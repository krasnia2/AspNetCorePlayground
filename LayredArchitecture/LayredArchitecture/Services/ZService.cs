using BetterNotificationsLib.Models;
using LayeredArchitecture.Brokers;
using LayeredArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    // Abstracts communication with the Notification Class Library
    public class ZService : IZService
    {
        private readonly INotificationsBroker _notificationsBroker;

        public ZService(INotificationsBroker notificationsBroker)
        {
            _notificationsBroker = notificationsBroker;
        }

        public NotificationResponse SendNotification(Notification notification)
        {
            var betterNotification = MapToBetterNotification(notification);
            var notificationResponse = _notificationsBroker.SendNotification(betterNotification);
            
            return MapToNotificationResponse(notificationResponse);
        }

        private NotificationResponse MapToNotificationResponse(BetterNotificationResponse betterNotificationResponse)
        {
            return new NotificationResponse 
            { 
                Id = betterNotificationResponse.Id 
            };
        }

        private BetterNotification MapToBetterNotification(Notification notification)
        {
            return new BetterNotification()
            {
                Id = notification.Id
            };
        }
    }
}
