using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> met = new List<string>();
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
                        met.Add(m.Name);
                    }
                }                
                Console.WriteLine();
            }

            var sortedMethods = met.OrderBy(m => m);

            foreach (var m in sortedMethods)
            {                
                Console.WriteLine(m);                                  
            }
            Console.ReadLine();
        }
    }
}
