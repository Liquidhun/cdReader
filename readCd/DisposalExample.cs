using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExample
{
    public class DisposableExample : IDisposable
    {
        public DisposableExample()
        {
            Console.WriteLine("Konstruktor");
        }

        public void Method()
        {
            Console.WriteLine("Method");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose metódus");
        }
    }
}