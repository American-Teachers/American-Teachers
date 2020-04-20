using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AtApi.Adapter
{
    public class TeacherAdapter : IAdapter<Teacher>
    {
        private readonly AtDbContext atDbContext;

        public TeacherAdapter(AtDbContext atDbContext)
        {
            this.atDbContext = atDbContext;
        }
        public Teacher Create(Teacher model)
        {
            var e = atDbContext.Teachers.Add(model);
            atDbContext.SaveChanges();
            return e.Entity;
        }

        public void Delete(int id)
        {
            var model = atDbContext.Teachers.Where(_ => _.Id == id).FirstOrDefault();
            atDbContext.Teachers.Remove(model);
            atDbContext.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return atDbContext.Teachers.ToList();
        }

        public Teacher GetOne(int id)
        {
            return atDbContext.Teachers.Where(_ => _.Id == id).SingleOrDefault();
        }

        public Teacher Update(Teacher model)
        {
            var old = GetOne(model.Id);
            old.EmailAddress = model.EmailAddress;
            old.FirstName = model.FirstName;
            old.LastName = model.LastName;
            old.PreferredName = model.PreferredName;
            old.Suffix = model.Suffix;
            old.Title = model.Title;
            atDbContext.SaveChanges();
            return old;
        }
    }
}
