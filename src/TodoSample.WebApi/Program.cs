using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using TodoSample.Infrastructure.Extensions;
using TodoSample.Services.Extensions;
using TodoSample.WebApi.Middlewares;
using TodoSample.WebApi.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddVersioning();

builder.Services.AddSwagger();

builder.Services.AddLoggingToPipeline();

builder.Services.AddEntityFramework();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseSwaggerWithVersioning(apiVersionDescriptionProvider);

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();



