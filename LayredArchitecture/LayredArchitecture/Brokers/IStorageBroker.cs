using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayeredArchitecture.Brokers
{
    public interface IStorageBroker
    {
        List<string> GetAllData();

    }
}
