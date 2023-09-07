using aspdotnetwebapi.Entities;
using Microsoft.EntityFrameworkCore;
using Task = aspdotnetwebapi.Entities.Task;
namespace aspdotnetwebapi.DbContext
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        private const string CONNECTION_STRING = "Host=localhost;Port=5432;" +
                                                 "Username=postgres;" +
                                                 "Password=root;" +
                                                 "Database=aspdotnetwebapi";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DescCourse> DescriptionCourses { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Review?> Reviews { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Choice> Choices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        }

    }
}
