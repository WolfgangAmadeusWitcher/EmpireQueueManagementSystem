using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Domain.Models
{
    public class MonitoringHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public MonitoringHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
