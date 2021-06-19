using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyReflectionMainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is my learning project for C# reflection");
            Console.ReadKey(true);

            Console.WriteLine("First of all, getting type");
            Console.WriteLine("There are three ways:\n *keyword typeof;\n *method Object.GetType();" +
                "\n *static method Type.GetType()\n");

            Console.WriteLine("***** First: keyword typeof *****");
            Console.WriteLine("Let`s try to use typeof with class Sabaka without any exemplars of it");
            Type sabakaType = typeof(Sabaka);
            Console.WriteLine(sabakaType);
            Console.WriteLine(sabakaType.ToString());
            Console.WriteLine(sabakaType.FullName);
            Console.ReadKey(true);
            Console.WriteLine();

            Console.WriteLine("***** Second: method Object.GetType() *****");
            Console.WriteLine("Unlike of previous, there is needed to create an exemplar of class and" +
                "after thar we use Object.GetType() on it");
            Sabaka doggy = new Sabaka();
            Type doggyType = doggy.GetType();
            Console.WriteLine(doggyType);
            Console.WriteLine();
            Console.WriteLine("All open members of Type can be watched by GetMembers. All public members of Sabaka:");
            doggyType.GetMembers().ToList().ForEach(x => Console.WriteLine(x.MemberType.ToString(), x.Name));
            Console.ReadKey(true);
            Console.WriteLine();

            Console.WriteLine("\n***** Third: static method Type.GetType() *****\n");
            Console.WriteLine("There is work with .exe file also named assembly with this approach." +
                "This time class Sabaka is inside MyReflectionMainProject, that`s why we didn`t create" +
                "assembly object. But if class lie inside another .dll file, there is needed to be" +
                "point after comma\n");
            Type sabakaStatisGetType = Type.GetType("MyReflectionMainProject.Sabaka", false, true);
            Console.WriteLine(sabakaStatisGetType);
            Console.WriteLine();
            Console.WriteLine("All public methods of Sabaka");
            sabakaStatisGetType.GetMethods().ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadKey(true);

            Console.WriteLine("\n***** Getting the information about methods *****\n");
            Console.WriteLine("There are some methods of Type, that will be helpfull. There are group of methods Get[Any field]");
            Console.ReadKey(true);

            Console.WriteLine("\n****** Dynamically loading assemblies and late binding ******\n");

            Console.WriteLine("There are many assemblies that would be used when you create an " +
                "application. You must point links to tahts assemblies at the project. After that" +
                "if some of that assemlies needed, they automaticaly loads.");
            Console.ReadKey(true);
            Console.WriteLine("Bu also we can dynamically load another assemblies, without any links");
            Console.WriteLine("There are Class Aseebly for work with them. With this class you can load" +
                " abd search another assemblies");
            Console.WriteLine(@"Two methods: Assembly.LoadForm(string ""path_to_assembly"") or Assembly.Load(friendly assembly)\n");
            Console.ReadKey(true);

            Assembly asm = Assembly.LoadFrom("importLib.dll");
            Console.WriteLine(asm.GetName().Name);
            Console.WriteLine(asm.Location);
            asm.GetTypes().ToList().ForEach(x => Console.WriteLine(x.Name));
            Console.ReadKey(true);

            Console.WriteLine("\n***** late binding *****\n");
            Console.WriteLine("With dynamically loading we can realize a late binding. " +
                "Late binding give us an opportunity to create exemplars of some types" +
                " and use them while app is running up");
            Console.WriteLine("There is class System.Activator, that plays key role. " +
                "With his static method Activator.CreateInstance() we can create an exemplars" +
                "of chosen type");
            Console.WriteLine("We are already loaded assembly, lets call some method");

            Console.ReadKey(true);
            Console.WriteLine("Please, write some class from assembly\n");
            //Type someType = Type.GetType($"{asm.GetName().Name}.{Console.ReadLine()}", false, true);
            Type someType = asm.GetType($"{asm.GetName().Name}.{Console.ReadLine()}");
            Console.WriteLine($"Now we have class {someType.FullName}, lets create exemplar of it\n");

            Console.ReadKey(true);
            object obj = Activator.CreateInstance(someType);


            Console.WriteLine("Let`s try to call some method, but before that, we neeed to know his methods\n");
            someType.GetMethods().ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadKey(true);
            Console.WriteLine("Please, write some method\n");
            string methodName = Console.ReadLine();
            MethodInfo method = someType.GetMethod(methodName);
            Console.WriteLine($"Now we have method {method.Name}, let`s see his attributes and try to call it");
            foreach (var item in method.GetParameters())
            {
                Console.WriteLine($"{item.ParameterType} {item.Name}");
            }

            Console.ReadKey(true);
            Console.WriteLine("If method has more then 0 atributes, lets insert them");
            if(method.GetParameters().Length == 0)
            {
                method.Invoke(obj, null);
            }
            else
            {
                object[] parr = new object[method.GetParameters().Length];
                for (int i = 0; i < method.GetParameters().Length; i++)
                {
                    parr[i] = Console.ReadLine();
                }
                object result = method.Invoke(obj, parr);
                Console.WriteLine(result);
            }
            Console.ReadKey(true);      
        }
    }

    public class Sabaka
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Sabaka()
        {
            Name = "Good Boy";
            Age = 5;
        }
        public void GafGaf()
        {
            Console.WriteLine("Gaf-Gaf");
        }        

        public static void StGafGaf()
        {
            Console.WriteLine("Static Gaf-Gaf");
        }
    }
}
