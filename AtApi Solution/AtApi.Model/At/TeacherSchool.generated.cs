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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AtApi.Model.At
{
   public partial class TeacherSchool
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected TeacherSchool()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static TeacherSchool CreateTeacherSchoolUnsafe()
      {
         return new TeacherSchool();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="schoolid">Foreign key for School.SchoolTeachers &lt;--&gt; TeacherSchool.School. </param>
      /// <param name="teacherid">Foreign key for Teacher.TeacherSchools &lt;--&gt; TeacherSchool.Teacher. </param>
      /// <param name="school"></param>
      /// <param name="teacher"></param>
      public TeacherSchool(int schoolid, int teacherid, global::AtApi.Model.School school, global::AtApi.Model.Teacher teacher)
      {
         this.SchoolId = schoolid;

         this.TeacherId = teacherid;

         if (school == null) throw new ArgumentNullException(nameof(school));
         this.School = school;

         if (teacher == null) throw new ArgumentNullException(nameof(teacher));
         this.Teacher = teacher;


         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="schoolid">Foreign key for School.SchoolTeachers &lt;--&gt; TeacherSchool.School. </param>
      /// <param name="teacherid">Foreign key for Teacher.TeacherSchools &lt;--&gt; TeacherSchool.Teacher. </param>
      /// <param name="school"></param>
      /// <param name="teacher"></param>
      public static TeacherSchool Create(int schoolid, int teacherid, global::AtApi.Model.School school, global::AtApi.Model.Teacher teacher)
      {
         return new TeacherSchool(schoolid, teacherid, school, teacher);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public int Id { get; protected set; }

      /// <summary>
      /// Indexed, Required
      /// Foreign key for School.SchoolTeachers &lt;--&gt; TeacherSchool.School. 
      /// </summary>
      [Required]
      public int SchoolId { get; set; }

      /// <summary>
      /// Indexed, Required
      /// Foreign key for Teacher.TeacherSchools &lt;--&gt; TeacherSchool.Teacher. 
      /// </summary>
      [Required]
      public int TeacherId { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::AtApi.Model.School School { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::AtApi.Model.Teacher Teacher { get; set; }

   }
}
