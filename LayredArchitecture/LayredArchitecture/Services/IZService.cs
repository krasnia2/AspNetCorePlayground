using LayeredArchitecture.Models;

namespace LayeredArchitecture.Services
{
    // Abstracts communication with the Notification Class Library
    public interface IZService
    {
        NotificationResponse SendNotification(Notification notification);
    }
}
