using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClassExample
{
    partial class TestClass
    {
        public int SomeValue { get; set; }
    }

    partial class TestClass
    {
        public string SomeString { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();
        }
    }
}
