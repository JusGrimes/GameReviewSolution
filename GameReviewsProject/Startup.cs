using System;
using System.IO;
using FluentValidation;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using GameReviewSolution.Services;
using GameReviewSolution.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace GameReviewSolution;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "GameReviewsProject", Version = "v1"});
        });
        services.AddDbContext<GameReviewContext>(opt =>
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var separator = Path.DirectorySeparatorChar;
            opt.UseSqlite($"Data Source={path}{separator}GameReviewDatabase.db");
        });

        services.AddScoped<IValidator<GameDto>, GameDtoValidator>();
        services.AddScoped<IValidator<ReviewPostDto>, ReviewPostValidator>();
        services.AddScoped<IValidator<EmailAddress>, EmailAddressValidator>();

        services.AddScoped<IGameRepoService, GameRepoService>();
        services.AddScoped<IPublisherRepoService, PublisherRepoService>();
        services.AddScoped<IReviewPostRepoService, ReviewPostRepoService>();
        services.AddScoped<IUserRepoService, UserRepoService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameReviewsProject v1"));
        }

        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}