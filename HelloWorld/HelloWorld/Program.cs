// See https://aka.ms/new-console-template for more information
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! "); //WriteLine will insert a new line at the end of the output each time the method is used 
            Console.WriteLine("I am Learning C#");
            Console.Write("C# Can do math. For example is 3 + 3 = "); //Write will not insert a new line at the end of the output each time the method is used
            Console.WriteLine(3 + 3);
        }
    }
}