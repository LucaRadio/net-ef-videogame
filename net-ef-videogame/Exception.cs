using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class ExceptionTitle : Exception
    {
        public ExceptionTitle()
        {
            Console.WriteLine("Insert a valid name. Cannot be empty!");

        }

    }
    internal class ExceptionDate : Exception
    {
        public ExceptionDate()
        {
            Console.WriteLine($"Insert a valid Date");

        }
    }
    internal class ExceptionNumber : Exception
    {
        public ExceptionNumber()
        {
            Console.WriteLine($"Insert a valid number");

        }
    }
}
