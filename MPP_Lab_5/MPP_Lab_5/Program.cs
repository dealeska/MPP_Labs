using System;

namespace MPP_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {           
            DynamicList<string> names = new DynamicList<string>() { "Gleb", "Olga" };
            Console.WriteLine("Сount: " + names.Count);
            Console.WriteLine("Сapasity: " + names.Capacity);

            names.Add("Alesya");
            names.Add("Katya");
            names.Add("Ksusha");
            Console.WriteLine("Count: " + names.Count);
            Console.WriteLine("Capasity: " + names.Capacity);
            PrintList(names);

            names.Remove("Katya");
            Console.WriteLine("Count: " + names.Count);
            Console.WriteLine("Capasity: " + names.Capacity);
            PrintList(names);

            names.Add("Matvei");
            names.Add("Alexandr");
            names.Add("Kirill");
            names.Add("Denis");
            Console.WriteLine("Count: " + names.Count);
            Console.WriteLine("Capasity: " + names.Capacity);
            PrintList(names);

            names.RemoveAt(3);
            names.RemoveAt(names.Count - 1);
            Console.WriteLine("Count: " + names.Count);
            Console.WriteLine("Capasity: " + names.Capacity);
            PrintList(names);

            names.Clear();
            Console.WriteLine("Count: " + names.Count);
            Console.WriteLine("Capasity: " + names.Capacity);
            Console.ReadLine();
        }

        static void PrintList<T>(DynamicList<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("\n");
        }
    }
}
