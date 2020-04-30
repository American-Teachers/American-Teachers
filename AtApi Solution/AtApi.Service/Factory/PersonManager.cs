using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service.Framework;
using System;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    public class PersonManager : IPersonManager
    {
        private readonly IFactory<Teacher> teacherFactory;
        private readonly IFactory<Student> studentFactory;
        private readonly IFactory<Parent> parentFactory;

        public PersonManager(IFactory<Teacher> teacherFactory, IFactory<Student> studentFactory, IFactory<Parent> parentFactory)
        {
            this.teacherFactory = teacherFactory;
            this.studentFactory = studentFactory;
            this.parentFactory = parentFactory;
        }
        public async Task<PersonResponse> CreateAsync(PersonRequest personRequest)
        {
            Guard.IsNotNull(() => personRequest);

            var personResponse = new PersonResponse();
            Guard.IsNotNullOrEmpty(() => personRequest.AspUserId);
            Person person;
            switch (personRequest.Role)
            {
                case "Teacher":
                    var teacher = Teacher.Create(personRequest.EmailAddress, personRequest.FirstName, personRequest.LastName);
                    teacher.PreferredName = personRequest.PreferredName;
                    teacher.AspUserId = personRequest.AspUserId;
                    person = await teacherFactory.CreateAsync(teacher);
                    break;
                case "Student":
                    var student = Student.Create(personRequest.EmailAddress, personRequest.FirstName, personRequest.LastName);
                    student.PreferredName = personRequest.PreferredName;
                    student.AspUserId = personRequest.AspUserId;
                    person = await studentFactory.CreateAsync(student);
                    break;
                case "Parent":
                    var parent = Parent.Create(personRequest.EmailAddress, personRequest.FirstName, personRequest.LastName);
                    parent.PreferredName = personRequest.PreferredName;
                    parent.AspUserId = personRequest.AspUserId;
                    person = await parentFactory.CreateAsync(parent);
                    break;
                default:
                    throw new NotImplementedException(personRequest.Role);
            }
            personResponse.PersonId = person.Id;
            return personResponse;
        }
    }
}
