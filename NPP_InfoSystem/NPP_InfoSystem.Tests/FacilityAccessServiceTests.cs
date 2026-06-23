using Moq;
using NPP_InfoSystem.BusinessLogic;
using NPP_InfoSystem.Domain;
using NPP_InfoSystem.Domain.Interfaces;
using Xunit;

namespace NPP_InfoSystem.Tests
{
    public class FacilityAccessServiceTests
    {
        [Fact]
        public void InspectAccessPermission_WhenFacilityDoesNotExist_ReturnsFalse()
        {
            var mockRepo = new Mock<IFacilityRepository>();
            mockRepo.Setup(r => r.GetFacilityById(It.IsAny<int>())).Returns((NppFacility?)null);
            var service = new FacilityAccessService(mockRepo.Object);

            bool result = service.InspectAccessPermission(99, 3);

            Xunit.Assert.False(result);
        }

        [Theory]
        [InlineData(1, 2, false)]
        [InlineData(2, 2, true)]
        [InlineData(3, 1, true)]
        public void InspectAccessPermission_WhenClearanceChecked_ReturnsExpectedResult(
            int employeeClearance, int requiredFacilityClearance, bool expectedResult)
        {
            var testFacility = new NppFacility(1, "Блочний щит", requiredFacilityClearance);

            var mockRepo = new Mock<IFacilityRepository>();
            mockRepo.Setup(r => r.GetFacilityById(It.IsAny<int>())).Returns(testFacility);

            var service = new FacilityAccessService(mockRepo.Object);

            bool result = service.InspectAccessPermission(1, employeeClearance);

            Xunit.Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void InspectAccessPermission_WhenFacilityUnderMaintenance_ReturnsFalse()
        {
            var facility = new NppFacility(2, "Дизель-генераторна", 1)
            {
                IsUnderMaintenance = true
            };

            var mockRepo = new Mock<IFacilityRepository>();
            mockRepo.Setup(r => r.GetFacilityById(It.IsAny<int>())).Returns(facility);

            var service = new FacilityAccessService(mockRepo.Object);

            bool result = service.InspectAccessPermission(2, 3);

            Xunit.Assert.False(result);
        }
    }
}