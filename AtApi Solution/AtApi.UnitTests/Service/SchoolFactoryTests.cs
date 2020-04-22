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
    public class SchoolFactoryTests : TestsBase
    {

        private readonly Mock<IAdapter<School>> adapter;
        private readonly Mock<IContextAdapter<AtDbContext>> contextAdapter;
        public SchoolFactoryTests()
        {
            adapter = new Mock<IAdapter<School>>(MockBehavior.Strict);
            contextAdapter = new Mock<IContextAdapter<AtDbContext>>(MockBehavior.Strict);
        }

        protected override void VerifyAll()
        {
            adapter.VerifyAll();
            contextAdapter.VerifyAll();
        }

        private SchoolFactory GetFactory()
        {
            return new SchoolFactory(adapter.Object, contextAdapter.Object);
        }

        private School GetData()
        {
            return School.Create($"{Guid.NewGuid():n}");
        }


        [Fact]
        public async Task Create_SuccessAsync()
        {
            var model = GetData();

            adapter.Setup(m => m.Create(It.IsAny<School>())).Returns(model);
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
            var old = model.Serlialize().DeSerialize<School>();
            old.Name = Guid.NewGuid().ToString();
            adapter.Setup(m => m.GetOneAsync(It.Is<int>(s => s == old.Id))).ReturnsAsync(old);
            contextAdapter.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
            var factory = GetFactory();
            var actual = await factory.UpdateAsync(model);

            Assert.NotNull(actual);
            Assert.Equal(model.Name, actual.Name);
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
            var model = new List<School> {
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
