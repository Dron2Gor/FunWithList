using System;

namespace FunWithList
{
    class Program
    {
        static void Main(string[] args)
        {
////            Console.WriteLine("Hello World!");
//            DronList<string> list = new DronList<string>();
//            
//            list.Add("sdsdsds");
//            list.Add("sdsdsds2");
//            list.Add("sdsdsds3");
//            list.Add("sdsdsds4");
//            list.Add("sdsdsds5");
//            list.Insert(1,"88");
//
//            Console.WriteLine(list.Count);
//            Console.WriteLine(list.Contains("sdsdsds"));
//            Console.WriteLine(list.IndexOf("sdsdsds"));
//
//            foreach (var item in list)
//            {
//                Console.WriteLine(item);
//            }
//
//            Console.WriteLine(list[1]+"---------------------------");
//            
//            list.Remove("sdsdsds");
//
//            foreach (var item in list)
//            {
//                Console.WriteLine(item);
//            }
//            Console.WriteLine("the end");
//
//            Console.WriteLine("---------------------------------------");
//            DronStack<int> stack = new DronStack<int>();
//            
//            stack.Push(1);
//            stack.Push(2);
//            stack.Push(3);
//            stack.Push(4);
//            stack.Push(5);
//            stack.Push(6);
//            stack.Push(7);
//            stack.Push(8);
//            stack.Push(9);
//            stack.Push(10);
//            stack.Push(11);
//            stack.Push(12);
//            stack.Push(13);
//            stack.Push(14);
//            stack.Push(15);
//            stack.Push(16);
//            stack.Push(17);
//            stack.Push(18);
//
//            foreach (int item in stack)
//            {
//                Console.WriteLine(item);
//            }
//
//            Console.WriteLine("----------------");
//
//            Console.WriteLine(stack.Peek());
//
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine("-----------------");
//            foreach (int item in stack)
//            {
//                Console.WriteLine(item);
//            }
            DronQueue<string> queue = new DronQueue<string>();
            
            queue.Enqueue("1111");
            queue.Enqueue("2222");
            queue.Enqueue("3333");
            queue.Enqueue("4444");
            queue.Enqueue("5555");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine("---------------------------");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}