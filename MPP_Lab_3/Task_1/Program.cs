using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MPP_Lab_3
{
    class Program
    {
        struct Asm
        {
            public string Namespace;
            public string Name;

            public Asm(string Namespace, string Name)
            {
                this.Namespace = Namespace;
                this.Name = Name;
            }
        }

        private static List<Asm> members = new List<Asm>();

        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Path to dll or exe: ");
            path = Console.ReadLine();

            Assembly asm = Assembly.LoadFrom(path);
            Type[] type = asm.GetTypes();

            foreach (Type t in type)
            {
                Console.WriteLine($"Class Name: {t.Name}\nNamespace: {t.Namespace}\nPublic methods:");
                MethodInfo[] method = t.GetMethods();
                foreach (var m in method)
                {
                    if (m.IsPublic)
                    {
                        Console.WriteLine(m.Name);
                        members.Add(new Asm(t.FullName, m.Name));
                    }
                }
                Console.WriteLine();
            }

            var sortedMembers = members.OrderBy(t => t.Namespace).ThenBy(m => m.Name);

            foreach (var m in sortedMembers)
            {
                Console.WriteLine($"{m.Namespace}, {m.Name}");
            }
            Console.ReadLine();
        }
    }
}
