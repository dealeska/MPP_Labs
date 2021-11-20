using System;

namespace MPP_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            DinamicList<int> a1 = new DinamicList<int>() { 3, 6, 8 };
            DinamicList<int> aa = new DinamicList<int>(a1);
            Console.WriteLine("count: " + aa.Count);
            Console.WriteLine("capasity: " + aa.Capasity);
            aa.Add(5);
            aa.Add(6);
            aa.Add(7);
            Console.WriteLine("count: " + aa.Count);
            Console.WriteLine("capasity: " + aa.Capasity);
            aa.Remove(5);
            Console.WriteLine("count: " + aa.Count);
            Console.WriteLine("capasity: " + aa.Capasity);
            aa.Add(8);
            aa.Add(9);
            aa.Add(10);
            aa.Add(11);
            Console.WriteLine("count: " + aa.Count);
            Console.WriteLine("capasity: " + aa.Capasity);
            aa.RemoveAt(3);

            foreach(var item in aa)
            {
                Console.Write(item + ",");
            }
            aa.Clear();
            Console.WriteLine("\ncount: " + aa.Count);
            Console.WriteLine("capasity: " + aa.Capasity);
            Console.ReadLine();
        }
    }
}
