using System;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
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
            var enterprise = _dbContext.Set<Enterprise>().First(x => x.Id == id);
            var worksheet = package.Workbook.Worksheets.Add(enterprise.Name);
            worksheet.Cells["A1:G1"].Merge = true;
            return $"BaseEnterpriseReport_{DateTime.Now.ToShortDateString()}.xlsx";
        }
    }
}