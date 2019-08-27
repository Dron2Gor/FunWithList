using System;

namespace FunWithList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DronList<string> list = new DronList<string>();
            
            list.Add("sdsdsds");

            Console.WriteLine(list.Count);
            Console.WriteLine(list.Contains("sdsdsds"));
            Console.WriteLine(list.IndexOf("sdsdsds"));
        }
    }
}