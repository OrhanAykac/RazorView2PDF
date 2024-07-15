using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using Razor.Templating.Core;
using RazorView2PDF.Models;

namespace RazorView2PDF.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet]
    public async Task<IResult> DailySales()
    {

        List<DailySalesModel> sales =
        [
            new DailySalesModel { ProductName = "Pantolon", Price = 10, Quantity = 3 },
            new DailySalesModel { ProductName = "Kaban", Price = 20, Quantity = 8 },
            new DailySalesModel { ProductName = "Elbise", Price = 15, Quantity = 15 },
        ];

        string html = await RazorTemplateEngine.RenderAsync(
    viewName: "/Views/Report/DailySales.cshtml",
    viewModel: sales);


        await using var browser = await Puppeteer.LaunchAsync(
            new LaunchOptions { Headless = true });




        await using var page = await browser.NewPageAsync();

        await page.SetContentAsync(html);

        var streamPDF = await page.PdfStreamAsync();

        return Results.File(streamPDF, "application/pdf", "pdfFile.pdf");
    }
}
