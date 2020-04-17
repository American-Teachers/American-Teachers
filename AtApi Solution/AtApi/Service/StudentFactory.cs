using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class StudentFactory : BaseFactory<Student, IAdapter<Student>>
    {
        public StudentFactory(IAdapter<Student> adapter) : base(adapter)
        {

        }
    }
}
