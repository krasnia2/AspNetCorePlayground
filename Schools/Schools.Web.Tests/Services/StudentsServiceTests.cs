using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Schools.Web.Brokers;
using Schools.Web.Exceptions;
using Schools.Web.Models;
using Schools.Web.Services;
using System;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace Schools.Web.Tests
{
    public class StudentsServiceTests
    {
        private Mock<ILoggingBroker> loggingBrokerMock;

        [SetUp]
        public void Setup()
        {
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
        }

        [Test]
        public async Task ShouldPersistStudentWhenStudentIsPassedIn()
        {
            // given
            var storageBrokerMock = new Mock<IStorageBroker>();
            Student student = new Filler<Student>().Create();

            storageBrokerMock.Setup(broker => broker.AddStudentAsync(student));

            // when
            var studentsService = new StudentsService(storageBrokerMock.Object, this.loggingBrokerMock.Object);
            await studentsService.RegisterStudentAsync(student);

            // then
            storageBrokerMock.Verify(broker => 
                broker.AddStudentAsync(student),
                Times.Once);
        }

        [Test]
        public async Task ShouldThrowStudentRegistrationExceptionWhenStorageFails()
        {
            // given
            var storageBrokerMock = new Mock<IStorageBroker>();
            Student student = new Filler<Student>().Create();
            var dbUpdateException = new DbUpdateException(
                message: "Exception",
                innerException: new Exception());

            storageBrokerMock.Setup(broker => 
                broker.AddStudentAsync(student))
                    .ThrowsAsync(dbUpdateException);

            // when
            var studentsService = new StudentsService(storageBrokerMock.Object, this.loggingBrokerMock.Object);

            Task registerStudentTask = studentsService.RegisterStudentAsync(student);

            // then
            Assert.ThrowsAsync<StudentRegistrationFailedException>(
                () => registerStudentTask);

            this.loggingBrokerMock.Verify(broker => broker.Error(dbUpdateException.Message), Times.Once);
        }
    }
}