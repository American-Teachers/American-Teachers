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

namespace AtApi.Model
{
   /// <summary>
   /// Person
   /// </summary>
   public partial class Person
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Person()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Person CreatePersonUnsafe()
      {
         return new Person();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="emailaddress">Email Address</param>
      /// <param name="firstname">First Name</param>
      /// <param name="lastname">Last Name</param>
      public Person(string emailaddress, string firstname, string lastname)
      {
         if (string.IsNullOrEmpty(emailaddress)) throw new ArgumentNullException(nameof(emailaddress));
         this.EmailAddress = emailaddress;

         if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
         this.FirstName = firstname;

         if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
         this.LastName = lastname;


         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="emailaddress">Email Address</param>
      /// <param name="firstname">First Name</param>
      /// <param name="lastname">Last Name</param>
      public static Person Create(string emailaddress, string firstname, string lastname)
      {
         return new Person(emailaddress, firstname, lastname);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Required
      /// Id
      /// </summary>
      /// <remarks>
      /// Id
      /// </remarks>
      [Key]
      [Required]
      public int Id { get; protected set; }

      /// <summary>
      /// Required, Max length = 1000
      /// Email Address
      /// </summary>
      [Required]
      [MaxLength(1000)]
      [StringLength(1000)]
      public string EmailAddress { get; set; }

      /// <summary>
      /// Required
      /// First Name
      /// </summary>
      [Required]
      public string FirstName { get; set; }

      /// <summary>
      /// Required
      /// Last Name
      /// </summary>
      [Required]
      public string LastName { get; set; }

      /// <summary>
      /// Title
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      /// Suffix
      /// </summary>
      public string Suffix { get; set; }

      /// <summary>
      /// Max length = 1000
      /// Preferred Name
      /// </summary>
      [MaxLength(1000)]
      [StringLength(1000)]
      public string PreferredName { get; set; }

   }
}
