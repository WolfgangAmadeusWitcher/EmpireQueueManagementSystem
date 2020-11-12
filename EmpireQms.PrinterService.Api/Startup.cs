using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.PrintService.Api.Domain;
using EmpireQms.PrintService.Api.Domain.Repositories;
using EmpireQms.PrintService.Api.Integration.EventHandlers.PrintTemplates;
using EmpireQms.PrintService.Api.Integration.Events.PrintTemplates;
using EmpireQms.PrintService.Api.Persistence;
using EmpireQms.PrintService.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmpireQms.Printer.Api
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
            services.AddCors();
            services.AddDbContext<PrintContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PrintServiceConnection"));
            });
            services.AddSignalR();
            //services.AddMediatR(typeof(Startup));
            RegisterServices(services);
            RegisterRepositories(services);
            AddEventHandlers(services);
            services.AddControllers();

        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Print Service");
            });

            services.AddTransient<PrintTemplateCreatedEventHandler>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPrintTemplateRepository, PrintTemplateRepository>();
        }

        private void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<PrintTemplateCreatedEvent>, PrintTemplateCreatedEventHandler>();
        }

       

     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PrintTemplateCreatedEvent, PrintTemplateCreatedEventHandler>();
        }
    }
}
