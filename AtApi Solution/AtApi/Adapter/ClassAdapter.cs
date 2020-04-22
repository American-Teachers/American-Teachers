using AtApi.Model;
using AtApi.Model.At;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Adapter
{
    public class ClassAdapter : AtBaseAdapter<Class>
    {

        public ClassAdapter(AtDbContext atDbContext) : base(atDbContext)
        {

        }
        
        public override async Task<Class> GetOneAsync(int id)
        {
            return await atDbContext.Classes.Where(_ => _.Id == id).SingleOrDefaultAsync();
        }

       
    }
}
