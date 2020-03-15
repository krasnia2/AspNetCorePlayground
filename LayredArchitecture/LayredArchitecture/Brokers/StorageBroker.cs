using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayeredArchitecture.Brokers
{
    public class StorageBroker : IStorageBroker
    {
        public List<string> GetAllData()
        {
            return new List<string>
            {
                "A",
                "B",
                "C"
            };
        }
    }
}
