using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AtApi.Service.Adapter
{
    public class TeacherAdapter : AtBaseAdapter<Teacher>
    {


        public TeacherAdapter(AtDbContext atDbContext) : base(atDbContext)
        {
        }
        public Teacher GetOne(int id)
        {
            return atDbContext.Teachers.Where(_ => _.Id == id).SingleOrDefault();
        }

        //public Teacher Update(Teacher model)
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
