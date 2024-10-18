using SampleClassLibrary;

namespace SampleConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // All we have to do here is invoke the method to make sure
            // that the nuget package installed properly and that the
            // native file dependencies were copied correctly.
            var result = ErfaLib.c2s();

            Console.WriteLine(result);
            Console.WriteLine("Hello, World!");
        }
    }
}
