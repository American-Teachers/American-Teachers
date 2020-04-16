using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class ClassFactory : BaseFactory<Class, IBaseAdapter<Class>>
    {
        public ClassFactory(IBaseAdapter<Class> adapter) : base(adapter)
        {

        }
    }
}
