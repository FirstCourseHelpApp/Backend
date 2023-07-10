using Backend.DAL.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Backend.Services.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }


        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<Point> Points { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<SubChapter> SubChapters { get; set; } = null!;
        public virtual DbSet<SubChapterProgress> SubChapterProgresses { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<TestProgress> TestProgresses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProgress> UsersProgress { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hello.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
