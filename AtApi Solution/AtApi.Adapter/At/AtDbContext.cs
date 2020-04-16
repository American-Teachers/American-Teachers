using Microsoft.EntityFrameworkCore;
using System;
using AtApi.Model;

namespace AtApi.Adapter.At
{
    public class AtDbContext : DbContext
    {
        private readonly string _connectionString;

        public AtDbContext()
        {

        }

        public AtDbContext(DbContextOptions<AtDbContext> options) : base(options)
        {

        }

        public AtDbContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString);
            }
           
        }//
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            foreach (var item in Enum.GetValues(typeof(ScheduleDays)))
            {
                modelBuilder.Entity<ScheduleDay>().HasData(new ScheduleDay { Id = (int)item, Name = nameof(item) });
            }
           
        }


        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Teacher> Parents { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

    }
}
