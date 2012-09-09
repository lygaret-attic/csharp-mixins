# Mixins with .NET 4.5 and C#

This is a couple of samples of mixins in .NET4.5 and C#, thanks to the [ConditionalWeakTable](http://msdn.microsoft.com/en-us/library/dd287757.aspx)
class in 4.5. This was inspired by a blog post at [CSharpCorner](http://www.c-sharpcorner.com/uploadfile/b942f9/how-to-create-mixin-using-C-Sharp-4-0/)

## How does it work?

Basically, it's just extension methods with a special ConditionalWeakTable that attaches private data to 
instances. This means that instead of having to have the class you want to attach methods to implement
data fields for your extension methods, you can attach data to the instance as part of the extension method,
thereby getting much more useful "mixins" rather than simply extension methods.

## Show me?

```c#
[TestClass()]
public class MSampleMixinTest
{
	public class SuperClass
	{
	}

    // example of including a simple mixin
	// notice two things -
	//    the MSampleMixin is not the super class, rather it's an interface
	//    there are no fields or properties defined to store the Foo data for the mixin methods
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
```