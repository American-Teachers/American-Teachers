//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AtApi.Model.At
{
   /// <summary>
   /// Model Summary
   /// </summary>
   public partial class AtDbContext : DbContext
   {
      #region DbSets

      /// <summary>
      /// Repository for global::AtApi.Model.Class - Class
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.Class> Classes { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Enrollment - Enrollment
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Enrollment> Enrollment { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.Parent - Parent
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.Parent> Parents { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.ParentStudent> ParentStudents { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.Person - Person
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.Person> People { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Schedule - Schedule
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Schedule> Schedules { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.School - School
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.School> Schools { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.Student - Student
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.Student> Students { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.Teacher - Teacher
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.Teacher> Teachers { get; set; }
      #endregion DbSets

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Name=AmericanTeachers";

      /// <inheritdoc />
      public AtDbContext(DbContextOptions<AtDbContext> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <inheritdoc />
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("AmericanTeacher");

         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .ToTable("Class")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedNever();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.Name)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.Description)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.Code)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.Subject)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.EstimatedNumberOfStudents)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .Property(t => t.TeacherId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .HasMany(x => x.Schedules)
                     .WithOne()
                     .HasForeignKey("Schedule_Schedules_Id");
         modelBuilder.Entity<global::AtApi.Model.Class>()
                     .HasOne(x => x.Teacher)
                     .WithMany()
                     .HasForeignKey("Teacher_Id");

         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .ToTable("Enrollments")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedNever();
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.ClassId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.StudentId)
                     .IsRequired();


         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .ToTable("ParentStudent")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .HasOne(x => x.Parent)
                     .WithOne(x => x.ParentStudents)
                     .HasForeignKey<global::AtApi.Model.At.ParentStudent>();
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .HasOne(x => x.Student)
                     .WithOne(x => x.ParentStudents)
                     .HasForeignKey<global::AtApi.Model.At.ParentStudent>();

         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .ToTable("Person")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedNever();
         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .Property(t => t.EmailAddress)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Person>().HasIndex(t => t.EmailAddress);
         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .Property(t => t.FirstName)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .Property(t => t.LastName)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.Person>()
                     .Property(t => t.PreferredName)
                     .HasMaxLength(1000);

         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .ToTable("Schedule")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .Property(t => t.Name)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .Property(t => t.Day)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .Property(t => t.Time)
                     .HasMaxLength(100)
                     .IsRequired();

         modelBuilder.Entity<global::AtApi.Model.School>()
                     .ToTable("School")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.School>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedNever();
         modelBuilder.Entity<global::AtApi.Model.School>()
                     .Property(t => t.Name)
                     .IsRequired();


         modelBuilder.Entity<global::AtApi.Model.Teacher>()
                     .HasMany(x => x.Schools)
                     .WithOne()
                     .HasForeignKey("School_Schools_Id");

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
