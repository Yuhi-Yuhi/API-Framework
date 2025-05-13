using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
    public class DataHelpers
    {
        public string GenerateString()
        {
            string param = "qwerty";
            Console.WriteLine(param);
            return param;

        }
        public static string GenerateStringStatic()
        {
            string param = null;
            try
            {
                Console.WriteLine("Блок try");
                param = "asdf";
                Console.WriteLine(param);

            }
            catch (NullReferenceException ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return param;
        }
        public static string GenerateStringStatic2()
        {
            string param = null;
            Console.WriteLine("Блок try");
            param = "asdf";
            Console.WriteLine(param);
            return param;
        }
    }
}
