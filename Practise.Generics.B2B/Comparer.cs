using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Practise.Generics.B2B
{
    public static class Comparer
    {

        public static List<Tuple<string, T, T>> Differences<T>(T current, T original)
        {

            var differences = new List<Tuple<string, T, T>>();

            var areEqualMethod = typeof(Comparer)
                             .GetMethod(nameof(AreEqual), BindingFlags.NonPublic | BindingFlags.Static);

            typeof(T).GetProperties()
                     .ToList()
                     .ForEach(property => // : PropertyInfo
                     {
                         object x = property.GetValue(current);
                         object y = property.GetValue(original);
                         Type propertyType = property.PropertyType;

                         MethodInfo areEqual = areEqualMethod.MakeGenericMethod(propertyType); // : MethodInfo

                         bool equal = (bool)areEqual.Invoke(obj: null,
                                             parameters: new[] { x, y });

                         if (!equal)
                             differences.Add(Tuple.Create(property.Name, current, original));
                     });

            return differences;
        }


        private static bool AreEqual<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }

}
