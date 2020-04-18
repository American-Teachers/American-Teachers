using AtApi.Adapter;
using AtApi.Model;
using AtApi.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AtApi.UnitTests
{

    public class ClassFactoryTests : TestsBase
    {
        private Mock<IAdapter<Class>> _classAdapter;
        public ClassFactoryTests()
        {
            _classAdapter = new Mock<IAdapter<Class>>(MockBehavior.Strict);
        }

        protected override void VerifyAll()
        {
            _classAdapter.VerifyAll();
        }

        private ClassFactory GetFactory()
        {
            return new ClassFactory(_classAdapter.Object);
        }

        private Class GetData()
        {
            return Class.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Random.Next(), null, Random.Next());
        }


        [Fact]
        public void Create_Success()
        {
            var model = GetData();

            _classAdapter.Setup(m => m.Create(It.IsAny<Class>())).Returns(model);
            var factory = GetFactory();
            var actual = factory.Create(model);

            Assert.NotNull(actual);
            VerifyAll();
        }

        [Fact]
        public void Update_Success()
        {
            var model = GetData();

            _classAdapter.Setup(m => m.Update(It.IsAny<Class>())).Returns(model);
            var factory = GetFactory();
            var actual = factory.Update(model);

            Assert.NotNull(actual);
            VerifyAll();
        }


        [Fact]
        public void Delete_Success()
        {
            var id = Random.Next();
            _classAdapter.Setup(m => m.Delete(It.Is<int>(s => s == id)));
            var factory = GetFactory();
            factory.Delete(id);

            VerifyAll();
        }


        [Fact]
        public void GetAll_Success()
        {
            var model = new List<Class> {
                GetData(),
                GetData()
            };

            _classAdapter.Setup(m => m.GetAll()).Returns(model);
            var factory = GetFactory();
            var actual = factory.GetAll();

            Assert.NotNull(actual);
            VerifyAll();
        }


        [Fact]
        public void GetOne_Success()
        {
            var id = Random.Next();
            var model = GetData();

            _classAdapter.Setup(m => m.GetOne(It.Is<int>(s => s == id))).Returns(model);
            var factory = GetFactory();
            var actual = factory.GetOne(id);

            Assert.NotNull(actual);
            VerifyAll();
        }

    }
}


