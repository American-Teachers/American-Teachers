using System;

namespace AtApi.UnitTests
{
    public abstract class TestsBase
    {
        protected Random Random = new Random(DateTime.Now.Millisecond);
        public virtual void VerifyAll()
        {
        }
    }
}
