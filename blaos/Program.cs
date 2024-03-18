using blaos.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

var app = builder.Build();
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
} else 
    app.UseHsts(); // This will add middleware for using hsts which adds a Strict-Transport-Security header

app.UseHttpsRedirection();
app.UseStaticFiles(); // This will use static files for the request. If we don't set a path to the static files dir, it will use a wwwroot foder 

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
    // The above will forward proxy headers to the current  request. This helps in deployment.
});

app.UseAuthorization();


app.MapControllers();

app.Run();
