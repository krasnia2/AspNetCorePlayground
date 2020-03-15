using LayeredArchitecture.Brokers;
using LayeredArchitecture.Models;
using LayeredArchitecture.Services;
using Moq;
using NUnit.Framework;
using Tynamix.ObjectFiller;

namespace LayeredArchitectureTests.Services
{
    public class AServiceTests
    {
        [Test]
        public void ShouldCallNotificationsBroker()
        {
            // given
            var zServiceMock = new Mock<IZService>();
            Notification notification = new Filler<Notification>().Create();

            NotificationResponse notificationResponse = new Filler<NotificationResponse>().Create();

            // when
            zServiceMock.Setup(broker => broker.SendNotification(notification))
                .Returns(notificationResponse);

            // should
            var aService = new AService(zServiceMock.Object);
            aService.DoStuffA(notification);

            zServiceMock.Verify(broker =>
                broker.SendNotification(notification),
                Times.Once);
        }
    }
}
