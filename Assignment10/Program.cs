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

            
        }

        static void PrintProducts(List<Product> products, string title)
        {
            Console.WriteLine("\n" + title);
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Product Name: {product.ProductName}, Category: {product.Category}, Unit Price: {product.UnitPrice}, Units in Stock: {product.UnitsInStock}");
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

