using static Assignment10.ListGenerator;

namespace Assignment10
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Restriction Operators

            #region 1. Find all products that are out of stock.

            var productsOutOfStock = ProductsList.Where(p => p.UnitsInStock == 0);
            
            PrintProducts(productsOutOfStock.ToList(), "Products Out of Stock:");

            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.

            var ProductsInStockAndCostMoreThan3 = ProductsList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);

            PrintProducts(ProductsInStockAndCostMoreThan3.ToList(), "Products in Stock and Costing More than $3.00:");

            #endregion

            #region 3. Returns digits whose name is shorter than their value.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var ShorterThanValue = Arr.Where((digit,index) => digit.Length < index);

            PrintArray(ShorterThanValue.ToArray(), "Digits whose name is shorter than their value:");


            #endregion

            #endregion

            #region Element Operators

            #region 1. Get first Product out of Stock 

            var firstProductOutOfStock = ProductsList.First(p => p.UnitsInStock == 0);

            Console.WriteLine($"\nFirst Product Out of Stock: {firstProductOutOfStock.ProductName}");

            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            var firstProductPriceGreaterThan1000 = ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"\nFirst Product with Price > $1000: {firstProductPriceGreaterThan1000?.ProductName ?? "None"}");

            #endregion

            #region 3. Retrieve the second number greater than 5 

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var s = arr.Where(element => element > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"\nSecond Number Greater than 5: {s}");

            #endregion

            #endregion

        }

        static void PrintProducts(List<Product> products, string title)
        {
            Console.WriteLine("\n" + title);
            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Unit Price: {product.UnitPrice}, Units in Stock: {product.UnitsInStock}");
            }
        }

        static void PrintArray(string[] arr, string title)
        {
            Console.WriteLine("\n" + title);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

    }
}

