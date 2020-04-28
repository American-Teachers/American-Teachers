using AtApi.Service.Adapter;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Model.At;
using System.Threading.Tasks;

namespace AtApi.Service
{
    public class ClassFactory : BaseFactory<Class,  AtDbContext>
    {

        public ClassFactory(IAdapter<Class> adapter, IContextAdapter<AtDbContext> contextAdapter) : base(adapter, contextAdapter)
        {


        }
        public override async Task<Class> UpdateAsync(Class model, bool saveChanges = true)
        {
            var old = await adapter.GetOneAsync(model.Id);
            old.Name = model.Name;
            old.Subject = model.Subject;
            old.Description = model.Description;
            old.Subject = model.Subject;
            old.TeacherId = model.TeacherId;
            old.ScheduleId = model.ScheduleId;
            old.EstimatedNumberOfStudents = model.EstimatedNumberOfStudents;            
            return await base.UpdateAsync(old, saveChanges);
        }
    }

}
