using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class ClassFactory : BaseFactory<Class, IAdapter<Class>>
    {
       
        public ClassFactory(IAdapter<Class> adapter) : base(adapter)
        {

        }
    }
}
