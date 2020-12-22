using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Shared.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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

        #region general

        public async Task<string> DetailBaseEnterpriseReport(ExcelPackage package, int id)
        {
            // get selected enterprise and setup vars
            var enterprise = _dbContext.Set<Enterprise>()
                .Include(x => x.Projects).ThenInclude(x => x.Costs).ThenInclude(x => x.CostType)
                .Include(x => x.Projects).ThenInclude(x => x.Gains).ThenInclude(x => x.GainType)
                .Include(x => x.Projects).ThenInclude(x => x.Losses).ThenInclude(x => x.LossType)
                .Include(x => x.Projects).ThenInclude(x => x.ProjectSubType)
                .Include(x => x.Assets)
                .First(x => x.Id == id);
            var projects = enterprise.Projects.ToList();

            // iterate by project non-movable assets
            var nonMovableAssets = projects.Where(x => x.ProjectType != ProjectTypeEnum.MovableAsset.Code).ToList();
            foreach (var nonMovableAsset in nonMovableAssets)
            {
                var currentRow = 1;
                var projectValue = -nonMovableAsset.PurchasePrice;

                // set title
                var worksheet = package.Workbook.Worksheets.Add($"{nonMovableAsset.Code}");
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = enterprise.Name;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.LightGray);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;

                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = nonMovableAsset.Name;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.Bisque);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;
                currentRow++;

                // iterate losses
                var losses = nonMovableAsset.Losses.ToList();
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}"].Value = "";
                worksheet.Cells[$"B{currentRow}"].Value = "$";
                worksheet.Cells[$"C{currentRow}"].Value = "#";
                worksheet.Cells[$"D{currentRow}"].Value = "Sub total";
                worksheet.Cells[$"E{currentRow}"].Value = "Comision";
                worksheet.Cells[$"F{currentRow}"].Value = "Total";
                worksheet.Cells[$"G{currentRow}"].Value = "Descripcion";
                currentRow++;
                foreach (var loss in losses)
                {
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                        .SetColor(Color.PaleVioletRed);
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[$"A{currentRow}"].Value = loss.LossType.Name;
                    worksheet.Cells[$"B{currentRow}"].Value = $"${loss.Value}";
                    worksheet.Cells[$"C{currentRow}"].Value = loss.Quantity;
                    worksheet.Cells[$"D{currentRow}"].Value = $"${loss.SubTotal}";
                    var commission = loss.CommissionType == CommissionTypeEnum.Money.Code
                        ? $"${loss.Commission}"
                        : $"{loss.Commission}%";
                    worksheet.Cells[$"E{currentRow}"].Value = commission;
                    worksheet.Cells[$"F{currentRow}"].Value = $"${loss.Total}";
                    worksheet.Cells[$"G{currentRow}"].Value = loss.Description;
                    currentRow++;
                    projectValue -= loss.Total;
                }

                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                worksheet.Cells[$"E{currentRow}"].Value = "Total egresos";
                worksheet.Cells[$"F{currentRow}"].Value = $"${losses.Sum(x => x.Total)}";
                currentRow++;
                currentRow++;

                // iterate costs
                var costs = nonMovableAsset.Costs.ToList();
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}"].Value = "";
                worksheet.Cells[$"B{currentRow}"].Value = "$";
                worksheet.Cells[$"C{currentRow}"].Value = "#";
                worksheet.Cells[$"D{currentRow}"].Value = "Sub total";
                worksheet.Cells[$"E{currentRow}"].Value = "Comision";
                worksheet.Cells[$"F{currentRow}"].Value = "Total";
                worksheet.Cells[$"G{currentRow}"].Value = "Descripcion";
                currentRow++;
                foreach (var cost in costs)
                {
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                        .SetColor(Color.PaleGoldenrod);
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[$"A{currentRow}"].Value = cost.CostType.Name;
                    worksheet.Cells[$"B{currentRow}"].Value = $"${cost.Value}";
                    worksheet.Cells[$"C{currentRow}"].Value = cost.Quantity;
                    worksheet.Cells[$"D{currentRow}"].Value = $"${cost.SubTotal}";
                    var commission = cost.CommissionType == CommissionTypeEnum.Money.Code
                        ? $"${cost.Commission}"
                        : $"{cost.Commission}%";
                    worksheet.Cells[$"E{currentRow}"].Value = commission;
                    worksheet.Cells[$"F{currentRow}"].Value = $"${cost.Total}";
                    worksheet.Cells[$"G{currentRow}"].Value = cost.Description;
                    currentRow++;
                    projectValue -= cost.Total;
                }

                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                worksheet.Cells[$"E{currentRow}"].Value = "Total costos";
                worksheet.Cells[$"F{currentRow}"].Value = $"${costs.Sum(x => x.Total)}";
                currentRow++;
                currentRow++;

                // iterate gains
                var gains = nonMovableAsset.Gains.ToList();
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}"].Value = "";
                worksheet.Cells[$"B{currentRow}"].Value = "$";
                worksheet.Cells[$"C{currentRow}"].Value = "#";
                worksheet.Cells[$"D{currentRow}"].Value = "Sub total";
                worksheet.Cells[$"E{currentRow}"].Value = "Comision";
                worksheet.Cells[$"F{currentRow}"].Value = "Total";
                worksheet.Cells[$"G{currentRow}"].Value = "Descripcion";
                currentRow++;
                foreach (var gain in gains)
                {
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                        .SetColor(Color.PaleGreen);
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[$"A{currentRow}"].Value = gain.GainType.Name;
                    worksheet.Cells[$"B{currentRow}"].Value = $"${gain.Value}";
                    worksheet.Cells[$"C{currentRow}"].Value = gain.Quantity;
                    worksheet.Cells[$"D{currentRow}"].Value = $"${gain.SubTotal}";
                    worksheet.Cells[$"E{currentRow}"].Value = "0%";
                    worksheet.Cells[$"F{currentRow}"].Value = $"${gain.SubTotal}";
                    worksheet.Cells[$"G{currentRow}"].Value = gain.Description;
                    currentRow++;
                    projectValue += gain.SubTotal;
                }

                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                worksheet.Cells[$"E{currentRow}"].Value = "Total ingresos";
                worksheet.Cells[$"F{currentRow}"].Value = $"${gains.Sum(x => x.SubTotal)}";
                currentRow++;
                currentRow++;

                // purchase cost
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}"].Value = "Valor adquisicion";
                worksheet.Cells[$"F{currentRow}"].Value = $"${nonMovableAsset.PurchasePrice}";
                currentRow++;

                // general balance
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}"].Value = "Balance total";
                worksheet.Cells[$"F{currentRow}"].Value = $"${projectValue}";
                currentRow++;

                // general balance + min
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}"].Value = $"Ganancia venta minima estimada (${nonMovableAsset.MinimumSellingPrice})";
                worksheet.Cells[$"F{currentRow}"].Value = $"${projectValue + nonMovableAsset.MinimumSellingPrice}";
                currentRow++;

                // general balance + max
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}"].Value = $"Ganancia venta maxima estimada (${nonMovableAsset.MaximumSellingPrice})";
                worksheet.Cells[$"F{currentRow}"].Value = $"${projectValue + nonMovableAsset.MaximumSellingPrice}";
            }

            // iterate by project movable assets
            {
                var currentRow = 1;

                // set title
                var worksheet = package.Workbook.Worksheets.Add("Muebles");
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = enterprise.Name;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.LightGray);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;

                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = "Muebles";
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.Bisque);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;
                currentRow++;

                var movableAssets = projects.OrderBy(x => x.ProjectSubTypeId)
                    .Where(x => x.ProjectType == ProjectTypeEnum.MovableAsset.Code).ToList();
                var projectSubTypes = movableAssets.Select(x => x.ProjectSubType.Name).Distinct().ToList();
                foreach (var projectSubType in projectSubTypes)
                {
                    var movableAssetsBySubType =
                        movableAssets.Where(x => x.ProjectSubType.Name == projectSubType).ToList();
                    worksheet.Cells[$"A{currentRow}"].Style.Font.Bold = true;
                    worksheet.Cells[$"A{currentRow}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[$"A{currentRow}"].Value = projectSubType;
                    currentRow++;

                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                        ExcelHorizontalAlignment.Center;
                    worksheet.Cells[$"A{currentRow}"].Value = "";
                    worksheet.Cells[$"B{currentRow}"].Value = "Costo adquisicion";
                    worksheet.Cells[$"C{currentRow}"].Value = "Perdida";
                    worksheet.Cells[$"D{currentRow}"].Value = "Inversion";
                    worksheet.Cells[$"E{currentRow}"].Value = "Ganancia";
                    worksheet.Cells[$"F{currentRow}"].Value = "Balance total";
                    currentRow++;

                    foreach (var movableAsset in movableAssetsBySubType)
                    {
                        worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        worksheet.Cells[$"A{currentRow}"].Value = $"{movableAsset.Code} - {movableAsset.Name}";
                        worksheet.Cells[$"B{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"B{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleTurquoise);
                        worksheet.Cells[$"B{currentRow}"].Value = $"${movableAsset.PurchasePrice}";
                        worksheet.Cells[$"C{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"C{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleVioletRed);
                        worksheet.Cells[$"C{currentRow}"].Value = $"${movableAsset.Losses.Sum(x => x.Total)}";
                        worksheet.Cells[$"D{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"D{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleGoldenrod);
                        worksheet.Cells[$"D{currentRow}"].Value = $"${movableAsset.Costs.Sum(x => x.Total)}";
                        worksheet.Cells[$"E{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[$"E{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
                        worksheet.Cells[$"E{currentRow}"].Value = $"${movableAsset.Gains.Sum(x => x.SubTotal)}";
                        worksheet.Cells[$"F{currentRow}"].Value = $@"${movableAsset.Gains.Sum(x => x.SubTotal)
                                                                  - movableAsset.Costs.Sum(x => x.Total)
                                                                  - movableAsset.Losses.Sum(x => x.Total)
                                                                  - movableAsset.PurchasePrice}";
                        currentRow++;
                        currentRow++;
                    }
                }
            }

            {
                var currentRow = 1;

                // set title
                var worksheet = package.Workbook.Worksheets.Add("Inventario");
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = enterprise.Name;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.LightGray);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;

                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = "Inventario";
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.Bisque);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;
                currentRow++;

                // iterate assets
                var assets = enterprise.Assets.ToList();
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:G{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}"].Value = "";
                worksheet.Cells[$"B{currentRow}"].Value = "$";
                worksheet.Cells[$"C{currentRow}"].Value = "#";
                worksheet.Cells[$"D{currentRow}"].Value = "Total";
                worksheet.Cells[$"E{currentRow}"].Value = "Descripcion";
                currentRow++;
                foreach (var asset in assets)
                {
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[$"B{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"B{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);

                    worksheet.Cells[$"A{currentRow}"].Value = asset.Name;
                    worksheet.Cells[$"B{currentRow}"].Value = $"${asset.Value}";
                    worksheet.Cells[$"C{currentRow}"].Value = asset.Quantity;
                    worksheet.Cells[$"D{currentRow}"].Value = $"${asset.SubTotal}";
                    worksheet.Cells[$"E{currentRow}"].Value = asset.Description;
                    currentRow++;
                }

                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"E{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"E{currentRow}"].Value = "Total inventario";
                worksheet.Cells[$"F{currentRow}"].Value = $"${assets.Sum(x => x.SubTotal)}";
            }

            // set quick balance sheet
            {
                var currentRow = 1;

                // set title
                var worksheet = package.Workbook.Worksheets.Add("Resumen inmuebles");
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = enterprise.Name;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.LightGray);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;

                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Merge = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Value = "Resumen";
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Fill.BackgroundColor
                    .SetColor(Color.Bisque);
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                currentRow++;
                currentRow++;

                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Font.Bold = true;
                worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{currentRow}"].Value = "";
                worksheet.Cells[$"B{currentRow}"].Value = "Costo adquisicion";
                worksheet.Cells[$"C{currentRow}"].Value = "Perdida";
                worksheet.Cells[$"D{currentRow}"].Value = "Inversion";
                worksheet.Cells[$"E{currentRow}"].Value = "Ganancia";
                worksheet.Cells[$"F{currentRow}"].Value = "Balance total";
                currentRow++;

                foreach (var nonMovableAsset in nonMovableAssets)
                {
                    worksheet.Cells[$"A{currentRow}:F{currentRow}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[$"A{currentRow}"].Value = $"{nonMovableAsset.Code} - {nonMovableAsset.Name}";
                    worksheet.Cells[$"B{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"B{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleTurquoise);
                    worksheet.Cells[$"B{currentRow}"].Value = $"${nonMovableAsset.PurchasePrice}";
                    worksheet.Cells[$"C{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"C{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleVioletRed);
                    worksheet.Cells[$"C{currentRow}"].Value = $"${nonMovableAsset.Losses.Sum(x => x.Total)}";
                    worksheet.Cells[$"D{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"D{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleGoldenrod);
                    worksheet.Cells[$"D{currentRow}"].Value = $"${nonMovableAsset.Costs.Sum(x => x.Total)}";
                    worksheet.Cells[$"E{currentRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[$"E{currentRow}"].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
                    worksheet.Cells[$"E{currentRow}"].Value = $"${nonMovableAsset.Gains.Sum(x => x.SubTotal)}";
                    worksheet.Cells[$"F{currentRow}"].Value = $@"${nonMovableAsset.Gains.Sum(x => x.SubTotal)
                                                              - nonMovableAsset.Costs.Sum(x => x.Total)
                                                              - nonMovableAsset.Losses.Sum(x => x.Total)
                                                              - nonMovableAsset.PurchasePrice}";
                    currentRow++;
                }
            }

            return $"BalanceDetallado_{enterprise.Name}_{DateTime.Now.ToShortDateString()}.xlsx";
        }

        public Task<string> SimpleBaseEnterpriseReport(ExcelPackage package, int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}