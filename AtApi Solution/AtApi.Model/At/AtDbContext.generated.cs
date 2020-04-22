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
      /// Repository for global::AtApi.Model.At.Class - Class
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Class> Classes { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Enrollment - Enrollment
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Enrollment> Enrollment { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Parent - Parent
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Parent> Parents { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.ParentStudent> ParentStudents { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Person - Person
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Person> People { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Schedule - Schedule
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Schedule> Schedules { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.School - School
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.School> Schools { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Student - Student
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Student> Students { get; set; }

      /// <summary>
      /// Repository for global::AtApi.Model.At.Teacher - Teacher
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.Teacher> Teachers { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::AtApi.Model.At.TeacherSchool> TeacherSchools { get; set; }
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


         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .ToTable("Classes")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.Name)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.Description)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.Code)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.Subject)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.EstimatedNumberOfStudents)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>().HasIndex(t => t.ScheduleId);
         modelBuilder.Entity<global::AtApi.Model.At.Class>()
                     .Property(t => t.TeacherId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Class>().HasIndex(t => t.TeacherId);

         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .ToTable("Enrollments")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.ClassId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>().HasIndex(t => t.ClassId);
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .Property(t => t.StudentId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>().HasIndex(t => t.StudentId);
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .HasOne(x => x.Class_)
                     .WithOne(x => x.Enrollments)
                     .HasForeignKey<global::AtApi.Model.At.Enrollment>("ClassId");
         modelBuilder.Entity<global::AtApi.Model.At.Enrollment>()
                     .HasOne(x => x.Student)
                     .WithOne(x => x.Enrollments)
                     .HasForeignKey<global::AtApi.Model.At.Enrollment>("StudentId");


         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .ToTable("ParentStudents")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .Property(t => t.ParentId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>().HasIndex(t => t.ParentId);
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .Property(t => t.StudentId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>().HasIndex(t => t.StudentId);
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .HasOne(x => x.Parent)
                     .WithOne(x => x.Students)
                     .HasForeignKey<global::AtApi.Model.At.ParentStudent>("ParentId")
                     .OnDelete(DeleteBehavior.Cascade);
         modelBuilder.Entity<global::AtApi.Model.At.ParentStudent>()
                     .HasOne(x => x.Student)
                     .WithOne(x => x.ParentStudents)
                     .HasForeignKey<global::AtApi.Model.At.ParentStudent>("StudentId")
                     .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .ToTable("People")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .Property(t => t.EmailAddress)
                     .HasMaxLength(1000)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .Property(t => t.FirstName)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .Property(t => t.LastName)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.Person>()
                     .Property(t => t.PreferredName)
                     .HasMaxLength(1000);

         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .ToTable("Schedules")
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
         modelBuilder.Entity<global::AtApi.Model.At.Schedule>()
                     .HasMany(x => x.Classes)
                     .WithOne()
                     .HasForeignKey("Class_Classes_Id");

         modelBuilder.Entity<global::AtApi.Model.At.School>()
                     .ToTable("Schools")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.School>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.School>()
                     .Property(t => t.Name)
                     .IsRequired();


         modelBuilder.Entity<global::AtApi.Model.At.Teacher>()
                     .HasMany(x => x.Classes)
                     .WithOne()
                     .HasForeignKey("Class_Classes_Id")
                     .IsRequired();

         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .ToTable("TeacherSchools")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .Property(t => t.Id)
                     .IsRequired()
                     .ValueGeneratedOnAdd();
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .Property(t => t.SchoolId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>().HasIndex(t => t.SchoolId);
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .Property(t => t.TeacherId)
                     .IsRequired();
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>().HasIndex(t => t.TeacherId);
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .HasOne(x => x.School)
                     .WithOne(x => x.SchoolTeachers)
                     .HasForeignKey<global::AtApi.Model.At.TeacherSchool>("SchoolId");
         modelBuilder.Entity<global::AtApi.Model.At.TeacherSchool>()
                     .HasOne(x => x.Teacher)
                     .WithOne(x => x.TeacherSchools)
                     .HasForeignKey<global::AtApi.Model.At.TeacherSchool>("TeacherId");

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
