using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class TeacherFactory : BaseFactory<Teacher, TeacherAdapter>
    {
        public TeacherFactory(TeacherAdapter adapter) : base(adapter)
        {

        }
    }
}
