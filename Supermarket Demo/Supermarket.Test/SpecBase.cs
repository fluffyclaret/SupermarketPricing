using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Supermarket.Test.Core
{
    [TestFixture]
    public abstract class SpecBase
    {
        [SetUp]
        public void Initialize()
        {
            Given();
            When();
        }

        [TearDown]
        public virtual void TearDown() { }

        protected virtual void Given() { }

        protected abstract void When();
    }
}
