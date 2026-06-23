using Microsoft.EntityFrameworkCore;
using NPP_InfoSystem.Domain;

namespace NPP_InfoSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        // Ключове слово virtual є обов'язковим, щоб Moq міг підмінити цю колекцію у тестах!
        public virtual DbSet<NppFacility> Facilities { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}