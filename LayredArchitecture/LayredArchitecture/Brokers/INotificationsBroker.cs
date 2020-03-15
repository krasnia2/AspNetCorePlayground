using BetterNotificationsLib.Models;

namespace LayeredArchitecture.Brokers
{
    public interface INotificationsBroker
    {
        public BetterNotificationResponse SendNotification(BetterNotification notification);
    }
}
