using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
    public class CalculationHelper
    {
        public int Method1(int x, int y)
        {
            return x + y;
        }

        public int Method1(int x, int y, string logMessage = "Результат сложения: ")
        {
            int result = x + y;
            Console.WriteLine($"{logMessage} {result}");
            return result;
        }

        public static int Method2(int a, int b)
        {
            return a - b;
        }

        public static int Method2(int a, int b, string logMessage = "Результат вычитания: ")
        {
            int result = a - b;
            Console.WriteLine($"{logMessage} {result}");
            return result;
        }

        
    }
}
