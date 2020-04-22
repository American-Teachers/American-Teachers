using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AtApi.Adapter
{
    public class StudentAdapter : AtBaseAdapter<Student>
    {
         
        public StudentAdapter(AtDbContext atDbContext) : base(atDbContext)
        {
         
        }
        public Student GetOne(int id)
        {
            return atDbContext.Students.Where(_ => _.Id == id).SingleOrDefault();
        }

        //public Student Update(Student model)
        //{
        //    var old = GetOne(model.Id);
        //    old.EmailAddress = model.EmailAddress;
        //    old.FirstName = model.FirstName;
        //    old.LastName = model.LastName;
        //    old.PreferredName = model.PreferredName;
        //    old.Suffix = model.Suffix;
        //    old.Title = model.Title;
        //    atDbContext.SaveChanges();
        //    return old;
        //}
    }
}
