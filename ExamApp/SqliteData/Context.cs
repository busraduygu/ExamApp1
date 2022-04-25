using ExamApp.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace ExamApp.SqliteData
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public Context()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>().HasMany(e => e.Questions).WithOne(q => q.Exam).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>().HasMany(q => q.Options).WithOne(o => o.Question).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Question>().HasOne(q => q.CorrectOption).WithOne(o => o.Question).OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "SqliteDb/Exam.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

    }
}
