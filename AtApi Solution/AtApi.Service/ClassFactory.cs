using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class ClassFactory : BaseFactory<ClassModel, IBaseAdapter<ClassModel>>
    {
        public ClassFactory(IBaseAdapter<ClassModel> adapter) : base(adapter)
        {

        }
    }
}
