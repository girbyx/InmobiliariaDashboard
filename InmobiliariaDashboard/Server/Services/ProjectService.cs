using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IProjectService : IBaseService<Project, ProjectHistory>
    {
        Task<bool> EmailProjectInformation(SendProjectInformationViewModel dto);
    }

    public class ProjectService : BaseService<Project, ProjectHistory>, IProjectService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public override Project Get(int id)
        {
            var records = _dbContext.Set<Project>()
                .Include(x => x.Enterprise.Contacts)
                .Include(x => x.Attachments)
                .Single(x => x.Id == id);
            return records;
        }

        public override int SaveAttachments(string[] files, int projectId)
        {
            if (files != null && files.Any())
            {
                return SaveToFileHosting(files, projectId, Constants.ProjectFolderPath);
            }

            return 0;
        }

        public async Task<bool> EmailProjectInformation(SendProjectInformationViewModel dto)
        {
            // get related entities
            var project = _dbContext.Set<Project>().Include(x => x.Attachments).First(x => x.Id == dto.ProjectId);
            var contact = _dbContext.Set<Contact>().First(x => x.Id == dto.ContactId);

            // build message
            var subject =
                $"{dto.Subject} || {BaseEnumeration.FromCode<ProjectTypeEnum>(project.ProjectType)} - {project.Name}";
            var message = "<html>" +
                          "<body>" +
                          $"<div>{dto.Message}</div>" +
                          "<h3>Adjuntos:</h3>";
            foreach (var attachment in project.Attachments)
            {
                message += $"<a href='{attachment.Url}'>{attachment.Name}.{attachment.ExtensionType}</a>" +
                           "<br/>";
            }

            message += @"</body>" +
                       "</html>";

            // setup email client
            var apiKey = _configuration[Constants.SendGridApiKey];
            var replyEmail = _configuration[Constants.ReplyEmail];
            var replyName = _configuration[Constants.ReplyName];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(replyEmail, replyName);
            var to = new EmailAddress(contact.Email, contact.Name);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, message);
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
    }
}