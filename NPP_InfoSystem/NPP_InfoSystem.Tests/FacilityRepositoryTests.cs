using Microsoft.EntityFrameworkCore;
using Moq;
using NPP_InfoSystem.DataAccess;
using NPP_InfoSystem.Domain;
using Xunit;

namespace NPP_InfoSystem.Tests
{
    public class FacilityRepositoryTests
    {
        [Fact]
        public void Create_InputFacility_CalledAddMethodOfDbSet()
        {
            // Arrange (Організація)
            var testFacility = new NppFacility(1, "Реакторне відділення", 3);
            var mockSet = new Mock<DbSet<NppFacility>>();

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Facilities).Returns(mockSet.Object);

            var repository = new FacilityRepository(mockContext.Object);

            // Act (Дія)
            repository.Create(testFacility);

            // Assert (Твердження - перевіряємо чи викликався метод Add та SaveChanges)
            mockSet.Verify(m => m.Add(It.IsAny<NppFacility>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDbSet()
        {
            // Arrange
            var testFacility = new NppFacility(2, "Сховище", 2);
            var mockSet = new Mock<DbSet<NppFacility>>();

            // Налаштовуємо імітацію: якщо шукають ID 2, повертаємо наш тестовий об'єкт
            mockSet.Setup(m => m.Find(2)).Returns(testFacility);

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Facilities).Returns(mockSet.Object);

            var repository = new FacilityRepository(mockContext.Object);

            // Act
            repository.Delete(2);

            // Assert (Перевіряємо, чи спочатку знайдено об'єкт, а потім видалено)
            mockSet.Verify(m => m.Find(2), Times.Once());
            mockSet.Verify(m => m.Remove(testFacility), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}