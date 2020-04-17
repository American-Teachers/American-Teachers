using AtApi.Model;
using AtApi.Model.At;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
namespace AtApi.Adapter
{
    public class ClassAdapter : IBaseAdapter<Class>
    {
        private readonly ILogger<ClassAdapter> logger;
        private readonly AtDbContext atDbContext;

        public ClassAdapter(ILogger<ClassAdapter> logger, AtDbContext atDbContext)
        {
            this.logger = logger;
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
            old.SubjectId = model.SubjectId;
            old.TeacherId = model.TeacherId;            
            atDbContext.SaveChanges();
            return old;
        }
    }
}
