using _103.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace _103.Data
{
    public class UniDbContext : DbContext
    {
        private object EntityFramework;

        public DbSet<Marks> Mark { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Unit> Units { get; set; }


        public string? connectionString;
        public SqlConnection _connection;
        public UniDbContext(DbContextOptions<UniDbContext> options) : base(options)
        {
            _connection = new SqlConnection(Database.GetConnectionString());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=RJ-040\\SQLEXPRESS;Database=103;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.RegisterFilter(new MyCustomFilter());
            var filteredEntities = _dbContext.YourEntity.ToList();*/
/* // Configure soft delete for entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if the entity implements ISoftDelete
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    // Configure soft delete query filter for the entity
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(EntityFramework.Filters.EF.Property<bool>("sDeleted") == false);
                }

                var activeNotDeletedStudents = DbContext.Students
                    .ActiveStudents()
                    .NotDeletedStudents()
                    .ToList();
            }*/

           
            /*modelBuilder.Entity<Marks>().ToTable("Marks");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Unit>().ToTable("Unit");*/

            /* modelBuilder.Entity<Unit>()
                  .HasOne(u => u.Teacher)
                  .WithMany(t => t.Unit)
                  .HasForeignKey(u => u.TeacherID);*/

            /*modelBuilder.Entity<Marks>()
                 .HasOne(m => m.Unit)
                 .WithMany(u => u.Mark)
                 .HasForeignKey(m => m.UnitID);

            modelBuilder.Entity<Marks>()
                 .HasOne(m => m.Student)
                 .WithMany(u => u.Mark)
                 .HasForeignKey(m => m.StudentID);*/
        }
    }
}