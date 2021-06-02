using System;
using System.IO;

namespace test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input path to DLL!");
            //testcase
            //PrintClassMethods("C:\\Users\\admin\\source\\repos\\ClassLibrary_test\\ClassLibrary_test\\bin\\Debug\\net5.0");
            PrintClassMethods(Console.ReadLine());
        }

        static void PrintClassMethods(string dllPath)
        {
            if (Directory.Exists(dllPath))
            {
                foreach (string filename in Directory.GetFiles(dllPath))
                {
                    if (Path.GetExtension(filename) == ".dll")
                    {
                        System.Reflection.Assembly myDllAssembly =
                            System.Reflection.Assembly.LoadFile(filename);

                        foreach (var type in myDllAssembly.GetTypes())
                        {
                            if (!type.IsClass || type.IsNotPublic) continue;
                            Console.WriteLine("=========================");
                            Console.WriteLine(type);

                            foreach (var metdh in type.GetMethods())
                            {
                                if (metdh.IsPrivate) continue;
                                Console.WriteLine("- " + metdh.Name);
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("Directory does not exists.");

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
