global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Elfo_Learning.Context;
using Elfo_Learning.Mapping;
using Elfo_Learning.Repositories;
using Elfo_Learning.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
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
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            builder.Logging.AddNLog();
            builder.Services.AddTransient<IMailService,LocalMailService>();
            builder.Services.AddTransient<ICityRepository,CityRepository>();
            // Add services to the container.
            //Add fluent validation for validating
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddControllers().AddFluentValidation();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            builder.Services.AddDbContext<ElfoContext>(use => use.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:Key").Value));
            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}