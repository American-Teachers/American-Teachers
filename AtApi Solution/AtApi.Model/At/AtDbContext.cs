using AtApi.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AtApi.Model.At
{
    public partial class AtDbContext 	
    {


        public AtDbContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            ConnectionString = connectionString;
        }

        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConnectionString);
            }
        }
        partial void OnModelCreatedImpl(ModelBuilder modelBuilder)
        {
            ////seed data
            //foreach (var item in Enum.GetValues(typeof(ScheduleDays)))
            //{
            //    modelBuilder.Entity<ScheduleDay>().HasData(new ScheduleDay { Id = (int)item, Name = nameof(item) });
            //}
        }

    }
}
