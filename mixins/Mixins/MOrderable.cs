using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace mixins.Mixins
{
    public interface MOrderable<T>
    {
        int Compare(T other);
    }

    public static class OrderableImpl
    {
        public static bool EqualTo<T>(this MOrderable<T> instance, T other)
        {
            return instance.Compare(other) == 0;
        }

        public static bool NotEqualTo<T>(this MOrderable<T> instance, T other)
        {
            return instance.Compare(other) != 0;
        }

        public static bool LessThan<T>(this MOrderable<T> instance, T other)
        {
            return instance.Compare(other) < 0;
        }

        public static bool GreaterThan<T>(this MOrderable<T> instance, T other)
        {
            return instance.Compare(other) > 0;
        }
    }
}
