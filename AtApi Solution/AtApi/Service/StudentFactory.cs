using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class StudentFactory : BaseFactory<Student, StudentAdapter>
    {
        public StudentFactory(StudentAdapter adapter) : base(adapter)
        {

        }
    }
}
