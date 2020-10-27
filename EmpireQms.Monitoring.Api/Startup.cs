using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Domain.Repositories;
using EmpireQms.Monitoring.Api.Integration.EventHandlers.BreakLogEntries;
using EmpireQms.Monitoring.Api.Integration.EventHandlers.EmpireQueues;
using EmpireQms.Monitoring.Api.Integration.EventHandlers.Terminals;
using EmpireQms.Monitoring.Api.Integration.Events.BreakLogEntries;
using EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues;
using EmpireQms.Monitoring.Api.Integration.Events.Terminals;
using EmpireQms.Monitoring.Api.Persistence;
using EmpireQms.Monitoring.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.Monitoring.Api
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
            services.AddDbContext<MonitoringContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MonitoringDbConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Monitoring Service", Version = "v1.0" }));
            services.AddSignalR();
            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
            RegisterRepositories(services);
            AddEventHandlers(services);
            services.AddControllers();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Monitoring");
            });

            services.AddTransient<TerminalStateUpdatedEventHandler>();
            services.AddTransient<TerminalSettingsUpdatedEventHandler>();

            services.AddTransient<TerminalCreatedEventHandler>();
            services.AddTransient<TerminalDeletedEventHandler>();

            services.AddTransient<BreakLogEntryUpdatedEventHandler>();
            services.AddTransient<BreakLogEntryCreatedEventHandler>();

            services.AddTransient<EmpireQueueCreatedEventHandler>();
            services.AddTransient<EmpireQueueUpdatedEventHandler>();
            services.AddTransient<EmpireQueueDeletedEventHandler>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITerminalRepository, TerminalRepository>();
            services.AddTransient<IBreakLogEntryRepository, BreakLogEntryRepository>();
            services.AddTransient<IEmpireQueueRepository, EmpireQueueRepository>();
            services.AddTransient<MonitoringContext>();
        }

        public void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<TerminalStateUpdatedEvent>, TerminalStateUpdatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalSettingsUpdatedEvent>, TerminalSettingsUpdatedEventHandler>();

            services.AddTransient<IEventHandler<TerminalCreatedEvent>, TerminalCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalDeletedEvent>, TerminalDeletedEventHandler>();

            services.AddTransient<IEventHandler<BreakLogEntryUpdatedEvent>, BreakLogEntryUpdatedEventHandler>();
            services.AddTransient<IEventHandler<BreakLogEntryCreatedEvent>, BreakLogEntryCreatedEventHandler>();

            services.AddTransient<IEventHandler<EmpireQueueCreatedEvent>, EmpireQueueCreatedEventHandler>();
            services.AddTransient<IEventHandler<EmpireQueueUpdatedEvent>, EmpireQueueUpdatedEventHandler>();
            services.AddTransient<IEventHandler<EmpireQueueDeletedEvent>, EmpireQueueDeletedEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MonitoringHub>("/monitoring");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Monitoring Service V1.0"));
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TerminalSettingsUpdatedEvent, TerminalSettingsUpdatedEventHandler>();
            eventBus.Subscribe<TerminalStateUpdatedEvent, TerminalStateUpdatedEventHandler>();

            eventBus.Subscribe<TerminalCreatedEvent, TerminalCreatedEventHandler>();
            eventBus.Subscribe<TerminalDeletedEvent, TerminalDeletedEventHandler>();

            eventBus.Subscribe<BreakLogEntryCreatedEvent, BreakLogEntryCreatedEventHandler>();
            eventBus.Subscribe<BreakLogEntryUpdatedEvent, BreakLogEntryUpdatedEventHandler>();

            eventBus.Subscribe<EmpireQueueCreatedEvent, EmpireQueueCreatedEventHandler>();
            eventBus.Subscribe<EmpireQueueUpdatedEvent, EmpireQueueUpdatedEventHandler>();
            eventBus.Subscribe<EmpireQueueDeletedEvent, EmpireQueueDeletedEventHandler>();
        }
    }
}
