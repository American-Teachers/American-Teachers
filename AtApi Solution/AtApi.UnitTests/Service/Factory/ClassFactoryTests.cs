using AtApi.Framework;
using AtApi.Model.At;
using AtApi.Service.Adapter;
using AtApi.Service.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AtApi.UnitTests.Service
{

    public class ClassFactoryTests : TestsBase
    {
        private readonly Mock<IAdapter<Class>> _classAdapter;
        private readonly Mock<IContextAdapter<AtDbContext>> contextAdapter;
        public ClassFactoryTests()
        {
            _classAdapter = new Mock<IAdapter<Class>>(MockBehavior.Strict);
            contextAdapter = new Mock<IContextAdapter<AtDbContext>>(MockBehavior.Strict);
        }

        protected override void VerifyAll()
        {
            _classAdapter.VerifyAll();
            contextAdapter.VerifyAll();
        }

        private ClassFactory GetFactory()
        {
            return new ClassFactory(_classAdapter.Object, contextAdapter.Object);
        }

        private Class GetData()
        {
            var teacher = Teacher.Create($"{Guid.NewGuid().ToString("n")}@noboday.com", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            return Class.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Random.Next(), teacher, Random.Next());
        }


        [Fact]
        public async Task Create_SuccessAsync()
        {
            var model = GetData();

            _classAdapter.Setup(m => m.Create(It.IsAny<Class>())).Returns(model);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            var actual = await factory.CreateAsync(model).ConfigureAwait(false);

            Assert.NotNull(actual);
            VerifyAll();
        }

        [Fact]
        public async Task Update_SuccessAsync()
        {
            var model = GetData();
            var old = model.Serlialize().DeSerialize<Class>();
            old.Name = Guid.NewGuid().ToString();
            _classAdapter.Setup(m => m.GetOneAsync(It.Is<int>(s => s == old.Id))).ReturnsAsync(old);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            var actual =await factory.UpdateAsync(model);

            Assert.NotNull(actual);
            Assert.Equal(model.Name, actual.Name);
            VerifyAll();
        }


        [Fact]
        public async Task Delete_SuccessAsync()
        {
            var id = Random.Next();
            _classAdapter.Setup(m => m.DeleteAsync(It.Is<int>(s => s == id))).Returns(Task.CompletedTask);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            await factory.DeleteAsync(id).ConfigureAwait(false);

            VerifyAll();
        }


        [Fact]
        public async Task GetAll_SuccessAsync()
        {
            var model = new List<Class> {
                GetData(),
                GetData()
            };

            _classAdapter.Setup(m => m.GetAllAsync()).ReturnsAsync(model);
            var factory = GetFactory();
            var actual =await factory.GetAllAsync();

            Assert.NotNull(actual);
            VerifyAll();
        }


        [Fact]
        public async Task GetOne_SuccessAsync()
        {
            var id = Random.Next();
            var model = GetData();

            _classAdapter.Setup(m => m.GetOneAsync(It.Is<int>(s => s == id))).ReturnsAsync(model);
            var factory = GetFactory();
            var actual = await factory.GetOneAsync(id);

            Assert.NotNull(actual);
            VerifyAll();
        }

    }
}


