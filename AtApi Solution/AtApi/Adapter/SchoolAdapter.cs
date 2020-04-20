using AtApi.Model;
using AtApi.Model.At;
using System.Collections.Generic;
using System.Linq;

namespace AtApi.Adapter
{
    public class SchoolAdapter : IAdapter<School>
    {
        private readonly AtDbContext atDbContext;

        public SchoolAdapter(AtDbContext atDbContext)
        {
            this.atDbContext = atDbContext;
        }
        public School Create(School model)
        {
            var e = atDbContext.Schools.Add(model);
            atDbContext.SaveChanges();
            return e.Entity;
        }

        public void Delete(int id)
        {
            var model = atDbContext.Schools.Where(_ => _.Id == id).FirstOrDefault();
            atDbContext.Schools.Remove(model);
            atDbContext.SaveChanges();
        }

        public List<School> GetAll()
        {
            return atDbContext.Schools.ToList();
        }

        public School GetOne(int id)
        {
            return atDbContext.Schools.Where(_ => _.Id == id).SingleOrDefault();
        }

        public School Update(School model)
        {
            var old = GetOne(model.Id);
            old.Name = model.Name;            
            atDbContext.SaveChanges();
            return old;
        }
    }
}
