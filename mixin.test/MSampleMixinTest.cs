using mixins.Mixins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mixin.test
{
    [TestClass()]
    public class MSampleMixinTest
    {
        public class SuperClass
        {
        }

        // example of including a simple mixin
        // notice that we don't define a field to store Foo
        public class TestSample : SuperClass, MSampleMixin
        {
        }

        [TestMethod()]
        public void FooTest()
        {
            var s1 = new TestSample();
            var s2 = new TestSample();

            s1.SetFoo("sample 1");
            s2.SetFoo("sample 2");

            Assert.AreEqual("sample 1", s1.GetFoo());
            Assert.AreEqual("sample 2", s2.GetFoo());
        }
    }
}
