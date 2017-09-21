using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
