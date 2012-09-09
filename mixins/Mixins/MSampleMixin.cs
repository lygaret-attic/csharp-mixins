using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace mixins.Mixins
{
    /// <summary>
    /// This is the interface that the instances would need to implement to get
    /// the methods of the mixin, as well as a way for the mixin to require any
    /// methods on the instance itself.
    /// 
    /// A good example of using required methods is in 
    /// <see cref="mixins.Mixins.MComparable" />, which uses it to require the
    /// compare method, which then enables all the other mixed in methods.
    /// </summary>
    public interface MSampleMixin
    {
    }

    /// <summary>
    /// This is the static class that adds all the intstance extension methods,
    /// which become the "mixed in" methods.
    /// </summary>
    public static class SampleMixinImpl
    {

        #region Private Data

        // THIS is what makes this more than just a bunch of extension methods.
        // !!!
        // 
        // ConditionalWeakTable is a way to attach arbitrary data to a particular 
        // instance. It is not simply a dictionary mapping values to instances as keys, 
        // but rather has special run time support to attach directly to instances.
        //
        // This has some interesting ramifications, mainly around object lifetime and 
        // how keys are mapped at runtime: each key must be unique, GetHashCode doesn't 
        // cut it. See the doc for that class for more info.
        //
        // _PData is the class used by the extension methods below to attach data to a 
        // _particular_ instance in the ConditionalWeakTable. This lets us add setters 
        // and methods which store data for a particular instance. 

        /// <summary>
        /// Mixin Private Data Fields
        /// </summary>
        sealed class _PData
        {
            public string Foo;
        }

        private static ConditionalWeakTable<MSampleMixin, _PData> _pdata =
            new ConditionalWeakTable<MSampleMixin, _PData>();

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        private static _PData GetPrivateData(MSampleMixin instance)
        {
            // This is a helper method that retrieves the _PData for a particular
            // instance, or creates it. This is where you'd write your own code for 
            // the setup of the mixin data.

            return _pdata.GetValue(instance, (i) => new _PData { Foo = "Default" });
        }

        #endregion

        // These extension methods can use the GetOrCreateData() to get a set of values

        public static string GetFoo(this MSampleMixin instance)
        {
            return GetPrivateData(instance).Foo;
        }

        public static void SetFoo(this MSampleMixin instance, string value)
        {
            GetPrivateData(instance).Foo = value;
        }
    }
}
