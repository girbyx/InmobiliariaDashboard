using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Services;
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
        public async Task<HttpResponseMessage> BaseEnterpriseReport(int id)
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
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(memoryStream.ToArray())
            };

            // set proper headers
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/vnd.ms-excel");

            return result;
        }
    }
}