using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class TeacherFactory : BaseFactory<TeacherModel, IBaseAdapter<TeacherModel>>
    {
        public TeacherFactory(IBaseAdapter<TeacherModel> adapter) : base(adapter)
        {

        }
    }
}
