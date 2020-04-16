using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class TeacherFactory : BaseFactory<Teacher, IBaseAdapter<Teacher>>
    {
        public TeacherFactory(IBaseAdapter<Teacher> adapter) : base(adapter)
        {

        }
    }
}
