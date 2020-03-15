using LayeredArchitecture.Brokers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LayeredArchitecture.Services
{
    public class DataProcessorService : IDataProcessorService
    {
        private readonly IStorageBroker _storageBroker;
        public DataProcessorService(IStorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        public List<string> ProcessData()
        {
            return _storageBroker.GetAllData()
                .Select(item => item.ToUpper())
                .ToList();
        }
    }
}
