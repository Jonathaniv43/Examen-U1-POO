using Microsoft.AspNetCore.Hosting;
using Examen.API;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();

app.UseAuthorization();

app.MapControllers();

app.Run();
