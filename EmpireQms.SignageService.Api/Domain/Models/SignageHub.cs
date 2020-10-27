using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Domain.Models
{
    public class SignageHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignageHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        private void AddSignageToConnectionContext(Signage currentSignage)
        {
            if (!Context.Items.ContainsKey(Context.ConnectionId))
                Context.Items.Add(Context.ConnectionId, currentSignage);
            else
                Context.Items[Context.ConnectionId] = currentSignage;
        }

        public void ActivateSignage(Signage currentSignage)
        { 
            AddSignageToConnectionContext(currentSignage);
            currentSignage.ConnectionId = Context.ConnectionId;
            _unitOfWork.Signages.UpdateSignage(currentSignage);
        }

        public void InactivateSignage(Signage signage)
        {
            if(signage == null) return;
            Context.Items.Remove(Context.ConnectionId);
            signage.ConnectionId = string.Empty;
            _unitOfWork.Signages.UpdateSignage(signage);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var signage = Context.Items[Context.ConnectionId];
            InactivateSignage(signage as Signage);
            Context.Items.Remove(Context.ConnectionId);
            
            await base.OnDisconnectedAsync(exception);
        }
    }
}
