using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        private readonly IEmailService _emailService;

        public ProjectService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration,
            IEmailService emailService) : base(
            dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _emailService = emailService;
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
            var subject = $"{project.Code} - {project.Name} || {dto.Subject}";
            var message = "<html>" +
                          "<body>" +
                          $"<div>{dto.Message}</div>" +
                          "<div>----------------------------</div>";

            foreach (var attachment in project.Attachments)
            {
                message += "<div>" +
                           $"<a href='{attachment.Url}'>{attachment.Name}.{attachment.ExtensionType}</a>" +
                           "</div>";
            }

            message += "</body>" +
                       "</html>";

            return await _emailService.SendEmail(contact.Email, contact.Name, subject, string.Empty, message);
        }
    }
}