using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Domain.Repositories;
using EmpireQms.SignageService.Api.Integration.EventHandlers.Signages;
using EmpireQms.SignageService.Api.Integration.EventHandlers.Terminals;
using EmpireQms.SignageService.Api.Integration.EventHandlers.TerminalSignages;
using EmpireQms.SignageService.Api.Integration.EventHandlers.Tickets;
using EmpireQms.SignageService.Api.Integration.Events.Signages;
using EmpireQms.SignageService.Api.Integration.Events.Terminals;
using EmpireQms.SignageService.Api.Integration.Events.TerminalSignages;
using EmpireQms.SignageService.Api.Integration.Events.Tickets;
using EmpireQms.SignageService.Api.Persistence;
using EmpireQms.SignageService.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.SignageService.Api
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
            services.AddDbContext<SignageContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SignageDbConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Signage Service", Version = "v1.0" }));
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
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Signage");
            });

            services.AddTransient<TerminalSettingsUpdatedEventHandler>();
            services.AddTransient<TerminalStateUpdatedEventHandler>();

            services.AddTransient<TerminalCreatedEventHandler>();
            services.AddTransient<TerminalDeletedEventHandler>();
            services.AddTransient<TerminalsSyncedEventHandler>();

            services.AddTransient<TerminalSignageDeletedEventHandler>();
            services.AddTransient<TerminalSignageCreatedEventHandler>();

            services.AddTransient<SignageDeletedEventHandler>();
            services.AddTransient<SignageCreatedEventHandler>();
            services.AddTransient<SignageUpdatedEventHandler>();
            services.AddTransient<SignagesSyncedEventHandler>();

            services.AddTransient<NextPersonCalledEventHandler>();
            services.AddTransient<ServiceCompletedForTerminalEventHandler>();
        }
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITerminalRepository, TerminalRepository>();
            services.AddTransient<ISignageRepository, SignageRepository>();
            services.AddTransient<ITerminalSignageRepository, TerminalSignageRepository>();
            services.AddTransient<SignageContext>();
        }

        private void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<TerminalSettingsUpdatedEvent>, TerminalSettingsUpdatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalStateUpdatedEvent>, TerminalStateUpdatedEventHandler>();

            services.AddTransient<IEventHandler<TerminalCreatedEvent>, TerminalCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalDeletedEvent>, TerminalDeletedEventHandler>();
            services.AddTransient<IEventHandler<TerminalsSyncedEvent>, TerminalsSyncedEventHandler>();

            services.AddTransient<IEventHandler<SignageDeletedEvent>, SignageDeletedEventHandler>();
            services.AddTransient<IEventHandler<SignageCreatedEvent>, SignageCreatedEventHandler>();
            services.AddTransient<IEventHandler<SignageUpdatedEvent>, SignageUpdatedEventHandler>();
            services.AddTransient<IEventHandler<SignagesSyncedEvent>, SignagesSyncedEventHandler>();

            services.AddTransient<IEventHandler<TerminalSignageCreatedEvent>, TerminalSignageCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalSignageDeletedEvent>, TerminalSignageDeletedEventHandler>();

            services.AddTransient<IEventHandler<NextPersonCalledEvent>, NextPersonCalledEventHandler>();
            services.AddTransient<IEventHandler<ServiceCompletedForTerminalEvent>, ServiceCompletedForTerminalEventHandler>();
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
                endpoints.MapHub<SignageHub>("/signage");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Signage Service V1.0"));
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TerminalSettingsUpdatedEvent, TerminalSettingsUpdatedEventHandler>();
            eventBus.Subscribe<TerminalStateUpdatedEvent, TerminalStateUpdatedEventHandler>();
            eventBus.Subscribe<TerminalCreatedEvent, TerminalCreatedEventHandler>();
            eventBus.Subscribe<TerminalDeletedEvent, TerminalDeletedEventHandler>();
            eventBus.Subscribe<TerminalsSyncedEvent, TerminalsSyncedEventHandler>();

            eventBus.Subscribe<SignageCreatedEvent, SignageCreatedEventHandler>();
            eventBus.Subscribe<SignageUpdatedEvent, SignageUpdatedEventHandler>();
            eventBus.Subscribe<SignageDeletedEvent, SignageDeletedEventHandler>();
            eventBus.Subscribe<SignagesSyncedEvent, SignagesSyncedEventHandler>();

            eventBus.Subscribe<TerminalSignageDeletedEvent, TerminalSignageDeletedEventHandler>();
            eventBus.Subscribe<TerminalSignageCreatedEvent, TerminalSignageCreatedEventHandler>();

            eventBus.Subscribe<NextPersonCalledEvent, NextPersonCalledEventHandler>();
            eventBus.Subscribe<ServiceCompletedForTerminalEvent, ServiceCompletedForTerminalEventHandler>();
        }
    }
}
