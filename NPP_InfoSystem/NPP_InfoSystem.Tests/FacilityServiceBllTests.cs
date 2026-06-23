using Moq;
using NPP_InfoSystem.BusinessLogic;
using NPP_InfoSystem.CCL.Security;
using NPP_InfoSystem.Domain;
using NPP_InfoSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NPP_InfoSystem.Tests
{
    public class FacilityServiceBllTests
    {
        [Fact]
        public void GetFacilitiesCatalog_WhenNotAdmin_ThrowsUnauthorizedAccessException()
        {
            // Arrange: Активний користувач - звичайний Інженер
            SecurityContext.SetUser(new Engineer(2, "Іван Інженер"));
            var mockRepo = new Mock<IFacilityRepository>();
            var service = new FacilityAccessService(mockRepo.Object);

            // Act & Assert: Має бути викинуто виключення
            Xunit.Assert.Throws<UnauthorizedAccessException>(() => service.GetFacilitiesCatalog());
        }

        [Fact]
        public void GetFacilitiesCatalog_WhenAdmin_ReturnsMappedDtos()
        {
            // Arrange: Активний користувач - Адміністратор
            SecurityContext.SetUser(new Admin(1, "Петро Адмін"));

            var facilities = new List<NppFacility>
            {
                new NppFacility(1, "Реакторне відділення", 3) { IsUnderMaintenance = true }
            };

            var mockRepo = new Mock<IFacilityRepository>();
            mockRepo.Setup(r => r.GetAllFacilities()).Returns(facilities);

            var service = new FacilityAccessService(mockRepo.Object);

            // Act
            var result = service.GetFacilitiesCatalog().ToList();

            // Assert: Перевіряємо, чи об'єкт правильно перетворився на DTO
            Xunit.Assert.Single(result);
            Xunit.Assert.Equal("Реакторне відділення", result[0].DisplayName);
            Xunit.Assert.Equal("На ремонті", result[0].StatusMessage);
        }
    }
}