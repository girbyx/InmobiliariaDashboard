using System;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IReportService
    {
        Task<string> DetailBaseEnterpriseReport(ExcelPackage package, int id);
        Task<string> SimpleBaseEnterpriseReport(ExcelPackage package, int id);
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

        public async Task<string> DetailBaseEnterpriseReport(ExcelPackage package, int id)
        {
            // get selected enterprise and setup vars
            var enterprise = _dbContext.Set<Enterprise>()
                .Include(x => x.Projects).ThenInclude(x => x.Costs)
                .Include(x => x.Projects).ThenInclude(x => x.Gains)
                .Include(x => x.Projects).ThenInclude(x => x.Losses)
                .Include(x => x.Assets)
                .First(x => x.Id == id);
            var projects = enterprise.Projects.ToList();

            // iterate by project non-movable assets
            var nonMovableAssets = projects.Where(x => x.ProjectType != ProjectTypeEnum.MovableAsset.Code).ToList();
            foreach (var project in nonMovableAssets)
            {
                // set title
                var worksheet = package.Workbook.Worksheets.Add(enterprise.Name);
                worksheet.Cells["A1:G1"].Merge = true;

                // iterate costs
                var costs = project.Costs.ToList();

                // iterate gains
                var gains = project.Gains.ToList();

                // iterate losses
                var losses = project.Losses.ToList();
            }

            // iterate by project movable assets
            var movableAssets = projects.OrderBy(x => x.ProjectSubTypeId).Where(x => x.ProjectType == ProjectTypeEnum.MovableAsset.Code).ToList();
            var projectSubTypes = movableAssets.Select(x => x.ProjectSubTypeId).ToList();
            foreach (var projectSubType in projectSubTypes)
            {
                var movableAssetsBySubType = movableAssets.Where(x => x.ProjectSubTypeId == projectSubType).ToList();

                // set title
                var worksheet = package.Workbook.Worksheets.Add(enterprise.Name);
                worksheet.Cells["A1:G1"].Merge = true;
            }

            // iterate assets
            var assets = enterprise.Assets.ToList();
            foreach (var asset in assets)
            {
                // set title
                var worksheet = package.Workbook.Worksheets.Add(enterprise.Name);
                worksheet.Cells["A1:G1"].Merge = true;
            }

            return $"BaseEnterpriseReport_{DateTime.Now.ToShortDateString()}.xlsx";
        }

        public Task<string> SimpleBaseEnterpriseReport(ExcelPackage package, int id)
        {
            throw new NotImplementedException();
        }
    }
}