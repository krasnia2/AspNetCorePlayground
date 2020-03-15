using Schools.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Web.Brokers
{
    public interface IStorageBroker
    {
        Task AddStudentAsync(Student student);
    }
}
