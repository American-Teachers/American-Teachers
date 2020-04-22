using AtApi.Adapter;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AtApi.UnitTests.Service     
{
    public class ParentFactoryTests : TestsBase
    {

        private readonly Mock<IAdapter<Parent>> adapter;
        private readonly Mock<IContextAdapter<AtDbContext>> contextAdapter;
        public ParentFactoryTests()
        {
            adapter = new Mock<IAdapter<Parent>>(MockBehavior.Strict);
            contextAdapter = new Mock<IContextAdapter<AtDbContext>>(MockBehavior.Strict);
        }

        protected override void VerifyAll()
        {
            adapter.VerifyAll();
            contextAdapter.VerifyAll();
        }

        private ParentFactory GetFactory()
        {
            return new ParentFactory(adapter.Object, contextAdapter.Object);
        }

        private Parent GetData()
        {
            return Parent.Create($"{Guid.NewGuid().ToString("n")}@noboday.com", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());            
        }


        [Fact]
        public async Task Create_SuccessAsync()
        {
            var model = GetData();

            adapter.Setup(m => m.Create(It.IsAny<Parent>())).Returns(model);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            var actual = await factory.CreateAsync(model);

            Assert.NotNull(actual);
            VerifyAll();
        }

        [Fact]
        public async Task Update_SuccessAsync()
        {
            var model = GetData();
            model.FirstName = "Model";
            var old = model.Serlialize().DeSerialize<Parent>();
            old.FirstName = "Old" + Guid.NewGuid().ToString();
            adapter.Setup(m => m.GetOneAsync(It.Is<int>(s => s == model.Id))).ReturnsAsync(old);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            var actual = await factory.UpdateAsync(model);

            Assert.NotNull(actual);
            Assert.Equal(model.FirstName, actual.FirstName);
            VerifyAll();
        }


        [Fact]
        public async Task Delete_SuccessAsync()
        {
            var id = Random.Next();
            adapter.Setup(m => m.DeleteAsync(It.Is<int>(s => s == id))).Returns(Task.CompletedTask);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            await factory.DeleteAsync(id);

            VerifyAll();
        }


        [Fact]
        public async Task GetAll_SuccessAsync()
        {
            var model = new List<Parent> {
                GetData(),
                GetData()
            };

            adapter.Setup(m => m.GetAllAsync()).ReturnsAsync(model);
            var factory = GetFactory();
            var actual = await factory.GetAllAsync();

            Assert.NotNull(actual);
            VerifyAll();
        }


        [Fact]
        public async Task GetOne_SuccessAsync()
        {
            var id = Random.Next();
            var model = GetData();

            adapter.Setup(m => m.GetOneAsync(It.Is<int>(s => s == id))).ReturnsAsync(model);
            var factory = GetFactory();
            var actual = await factory.GetOneAsync(id);

            Assert.NotNull(actual);
            VerifyAll();
        }

    }
}
