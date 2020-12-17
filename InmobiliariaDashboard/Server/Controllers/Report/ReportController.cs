using System.IO;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;

namespace InmobiliariaDashboard.Server.Controllers.Report
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _baseService;

        public ReportController(ILogger<ReportController> logger, IReportService baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        [Route("BaseEnterpriseReport")]
        public async Task<IActionResult> BaseEnterpriseReport(int id)
        {
            string fileName;
            var memoryStream = new MemoryStream();
            using (var package = new ExcelPackage())
            {
                // get the report
                fileName = await _baseService.BaseEnterpriseReport(package, id);
                await package.SaveAsAsync(memoryStream);
            }

            // process the stream
            memoryStream.Position = 0;
            return File(memoryStream.ToArray(), Constants.ExcelMimeType, fileName);
        }
    }
}