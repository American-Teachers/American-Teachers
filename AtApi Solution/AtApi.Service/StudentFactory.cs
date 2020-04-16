using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class StudentFactory : BaseFactory<Student, IBaseAdapter<Student>>
    {
        public StudentFactory(IBaseAdapter<Student> adapter) : base(adapter)
        {

        }
    }
}
