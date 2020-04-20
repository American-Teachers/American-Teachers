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
   /// <remarks>
   /// ParentStudents
   /// </remarks>
   public partial class ParentStudent
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected ParentStudent()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static ParentStudent CreateParentStudentUnsafe()
      {
         return new ParentStudent();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="parentid">Foreign key for Parent.Students &lt;--&gt; ParentStudent.Parent. </param>
      /// <param name="studentid">Foreign key for Student.ParentStudents &lt;--&gt; ParentStudent.Student. </param>
      /// <param name="parent"></param>
      /// <param name="student"></param>
      public ParentStudent(int parentid, int studentid, global::AtApi.Model.Parent parent, global::AtApi.Model.Student student)
      {
         this.ParentId = parentid;

         this.StudentId = studentid;

         if (parent == null) throw new ArgumentNullException(nameof(parent));
         this.Parent = parent;

         if (student == null) throw new ArgumentNullException(nameof(student));
         this.Student = student;


         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="parentid">Foreign key for Parent.Students &lt;--&gt; ParentStudent.Parent. </param>
      /// <param name="studentid">Foreign key for Student.ParentStudents &lt;--&gt; ParentStudent.Student. </param>
      /// <param name="parent"></param>
      /// <param name="student"></param>
      public static ParentStudent Create(int parentid, int studentid, global::AtApi.Model.Parent parent, global::AtApi.Model.Student student)
      {
         return new ParentStudent(parentid, studentid, parent, student);
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
      /// Foreign key for Parent.Students &lt;--&gt; ParentStudent.Parent. 
      /// </summary>
      [Required]
      public int ParentId { get; set; }

      /// <summary>
      /// Indexed, Required
      /// Foreign key for Student.ParentStudents &lt;--&gt; ParentStudent.Student. 
      /// </summary>
      [Required]
      public int StudentId { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::AtApi.Model.Parent Parent { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::AtApi.Model.Student Student { get; set; }

   }
}

