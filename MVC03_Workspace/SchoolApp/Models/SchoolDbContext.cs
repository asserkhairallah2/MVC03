using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Models
{
    #region SchoolDbContext Class
    public class SchoolDbContext : DbContext
    {
        #region Constructor
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }
        #endregion

        #region OnModelCreating (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Composite Primary Key
            modelBuilder.Entity<StuCrsRes>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            #endregion

            #region Delete Behaviors (Prevent Cycles)
            modelBuilder.Entity<StuCrsRes>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StuCrsRes)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StuCrsRes)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
        #endregion
    }
    #endregion
}