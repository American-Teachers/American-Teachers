using AtApi.Adapter;
using AtApi.Model;

namespace AtApi.Service
{
    public class StudentFactory : BaseFactory<StudentModel, IBaseAdapter<StudentModel>>
    {
        public StudentFactory(IBaseAdapter<StudentModel> adapter) : base(adapter)
        {

        }
    }
}
