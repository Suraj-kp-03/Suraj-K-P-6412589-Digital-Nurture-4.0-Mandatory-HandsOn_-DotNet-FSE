using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    sealed class Logger // Implemeted sealed class which prevents from being inherited to other classes in the application
    {
        private static Logger _instance = new Logger();
        private Logger()
        {
            Console.WriteLine("Private Static Logger Instance and Private Constructor was created.");
        }
        public static Logger Instance 
        {
            get
            {
                return _instance;
            }
        }
    }
    class Program // Main class to test the Singleton Pattern Design
    {
        static void Main(string[] args)
        {
            Logger logger1 =Logger.Instance;
            Logger logger2 =Logger.Instance;
            if (logger1 == logger2)
            {
                Console.WriteLine("The Singleton Pattern Design was Succesful: Only one Instance created Throughout the Process. ");
            }
            else
            {
                Console.WriteLine(" Pattern Design Un-successful: More than one Instance is created");
            }
            Console.ReadLine();// Terminal gets closed when pressed enter, to prevent instant closing.
        }
    }

}