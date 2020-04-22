using AtApi.Model.At;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace AtApi.Adapter
{
    public class EnrollmentAdapter : AtBaseAdapter<Enrollment>
    {
        public EnrollmentAdapter(AtDbContext atDbContext) : base(atDbContext)
        {

        }

        public override async Task<Enrollment> GetOneAsync(int id)
        {
            return await atDbContext.Enrollment
                .Where(_ => _.Id == id)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
