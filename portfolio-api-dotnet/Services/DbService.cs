using Microsoft.EntityFrameworkCore;
using portfolio_api_dotnet.Models;

namespace Project.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // Define DbSets for each entity
        public DbSet<ProjectClass> Projects { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }

    }

    public class EFService
    {
        private readonly MyDbContext _context;

        public EFService(MyDbContext context)
        {
            _context = context;
            SeedDatabase();
        }

        // Example method to add an entity
        public void AddEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        // Example method to update an entity
        public void UpdateEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        // Example method to delete an entity
        public void DeleteEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        // Example method to query entities
        public List<T> QueryEntities<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        private void SeedDatabase()
        {
            // Check if database is already seeded
            if (!_context.Experiences.Any())
            {
                var experience1 = new Experience
                {
                    Title = "Software Developer",
                    Content = "Developed software",
                    Date = "2020-2021"
                };
                var experience2 = new Experience
                {
                    Title = "Software Developer II",
                    Content = "Developed software",
                    Date = "2020-2021"
                };
                _context.Experiences.AddRange(experience1, experience2);
                _context.SaveChanges();
            }

        }
    }
}