namespace IEnumerableSamples
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Test_HashSetItemsAreUnique();
        }

        private static void Test_HashSetItemsAreUnique()
        {
            var stringList = new List<string>();
            stringList.Add("a");
            stringList.Add("a");
            stringList.Add("a");
            stringList.Add("b");
            stringList.Add("b");
            stringList.Add("b");
            stringList.Add("c");
            stringList.Add("c");
            stringList.Add("c");

            Console.WriteLine(string.Join(", ", stringList));

            var hashSet = new HashSet<string>(stringList);
            Console.WriteLine(string.Join(", ", hashSet));
        }
    }
}
