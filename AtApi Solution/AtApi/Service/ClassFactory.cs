using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class ClassFactory : BaseFactory<Class, ClassAdapter>
    {
        public ClassFactory(ClassAdapter adapter) : base(adapter)
        {

        }
    }
}
