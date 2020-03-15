using LayeredArchitecture.Models;
using LayeredArchitecture.Services;
using Moq;
using NUnit.Framework;
using Tynamix.ObjectFiller;

namespace LayeredArchitectureTests.Services
{
    public class BServiceTests
    {
        // given
        // when 
        // should

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
            var bService = new BService(zServiceMock.Object);
            bService.DoStuffB(notification);

            zServiceMock.Verify(broker =>
                broker.SendNotification(notification),
                Times.Once);
        }
    }
}
