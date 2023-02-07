using DevShop.Application.Abstractions;
using DevShop.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.SignalR.HubServices
{
    public class NotificationService:INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task GetNotificationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
