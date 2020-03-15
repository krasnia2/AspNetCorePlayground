using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayeredArchitecture.Services
{
    public interface IDataProcessorService
    {
        List<string> ProcessData();
    }
}
