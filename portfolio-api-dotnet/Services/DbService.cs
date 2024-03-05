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
            if (!_context.Projects.Any())
            {
                var project1 = new ProjectClass
                {
                    Name = "Project 1",
                    Description = "Description 1",
                    Link = "Link 1",
                    Label = "Label 1",
                    Order = 1,
                    Logo = "Logo 1"
                };
                var project2 = new ProjectClass
                {
                    Name = "Project 2",
                    Description = "Description 2",
                    Link = "Link 2",
                    Label = "Label 2",
                    Order = 2,
                    Logo = "Logo 2"
                };
                _context.Projects.AddRange(project1, project2);
                _context.SaveChanges();
            }
            if (!_context.Users.Any())
            {
                var user1 = new User
                {
                    Email = "user1@gmail.com",
                    FirstName = "User",
                    IsAdmin = false,
                    LastName = "One",
                    Password = "password"
                };
                var user2 = new User
                {
                    Email = "user2@gmail.com",
                    FirstName = "User",
                    IsAdmin = false,
                    LastName = "Two",
                    Password = "password"
                };
                _context.Users.AddRange(user1, user2);
                _context.SaveChanges();
            }
            if (!_context.Sections.Any())
            {
                var section1 = new Section
                {
                    Order = 1,
                    Title = "Section 1",
                    Header = "Header 1",
                    SubHeader = "SubHeader 1",
                    Contents = new List<ContentClass>
                    {
                        new ContentClass
                        {
                            Content = "Content 1",
                            Order = 1,
                            SectionId = 1
                        },
                        new ContentClass
                        {
                            Content = "Content 2",
                            Order = 2,
                            SectionId = 1
                        }
                    }
                };
                var section2 = new Section
                {
                    Order = 2,
                    Title = "Section 2",
                    Header = "Header 2",
                    SubHeader = "SubHeader 2",
                    Contents = new List<ContentClass>
                    {
                        new ContentClass
                        {
                            Content = "Content 1",
                            Order = 1,
                            SectionId = 2
                        },
                        new ContentClass
                        {
                            Content = "Content 2",
                            Order = 2,
                            SectionId = 2
                        }
                    }
                };
                _context.Sections.AddRange(section1, section2);
                _context.SaveChanges();
            }
        }
    }
}