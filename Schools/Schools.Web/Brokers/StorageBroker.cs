using Microsoft.EntityFrameworkCore;
using Schools.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Web.Brokers
{
    public class StorageBroker : DbContext, IStorageBroker
    {
        private DbSet<Student> Students { get; set; }

        public async Task AddStudentAsync(Student student)
        {
            try
            {
                await this.Students.AddAsync(student);
                await this.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }

        }
    }
}
