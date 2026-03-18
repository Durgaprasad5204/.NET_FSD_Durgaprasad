using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace consoleapp1
{
    internal class Problem1
    {
        static void Main(string[] args)
        {
            
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"\n{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.WriteLine("\n--------------------Grain Products-----------------------------");

            //Grain Products
            var grain = products.Where(p=> p.ProCategory == "Grain").ToList();  
            foreach(var item in grain)
            {
                Console.WriteLine($"\n{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //Ascending order by product code
            Console.WriteLine("\n--------------------Ascending order by product code -----------------------------");
            var ascOrder = products.OrderBy(product=>product.ProCode).ToList();
            foreach(var item in ascOrder)
            {
                Console.WriteLine($"\n { item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //Ascending order by product name
            Console.WriteLine("\n--------------------ascending order by product Category -----------------------------");
            var ascOrderByCategory = products.OrderBy(product => product.ProCategory).ToList();
            foreach(var item in ascOrderByCategory)
            {
                Console.WriteLine($"\n{item.ProCategory}\t{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //Ascending order by product Mrp
            Console.WriteLine("\n--------------------ascending order by product Mrp -----------------------------");
            var ascOrderByMrp = products.OrderBy(product => product.ProMrp).ToList();
            foreach(var item in ascOrderByMrp)
            {
                Console.WriteLine($"\n{item.ProMrp}\t{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
            }

            //Descending Order by product Mrp
            Console.WriteLine("\n--------------------Descending Order by product Mrp -----------------------------");
            var descOrderByMrp = products.OrderByDescending(product => product.ProMrp).ToList();
            foreach(var item in descOrderByMrp)
            {
                Console.WriteLine($"{item.ProMrp}\t{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
            }

            // display products group by product Category
            Console.WriteLine("\n--------------------display products group by product Category -----------------------------");
            var groupByCategory = products.GroupBy(product => product.ProCategory);
            foreach (var group in groupByCategory)
            {
                Console.WriteLine($"\nCategory: {group.Key}"); 
                foreach(var item in group )
                {
                    Console.WriteLine($"\t{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

                }
            }
            //display products group by product Mrp.
            Console.WriteLine("\n--------------------display products group by product Mrp -----------------------------");
            var groupByMrp = products.GroupBy(product => product.ProMrp);
            foreach(var group in groupByMrp)
            {
                Console.WriteLine($"Mrp: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"\t{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
                }
            }

            // display product detail with highest price in FMCG category.
            Console.WriteLine("\n--------------------display product detail with highest price in FMCG category -----------------------------");
            var highestPriceFMCG = products.Where(product => product.ProCategory == "FMCG").OrderByDescending(product => product.ProMrp).FirstOrDefault();
            Console.WriteLine($"\nHighest Price FMGC Product: {highestPriceFMCG.ProCode}\t{highestPriceFMCG.ProName}\t{highestPriceFMCG.ProMrp}");

            //display count of total products.
            Console.WriteLine("\n--------------------display count of total products -----------------------------");
            var totalProducts = products.Count();
            Console.WriteLine($"\nTotal Products: {totalProducts}");

            //display count of total products with category FMCG.
            Console.WriteLine("\n--------------------display count of total products with category FMCG -----------------------------");
            var totalFMCGProducts = products.Count(product => product.ProCategory == "FMCG");
            Console.WriteLine($"\n Totoal FMCG Products :{totalFMCGProducts} ");

            //Write a LINQ query to display Max price.
            Console.WriteLine("\n--------------------display Max price -----------------------------");
            var maxPrice = products.Max(Product => Product.ProMrp);
            Console.WriteLine($"\n Max Price : {maxPrice}");

            //Write a LINQ query to display Min price.
            Console.WriteLine("\n--------------------display Min price -----------------------------");
            var MinPrice = products.Min(product => product.ProMrp);
            Console.WriteLine($"\n Min Price : {MinPrice}");

            //to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("\n--------------------display whether all products are below Mrp Rs.30 or not -----------------------------");
            bool allBelow30 = products.All(p => p.ProMrp < 30);

            Console.WriteLine("Are all products below Rs.30 ? " + allBelow30);



            Console.ReadLine();
        }
    }
}
