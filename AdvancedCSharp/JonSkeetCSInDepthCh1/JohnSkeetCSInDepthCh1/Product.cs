using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnSkeetCSInDepthCh1
{

    /// <summary>
    /// The product type in C# 1
    ///     1. ArrayList has no compile-time information about what's in it.
    ///        You could accidentally add a string and nothing would happen.
    ///     2. Both getters and setters have to be either public or private
    ///     3. A lot of fluff in creating properties and variables
    /// </summary>
    class Product
    {
        string name;
        public string Name { get { return name; } }

        // decimal is a 128 bit data type
        decimal price;
        public decimal Price { get { return price; } }

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static ArrayList GetSampleProducts()
        {
            ArrayList list = new ArrayList();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));

            return list;

        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }


    /// <summary>
    /// Strongly typed collections and private setters (C# 2)
    /// </summary>
    class Product2
    {

        string name;
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }

        // decimal is a 128 bit data type
        decimal price;
        public decimal Price
        {
            get { return price; }
            private set
            {
                price = value;
            }
        }

        // Due to the private set feature, the fields can be initialized using the property
        public Product2(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // C# 2: Generic List
        public static List<Product2> GetSampleProducts()
        {

            List<Product2> list = new List<Product2>();
            list.Add(new Product2("West Side Story", 9.99m));
            list.Add(new Product2("Assassins", 14.99m));
            list.Add(new Product2("Frogs", 13.99m));
            list.Add(new Product2("Sweeney Todd", 10.99m));

            return list;

        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }

    /// <summary>
    /// Automatically implemented properties and simpler initializaitons (C# 3)
    /// </summary>
    class Product3
    {
        // No need to implemented get and set
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product3(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        Product3() { }

        public static List<Product3> GetSampleProducts()
        {

            return new List<Product3>
            {
                // Property-based initalization
                new Product3 {Name = "West Side Story", Price = 9.99m },
                new Product3 {Name = "Assassins", Price = 14.99m },
                new Product3 {Name = "Frogs", Price = 13.99m },
                new Product3 {Name = "Sweeney Todd", Price = 10.99m }
            };

        }

    }

    /// <summary>
    /// Named arguments for clear initialization code (C# 4)
    ///     1. A type with private setters can't be publicly mutated,
    ///        but what if it needed to be privately immutable as well?
    /// </summary>
    class Product4
    {
        readonly string name;
        public string Name { get { return name; } }

        readonly decimal price;
        public decimal Price { get { return price; } }

        public Product4(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        Product4() { }

        public static List<Product4> GetSampleProducts()
        {

            return new List<Product4>
            {
                // Property-based initalization
                new Product4 (name: "West Side Story", price: 9.99m ),
                new Product4 (name: "Assassins", price: 14.99m ),
                new Product4 (name: "Frogs", price: 13.99m ),
                new Product4 (name: "Sweeney Todd", price: 10.99m )
            };

        }

    }

}
