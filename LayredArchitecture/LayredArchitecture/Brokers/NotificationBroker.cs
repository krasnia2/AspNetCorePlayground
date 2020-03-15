using BetterNotificationsLib;
using BetterNotificationsLib.Models;

namespace LayeredArchitecture.Brokers
{
    public class NotificationBroker : INotificationsBroker
    {
        private readonly BetterNotificationsService _notificationsService;

        public NotificationBroker()
        {
            _notificationsService = new BetterNotificationsService();
        }

        public BetterNotificationResponse SendNotification(BetterNotification notification)
        {
            return this._notificationsService.SendNotification(notification);
        }
    }
}
