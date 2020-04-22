using AtApi.Model.At;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Service.Adapter
{
    public class ParentAdapter : AtBaseAdapter<Parent>
    {
        public ParentAdapter(AtDbContext atDbContext) : base(atDbContext)
        {

        }

        public override async Task<Parent> GetOneAsync(int id)
        {
            return await atDbContext.Parents
                .Where(_ => _.Id == id)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
