global using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Fluent;
using NLog.Web;

namespace Elfo_Learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddNLog();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
           
            // Add services to the container.
            //Add fluent validation for validating
            builder.Services.AddControllers().AddFluentValidation();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
           
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}