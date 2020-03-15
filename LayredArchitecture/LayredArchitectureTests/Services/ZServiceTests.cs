using BetterNotificationsLib.Models;
using FluentAssertions;
using LayeredArchitecture.Brokers;
using LayeredArchitecture.Models;
using LayeredArchitecture.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayeredArchitectureTests.Services
{
    public class ZServiceTests
    {
        [Test]
        public void ShouldCallNotificationBroker()
        {
            // given
            var notificationsBroker = new Mock<INotificationsBroker>();
            Guid notificationId = Guid.NewGuid();
            Guid notificationResponseId = Guid.NewGuid();

            //// lib model
            //var notification = new BetterNotification
            //{
            //    Id = notificationId
            //};

            // lib model
            var notificationResponse = new BetterNotificationResponse
            {
                Id = notificationResponseId
            };

            // internal model
            var inputNotification = new Notification
            {
                Id = notificationId
            };

            // internal model
            var expectedNotificationResponse = new NotificationResponse
            {
                Id = notificationResponseId
            };

            notificationsBroker.Setup(broker =>
                broker.SendNotification(
                    It.Is<BetterNotification>(notification => notification.Id == notificationId)))
                .Returns(notificationResponse);

            // when
            var zService = new ZService(notificationsBroker.Object);
            NotificationResponse actualResponse = zService.SendNotification(inputNotification);

            // then
            actualResponse.Should().BeEquivalentTo(expectedNotificationResponse);
        }
    }
}
