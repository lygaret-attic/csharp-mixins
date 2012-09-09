using mixins.Mixins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace mixin.test
{
    [TestClass()]
    public class MOrderableTest
    {
        // example of including a simple mixin
        // notice that we don't define a field to store Foo
        public class TestSample : MOrderable<TestSample>
        {
            private string Value;

            public TestSample(string value)
            {
                Value = value;
            }

            int MOrderable<TestSample>.Compare(TestSample other) 
            {
                return Value.Length.CompareTo(other.Value.Length);    
            }
        }

        [TestMethod()]
        public void OrderedTest()
        {
            var s1 = new TestSample("one");
            var s2 = new TestSample("two");
            var s3 = new TestSample("three");

            Assert.IsTrue(s1.EqualTo(s2));
            Assert.IsTrue(s1.NotEqualTo(s3));
            Assert.IsTrue(s1.LessThan(s3));
            Assert.IsTrue(s3.GreaterThan(s2));
        }
    }
}
