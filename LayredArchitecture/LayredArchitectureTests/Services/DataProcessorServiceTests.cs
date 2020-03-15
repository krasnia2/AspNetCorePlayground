using FluentAssertions;
using LayeredArchitecture.Brokers;
using LayeredArchitecture.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;

namespace LayeredArchitectureTests
{
    public class DataProcessorServiceTests
    {
        // Break the Test into 3 categories
        // Given
        // When
        // Then
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnUpperCaseData()
        {
            // given
            var storageBrokerMock = new Mock<IStorageBroker>();
            var storageDataFiller = new Filler<string>();
            List<string> storageData = storageDataFiller.Create(10).ToList();

            storageBrokerMock.Setup(broker => broker.GetAllData())
                .Returns(storageData);

            List<string> expectedResult = storageData.Select(data => data.ToUpper()).ToList();

            // when
            var dataProcessorService = new DataProcessorService(storageBrokerMock.Object);
            List<string> actualResult = dataProcessorService.ProcessData();

            // then
            // Verify broker was called Only once during test
            storageBrokerMock.Verify(broker => 
                broker.GetAllData(), 
                Times.Once,
                "Storage broker should be called at least once for data processing");

            actualResult.Should().BeEquivalentTo(
                expectedResult, 
                because: "Returned items in list should be uppercase.");
        }
    }
}