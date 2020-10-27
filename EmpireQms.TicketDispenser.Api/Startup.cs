using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.CommandHandlers;
using EmpireQms.TicketDispenser.Api.Domain.Commands;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;
using EmpireQms.TicketDispenser.Api.Integration.EventHandlers.EmpireQueues;
using EmpireQms.TicketDispenser.Api.Integration.EventHandlers.TicketCategories;
using EmpireQms.TicketDispenser.Api.Integration.Events.EmpireQueues;
using EmpireQms.TicketDispenser.Api.Integration.Events.TicketCategories;
using EmpireQms.TicketDispenser.Api.Persistence;
using EmpireQms.TicketDispenser.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.TicketDispenser.Api
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
            services.AddDbContext<TicketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TicketDispenserConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Dispenser Service", Version = "v1.0" }));
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
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Ticket Dispenser");
            });

            services.AddTransient<IRequestHandler<CreateTicketCommand, bool>, CreateTicketCommandHandler>();

            services.AddTransient<TicketCategoryUpdatedEventHandler>();
            services.AddTransient<TicketCategoryCreatedEventHandler>();
            services.AddTransient<TicketCategoryDeletedEventHandler>();

            services.AddTransient<EmpireQueueDeletedEventHandler>();
            services.AddTransient<EmpireQueueCreatedEventHandler>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IEmpireQueueRepository, EmpireQueueRepository>();
            services.AddTransient<TicketContext>();
        }

        public void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<TicketCategoryUpdatedEvent>, TicketCategoryUpdatedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryCreatedEvent>, TicketCategoryCreatedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryDeletedEvent>, TicketCategoryDeletedEventHandler>();

            services.AddTransient<IEventHandler<EmpireQueueCreatedEvent>, EmpireQueueCreatedEventHandler>();
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
                endpoints.MapHub<TicketCategoryHub>("/ticket-category");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Dispenser Service V1.0"));
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TicketCategoryUpdatedEvent, TicketCategoryUpdatedEventHandler>();
            eventBus.Subscribe<TicketCategoryCreatedEvent, TicketCategoryCreatedEventHandler>();
            eventBus.Subscribe<TicketCategoryDeletedEvent, TicketCategoryDeletedEventHandler>();

            eventBus.Subscribe<EmpireQueueCreatedEvent, EmpireQueueCreatedEventHandler>();
            eventBus.Subscribe<EmpireQueueDeletedEvent, EmpireQueueDeletedEventHandler>();
        }
    }
}
