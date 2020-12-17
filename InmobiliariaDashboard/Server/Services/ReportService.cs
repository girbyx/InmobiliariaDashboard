using System;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IReportService
    {
        Task<string> BaseEnterpriseReport(ExcelPackage package, int id);
    }

    public class ReportService : IReportService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ReportService(IApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<string> BaseEnterpriseReport(ExcelPackage package, int id)
        {
            // get selected enterprise
            var enterprise = _dbContext.Set<Enterprise>()
                .Include(x => x.Projects).ThenInclude(x => x.Costs)
                .Include(x => x.Projects).ThenInclude(x => x.Gains)
                .Include(x => x.Projects).ThenInclude(x => x.Losses)
                .Include(x => x.Assets)
                .First(x => x.Id == id);

            // iterate by project
            var projects = enterprise.Projects.ToList();
            foreach (var project in projects)
            {
                var worksheet = package.Workbook.Worksheets.Add(enterprise.Name);
                worksheet.Cells["A1:G1"].Merge = true;

                // iterate costs
                var costs = project.Costs.ToList();

                // iterate gains
                var gains = project.Gains.ToList();

                // iterate losses
                var losses = project.Losses.ToList();
            }

            // iterate assets
            var assets = enterprise.Assets.ToList();
            foreach (var asset in assets)
            {
                
            }

            return $"BaseEnterpriseReport_{DateTime.Now.ToShortDateString()}.xlsx";
        }
    }
}