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
   /// Parent
   /// </summary>
   public partial class Parent: global::AtApi.Model.Person
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Parent(): base()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Parent CreateParentUnsafe()
      {
         return new Parent();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="emailaddress">Email Address</param>
      /// <param name="firstname">First Name</param>
      /// <param name="lastname">Last Name</param>
      public Parent(string emailaddress, string firstname, string lastname)
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
      public static new Parent Create(string emailaddress, string firstname, string lastname)
      {
         return new Parent(emailaddress, firstname, lastname);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      public string ParentProp1 { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      public virtual global::AtApi.Model.At.ParentStudent Students { get; set; }

   }
}

