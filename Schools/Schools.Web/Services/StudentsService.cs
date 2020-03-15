using Microsoft.EntityFrameworkCore;
using Schools.Web.Brokers;
using Schools.Web.Exceptions;
using Schools.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Web.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentsService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async Task RegisterStudentAsync(Student student)
        {
            try
            {
                await this.storageBroker.AddStudentAsync(student);
            } 
            catch(DbUpdateException dbUpdateException)
            {
                this.loggingBroker.Error(dbUpdateException.Message);
                throw new StudentRegistrationFailedException();
            }
            
        }
    }
}
