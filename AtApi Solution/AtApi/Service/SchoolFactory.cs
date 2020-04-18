using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class SchoolFactory : BaseFactory<School, IAdapter<School>>
    {
        public SchoolFactory(IAdapter<School> adapter) : base(adapter)
        {

        }
    }
}
