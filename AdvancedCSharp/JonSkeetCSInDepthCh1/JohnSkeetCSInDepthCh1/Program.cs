using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnSkeetCSInDepthCh1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Using the ProductNameComparer class to sort
            List<Product2> products2 = Product2.GetSampleProducts();
            products2.Sort(new ProductNameComparer());
            foreach (Product2 product2 in products2)
            {

                Console.WriteLine(product2);

            }


            // Sorting a List<Product2> using Comparison<Product2> without having to implement the IComparer interface (C# 2)
            products2.Sort(delegate (Product2 x, Product2 y)
                { return x.Name.CompareTo(y.Name); }
            );


            // Sorting using Comparison<Product> from a lambda expression (C# 3)
            List<Product3> products3 = Product3.GetSampleProducts();
            products2.Sort((x, y) => x.Name.CompareTo(y.Name));

            // In C# 3 you can easily print out the names in order without modifying the original list of products
            foreach(Product3 product3 in products3.OrderBy(p => p.Name))
            {
                Console.WriteLine(products3);
            }

        }
    }


    // Sorting a List<Product> using IComparer<Product> (C# 2)
    class ProductNameComparer : IComparer<Product2>
    {
        public int Compare(Product2 x, Product2 y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

}
