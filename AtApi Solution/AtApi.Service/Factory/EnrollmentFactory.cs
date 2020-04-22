using AtApi.Framework;
using AtApi.Model.At;
using AtApi.Service.Adapter;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    public class EnrollmentFactory : BaseFactory<Enrollment, AtDbContext>
    {
        public EnrollmentFactory(IAdapter<Enrollment> adapter, IContextAdapter<AtDbContext> contextAdapter) : base(adapter, contextAdapter)
        {

        }

        public override async Task<Enrollment> UpdateAsync(Enrollment model, bool saveChanges = true)
        {
            var old = await adapter.GetOneAsync(model.Id);
            old.ClassId = model.ClassId;
            old.StudentId = model.StudentId;
            return await base.UpdateAsync(old, saveChanges);

        }
    }
}
