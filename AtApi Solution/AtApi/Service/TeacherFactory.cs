using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class TeacherFactory : BaseFactory<Teacher, IAdapter<Teacher>>
    {
        public TeacherFactory(IAdapter<Teacher> adapter) : base(adapter)
        {

        }
    }
}
