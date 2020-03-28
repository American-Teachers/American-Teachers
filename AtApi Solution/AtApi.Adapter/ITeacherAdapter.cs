using AtApi.Model;
using System.Collections.Generic;

namespace AtApi.Adapter
{
    public interface ITeacherAdapter
    {

        TeacherModel GetOne(int id);
        TeacherModel Create(TeacherModel teacherModel);
        TeacherModel Update(TeacherModel teacherModel);
        void Delete(int id);
        List<TeacherModel> GetAll();
    }
}
