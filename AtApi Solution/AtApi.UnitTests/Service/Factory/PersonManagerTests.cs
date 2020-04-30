using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AtApi.UnitTests.Service.Factory
{
    public class PersonManagerTests : TestsBase
    {

        private readonly Mock<IFactory<Teacher>> teacherFactory;
        private readonly Mock<IFactory<Student>> studentFactory;
        private readonly Mock<IFactory<Parent>> parentFactory;

        public PersonManagerTests()
        {
            teacherFactory = new Mock<IFactory<Teacher>>(MockBehavior.Strict);
            studentFactory = new Mock<IFactory<Student>>(MockBehavior.Strict);
            parentFactory = new Mock<IFactory<Parent>>(MockBehavior.Strict);
        }

        private PersonManager GetPersonManager()
        {
            return new PersonManager(teacherFactory.Object, studentFactory.Object, parentFactory.Object);
        }

        protected override void VerifyAll()
        {
            base.VerifyAll();
            teacherFactory.VerifyAll();
            studentFactory.VerifyAll();
            parentFactory.VerifyAll();
        }

        [Fact]
        public async Task CreateAsync_Teacher()
        {
            var personRequest = new PersonRequest
            {
                AspUserId = Guid.NewGuid().ToString(),
                EmailAddress = "email@noemail.com" + Guid.NewGuid().ToString(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                PreferredName = Guid.NewGuid().ToString(),
                Role = "Teacher"
            };
            var teacher = Teacher.CreateTeacherUnsafe();
            teacher.AspUserId = personRequest.AspUserId;
            teacher.FirstName = personRequest.FirstName;
            teacher.LastName = personRequest.LastName;
            teacher.PreferredName = personRequest.PreferredName;            
            teacherFactory.Setup(m => m.CreateAsync(It.Is<Teacher>(s => s.AspUserId == personRequest.AspUserId), true)).ReturnsAsync(teacher);
            var manager = GetPersonManager();
            var actual = await manager.CreateAsync(personRequest);

            Assert.NotNull(actual);
        
            VerifyAll();
        }

        [Fact]
        public async Task CreateAsync_Student()
        {
            var personRequest = new PersonRequest
            {
                AspUserId = Guid.NewGuid().ToString(),
                EmailAddress = "email@noemail.com" + Guid.NewGuid().ToString(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                PreferredName = Guid.NewGuid().ToString(),
                Role = "Student"
            };
            var student = Student.CreateStudentUnsafe();
            student.AspUserId = personRequest.AspUserId;
            student.FirstName = personRequest.FirstName;
            student.LastName = personRequest.LastName;
            student.PreferredName = personRequest.PreferredName;

            studentFactory.Setup(m => m.CreateAsync(It.Is<Student>(s => s.AspUserId == personRequest.AspUserId), true)).ReturnsAsync(student);
            var manager = GetPersonManager();
            var actual = await manager.CreateAsync(personRequest);

            Assert.NotNull(actual);

            VerifyAll();
        }



        [Fact]
        public async Task CreateAsync_Parent()
        {
            var personRequest = new PersonRequest
            {
                AspUserId = Guid.NewGuid().ToString(),
                EmailAddress = "email@noemail.com" + Guid.NewGuid().ToString(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                PreferredName = Guid.NewGuid().ToString(),
                Role = "Parent"
            };
            var parent = Parent.CreateParentUnsafe();
            parent.AspUserId = personRequest.AspUserId;
            parent.FirstName = personRequest.FirstName;
            parent.LastName = personRequest.LastName;
            parent.PreferredName = personRequest.PreferredName;

            parentFactory.Setup(m => m.CreateAsync(It.Is<Parent>(s => s.AspUserId == personRequest.AspUserId), true)).ReturnsAsync(parent);
            var manager = GetPersonManager();
            var actual = await manager.CreateAsync(personRequest);

            Assert.NotNull(actual);

            VerifyAll();
        }


        [Fact]
        public async Task CreateAsync_Unknown_Fail()
        {
            var personRequest = new PersonRequest
            {
                AspUserId = Guid.NewGuid().ToString(),
                EmailAddress = "email@noemail.com" + Guid.NewGuid().ToString(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                PreferredName = Guid.NewGuid().ToString(),
                Role = Guid.NewGuid().ToString()
            };
           
 
            var manager = GetPersonManager();
            var exception =await Assert.ThrowsAsync<NotImplementedException>( ()=> manager.CreateAsync(personRequest));

            Assert.Equal(exception.Message, personRequest.Role);

            VerifyAll();
        }
    }
}
