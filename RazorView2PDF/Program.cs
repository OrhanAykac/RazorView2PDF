using PuppeteerSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


var app = builder.Build();

await Init();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


static Task Init()
{
    var browserFetcher = new BrowserFetcher();
    return browserFetcher.DownloadAsync();
}