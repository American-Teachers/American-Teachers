using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AtApi.Adapter
{
    public class StudentAdapter : IAdapter<Student>
    {
        private readonly AtDbContext atDbContext;

        public StudentAdapter(AtDbContext atDbContext)
        {
            this.atDbContext = atDbContext;
        }
        public Student Create(Student model)
        {
            var e = atDbContext.Students.Add(model);
            atDbContext.SaveChanges();
            return e.Entity;
        }

        public void Delete(int id)
        {
            var model = atDbContext.Teachers.Where(_ => _.Id == id).SingleOrDefault();
            atDbContext.Teachers.Remove(model);
            atDbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return atDbContext.Students.ToList();
        }

        public Student GetOne(int id)
        {
            return atDbContext.Students.Where(_ => _.Id == id).SingleOrDefault();
        }

        public Student Update(Student model)
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
