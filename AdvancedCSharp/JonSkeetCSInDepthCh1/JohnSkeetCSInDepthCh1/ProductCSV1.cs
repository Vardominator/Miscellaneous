using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnSkeetCSInDepthCh1
{
    /// <summary>
    /// The Product type as written in C# 1.0
    /// 
    /// Limitations:
    ///     1. An ArrayList has no compile-time info.  You can accidentally add a string to the list and compiler wouldn't know.
    ///     2. Since the getters are public, that means setters must be public as well.
    /// </summary>
    class ProductCSV1
    {
        string name;
        public string Name { get { return name; } }

        decimal price;
        public decimal Price { get { return price; } }

        public ProductCSV1(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static ArrayList GetSampleProducts()
        {
            ArrayList list = new ArrayList();
            list.Add(new ProductCSV1("West Side Story", 9.99m));
            list.Add(new ProductCSV1("Assassins", 14.99m));
            list.Add(new ProductCSV1("Frogs", 13.99m));
            list.Add(new ProductCSV1("Sweeney Todd", 10.99m));
            return list;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }

    }
    
}
