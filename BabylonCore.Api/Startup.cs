using System;
using System.Net;
using BabylonCore.Application.Interfaces;
using BabylonCore.Application.Patients.Commands.CreatePatientCommand;
using BabylonCore.Application.Patients.Commands.UpdatePatientCommand;
using BabylonCore.Application.Patients.Queries.GetPatientByIdQuery;
using BabylonCore.Application.Patients.Queries.GetPatientListQuery;
using BabylonCore.Domain.Patients;
using BabylonCore.Persistence;
using BabylonCore.Persistence.Patients;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace BabylonCore.Api
{
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
            //services.AddSingleton<IDbStore<Patient>, DbStore<Patient>>();
            //services.AddTransient<IMailService, MailService>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IGetPatientByIdQuery, GetPatientByIdQuery>();
            services.AddTransient<IGetPatientListQuery, GetPatientListQuery>();
            services.AddTransient<ICreatePatientCommand, CreatePatientCommand>();
            services.AddTransient<IUpdatePatientCommand, UpdatePatientCommand>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Patients Service API", Version = "v1" });
            });


            services
                .AddCouchbase(Configuration.GetSection("Couchbase"))
                .AddCouchbaseBucket<IPatientBucketProvider>("patients", "");

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                    {
                        var errorId = Guid.NewGuid();
                        var logger = loggerFactory.CreateLogger("Global exception logger");
                        logger.LogError(errorId.ToString(), exception.Error, exception.Error.Message);
                        var requestBody = context.Request.Body.ToString();
                        var requestHeaders = context.Request.Headers.ToString();
                        logger.LogError(errorId.ToString(), $"REQUEST LOG: BODY: {requestBody} HEADERS: {requestHeaders}", "Request Information");

                        if (exception.Error.Source == "FluentValidation")
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                            await context.Response.WriteAsync(exception.Error.Message);
                        }
                    }

                    if (context.Response.StatusCode == default(int))
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Unexpected error occurred. Try again later.");
                    }
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patients Services API");
            });

            applicationLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close();
            });
            app.UseMvc();
        }
    }
}
