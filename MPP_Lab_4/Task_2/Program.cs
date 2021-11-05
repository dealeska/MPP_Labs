using System;
using System.Reflection;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length != 1)
            {
                Console.Write("Path: ");
                path = Console.ReadLine();
            }
            else
            {
                path = args[0];
            }

            GetTestMethods(path);

            Console.ReadLine();
        }

        static void GetTestMethods(string path)
        {
            Assembly asm = Assembly.LoadFile(path);
            Type[] types = asm.GetTypes();

            foreach(var type in types)
            {
                ExportClassAttribute attribute = (ExportClassAttribute)type.GetCustomAttribute(typeof(ExportClassAttribute), true);
                if (attribute != null)
                {                    
                    Console.WriteLine($"-> Class Name: {type.Name} Namespace: {type.Namespace} Cathegory: {attribute.Category}\n   Public methods:");
                    MethodInfo[] methods = type.GetMethods();
                    foreach (var method in methods)
                    {
                        if (method.IsPublic)
                        {
                            Console.WriteLine("     " + method.Name);                            
                        }
                    }

                    Console.WriteLine("   Public fields:");
                    FieldInfo[] fields = type.GetFields();
                    foreach (var field in fields)
                    {
                        if (field.IsPublic)
                        {
                            Console.WriteLine("     " + field.Name);
                        }
                    }

                    Console.WriteLine();
                }
            }                       
        }
    }
}
