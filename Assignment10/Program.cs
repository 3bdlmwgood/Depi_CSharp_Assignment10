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

            #region Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddNumbersCount = numbers.Count(n => n % 2 != 0);

            Console.WriteLine($"\nNumber of Odd Numbers: {oddNumbersCount}");

            #endregion

            #region 2. Return a list of customers and how many orders each has.

            var customerOrderCounts = CustomersList.Select(c => new { Customer = c, OrderCount = c.Orders.Count() });

            foreach (var customerOrder in customerOrderCounts)
            {
                Console.WriteLine($"Customer: {customerOrder.Customer.CustomerName}, Order Count: {customerOrder.OrderCount}");
            }

            #endregion

            #region 3. Return a list of categories and how many products each has  (missed)

            var categoryProductCounts = ProductsList.GroupBy(p => p.Category)
                                                    .Select(g => new { Category = g.Key, ProductCount = g.Count() });

            foreach (var categoryProduct in categoryProductCounts)
            {
                Console.WriteLine($"Category: {categoryProduct.Category}, Product Count: {categoryProduct.ProductCount}");
            }

            #endregion

            #region 4. Get the total of the numbers in an array.

            int[] numbersArray = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var total = numbersArray.Sum();
            Console.WriteLine($"\nTotal of Numbers: {total}");

            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            string[] dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");

            var totalCharacters = dictionaryWords.Sum(word => word.Length);

            Console.WriteLine($"\nTotal Characters in Dictionary: {totalCharacters}");

            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            var shortestWordLength = dictionaryWords.Min(word => word.Length);
            Console.WriteLine($"\nLength of Shortest Word: {shortestWordLength}");

            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            var longestWordLength = dictionaryWords.Max(word => word.Length);
            Console.WriteLine($"\nLength of Longest Word: {longestWordLength}");

            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            var averageWordLength = dictionaryWords.Average(word => word.Length);
            Console.WriteLine($"\nAverage Word Length: {(int)(averageWordLength)}");

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

