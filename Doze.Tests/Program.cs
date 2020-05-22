using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Doze.Tests
{
    class Program
    {
        private static List<IDozeTest> Tests { get; set; }
        static void Main(string[] args)
        {
            CollectTests();
            RunTests();

            Console.ReadKey();
        }

        private static void CollectTests()
        {
            Tests = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(m => m.GetInterfaces().Contains(typeof(IDozeTest)))
                    .Select(m => m.GetConstructor(Type.EmptyTypes).Invoke(null) as IDozeTest)
                    .ToList();
        }

        private static void RunTests()
        {
            foreach(var test in Tests)
            {
                if(!test.Execute())
                {
                    Console.WriteLine($"Fail with test: '{test.GetType().FullName}'");
                }
            }

            Console.WriteLine("All tests executed");
        }
    }
}
