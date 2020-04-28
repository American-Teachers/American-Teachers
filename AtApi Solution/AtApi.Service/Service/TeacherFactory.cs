using AtApi.Service.Adapter;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Model.At;
using System.Threading.Tasks;

namespace AtApi.Service
{
    public class TeacherFactory : BaseFactory<Teacher, AtDbContext>
    {
        public TeacherFactory(IAdapter<Teacher> adapter, IContextAdapter<AtDbContext> contextAdapter) : base(adapter, contextAdapter)
        {

        }

        public override async Task<Teacher> UpdateAsync(Teacher model, bool saveChanges = true)
        {
            var old = await adapter.GetOneAsync(model.Id);
            old.AspUserId = model.AspUserId;           
            old.FirstName = model.FirstName;
            old.LastName = model.LastName;
            old.EmailAddress = model.EmailAddress;
            old.PreferredName = model.PreferredName;
            old.Suffix = model.Suffix;
            old.Title = model.Title;
            return await base.UpdateAsync(old, saveChanges);

        }
    }
}
