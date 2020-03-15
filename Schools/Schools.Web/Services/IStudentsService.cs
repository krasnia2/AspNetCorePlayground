using Schools.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Web.Services
{
    public interface IStudentsService
    {
        Task RegisterStudentAsync(Student student);
    }
}
