using System;

namespace Practise.Generics.B2B
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User() { Age = 22, Name = "Steve", Id = "43" };
            var user2 = new User() { Age = 14, Name = "Steve", Id = "1" };

            var differences = Comparer.Differences(user1, user2);
            foreach (var tuple in differences)
            {
                Console.WriteLine(tuple.Item1);
                Console.WriteLine(tuple.Item2);
                Console.WriteLine(tuple.Item3);
                Console.WriteLine("- - - - - - -");
            }

            Console.Read();
        }
    }

}
