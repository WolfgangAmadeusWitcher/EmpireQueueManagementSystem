using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.CommandHandlers;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Domain.Repositories;
using EmpireQms.TerminalService.Api.Integration.EventHandlers.TerminalCategories;
using EmpireQms.TerminalService.Api.Integration.EventHandlers.Terminals;
using EmpireQms.TerminalService.Api.Integration.EventHandlers.TicketCategories;
using EmpireQms.TerminalService.Api.Integration.Events;
using EmpireQms.TerminalService.Api.Integration.Events.TerminalCategories;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;
using EmpireQms.TerminalService.Api.Integration.Events.TicketCategories;
using EmpireQms.TerminalService.Api.Persistence;
using EmpireQms.TerminalService.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.TerminalService.Api
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
            services.AddDbContext<TerminalContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TerminalDbConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Terminal Service", Version = "v1.0" }));
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
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Terminal");
            });

            services.AddTransient<IRequestHandler<CreateBreakLogEntryCommand, bool>, CreateBreakLogEntryCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBreakLogEntryCommand, bool>, UpdateBreakLogEntryCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTerminalStateCommand, bool>, UpdateTerminalStateCommandHandler>();

            services.AddTransient<TerminalSettingsUpdatedEventHandler>();
            services.AddTransient<ServiceCompletedForTerminalEventHandler>();
            services.AddTransient<NextPersonCalledEventHandler>();

            services.AddTransient<TerminalCreatedEventHandler>();
            services.AddTransient<TerminalDeletedEventHandler>();
            services.AddTransient<TerminalsSyncedEventHandler>();

            services.AddTransient<TerminalCategoryDeletedEventHandler>();
            services.AddTransient<TerminalCategoryCreatedEventHandler>();

            services.AddTransient<TicketCategoryDeletedEventHandler>();
            services.AddTransient<TicketCategoryCreatedEventHandler>();
            services.AddTransient<TicketCategoryUpdatedEventHandler>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITerminalRepository, TerminalRepository>();
            services.AddTransient<IBreakLogEntryRepository, BreakLogEntryRepository>();
            services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddTransient<ITerminalCategoryRepository, TerminalCategoryRepository>();
            services.AddTransient<TerminalContext>();
        }

        public void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<TerminalSettingsUpdatedEvent>, TerminalSettingsUpdatedEventHandler>();
            services.AddTransient<IEventHandler<ServiceCompletedForTerminalEvent>, ServiceCompletedForTerminalEventHandler>();
            services.AddTransient<IEventHandler<NextPersonCalledEvent>, NextPersonCalledEventHandler>();

            services.AddTransient<IEventHandler<TerminalCreatedEvent>, TerminalCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalDeletedEvent>, TerminalDeletedEventHandler>();
            services.AddTransient<IEventHandler<TerminalsSyncedEvent>, TerminalsSyncedEventHandler>();

            services.AddTransient<IEventHandler<TicketCategoryDeletedEvent>, TicketCategoryDeletedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryCreatedEvent>, TicketCategoryCreatedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryUpdatedEvent>, TicketCategoryUpdatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalCategoryCreatedEvent>, TerminalCategoryCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalCategoryDeletedEvent>, TerminalCategoryDeletedEventHandler>();
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
                endpoints.MapHub<TerminalHub>("/terminal");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Terminal Service V1.0"));
            ConfigureEventBus(app);
        }
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TerminalSettingsUpdatedEvent, TerminalSettingsUpdatedEventHandler>();
            eventBus.Subscribe<ServiceCompletedForTerminalEvent, ServiceCompletedForTerminalEventHandler>();
            eventBus.Subscribe<NextPersonCalledEvent, NextPersonCalledEventHandler>();

            eventBus.Subscribe<TerminalCreatedEvent, TerminalCreatedEventHandler>();
            eventBus.Subscribe<TerminalDeletedEvent, TerminalDeletedEventHandler>();
            eventBus.Subscribe<TerminalsSyncedEvent, TerminalsSyncedEventHandler>();

            eventBus.Subscribe<TicketCategoryCreatedEvent, TicketCategoryCreatedEventHandler>();
            eventBus.Subscribe<TicketCategoryUpdatedEvent, TicketCategoryUpdatedEventHandler>();
            eventBus.Subscribe<TicketCategoryDeletedEvent, TicketCategoryDeletedEventHandler>();

            eventBus.Subscribe<TerminalCategoryDeletedEvent, TerminalCategoryDeletedEventHandler>();
            eventBus.Subscribe<TerminalCategoryCreatedEvent, TerminalCategoryCreatedEventHandler>();
        }
    }
}
