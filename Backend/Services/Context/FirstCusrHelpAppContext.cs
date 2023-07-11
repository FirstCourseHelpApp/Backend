using Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Context
{
    public class FirstCusrHelpAppContext : DbContext
    {
        public FirstCusrHelpAppContext(DbContextOptions<FirstCusrHelpAppContext> options)
        : base(options) { }


        public virtual DbSet<Answer>? Answers { get; set; }
        public virtual DbSet<Chapter>? Chapters { get; set; }
        public virtual DbSet<Person>? Persons { get; set; }
        public virtual DbSet<Point>? Points { get; set; }
        public virtual DbSet<Question>? Questions { get; set; }
        public virtual DbSet<SubChapter>? SubChapters { get; set; }
        public virtual DbSet<SubChapterProgress>? SubChapterProgresses { get; set; }
        public virtual DbSet<Term>? Terms { get; set; }
        public virtual DbSet<Test>? Tests { get; set; }
        public virtual DbSet<TestProgress>? TestProgresses { get; set; }
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<UserProgress>? UsersProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProgress)
                .WithOne(p => p.User)
                .HasForeignKey<UserProgress>(up => up.UserId);
        }
    }
}
