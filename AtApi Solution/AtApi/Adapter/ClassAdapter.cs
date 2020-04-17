using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
namespace AtApi.Adapter
{
    public class ClassAdapter : IAdapter<Class>
    {
        private readonly AtDbContext atDbContext;

        public ClassAdapter(AtDbContext atDbContext)
        {
            this.atDbContext = atDbContext;
        }
        public Class Create(Class model)
        {
            var e = atDbContext.Classes.Add(model);
            atDbContext.SaveChanges();
            return e.Entity;
        }

        public void Delete(int id)
        {
            var model = atDbContext.Classes.Where(_ => _.Id == id).SingleOrDefault();
            atDbContext.Classes.Remove(model);
            atDbContext.SaveChanges();
        }

        public List<Class> GetAll()
        {
            return atDbContext.Classes.ToList();
        }

        public Class GetOne(int id)
        {
            return atDbContext.Classes.Where(_=>_.Id == id).SingleOrDefault();
        }

        public Class Update(Class model)
        {
            var old = GetOne(model.Id);
            old.Name = model.Name;
            old.Subject = model.Subject;
            old.TeacherId = model.TeacherId;            
            atDbContext.SaveChanges();
            return old;
        }
    }
}
