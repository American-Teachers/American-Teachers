using AtApi.Framework;
using AtApi.Model.At;
using AtApi.Service.Adapter;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    public class SchoolFactory : BaseFactory<School,  AtDbContext>
    {
        public SchoolFactory(IAdapter<School> adapter, IContextAdapter<AtDbContext> contextAdapter) : base(adapter, contextAdapter)
        {

        }

        public override async Task<School> UpdateAsync(School model, bool saveChanges = true)
        {
            var old = await adapter.GetOneAsync(model.Id);
            old.Name = model.Name;
            return await base.UpdateAsync(old, saveChanges);

        }
    }
}
