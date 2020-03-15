using LayeredArchitecture.Brokers;
using LayeredArchitecture.Models;
using System;

namespace LayeredArchitecture.Services
{
    public class AService : IAService
    {
        private readonly IZService _zService;
        public AService(IZService zService)
        {
            _zService = zService;
        }

        public void DoStuffA(Notification notification)
        {
            _zService.SendNotification(notification);
        }
    }
}
