using LayeredArchitecture.Brokers;
using LayeredArchitecture.Models;
using System;

namespace LayeredArchitecture.Services
{
    public class BService : IBService
    {
        private readonly IZService _zService;

        public BService(IZService zService)
        {
            _zService = zService;
        }

        public void DoStuffB(Notification notification)
        {
            _zService.SendNotification(notification);
        }
    }
}
