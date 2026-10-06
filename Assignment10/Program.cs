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

            var ShorterThanValue = Arr.Where((digit, index) => digit.Length < index);

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

            #region Ordering Operators

            #region 1. Sort a list of products by name

            var orderedProductsByName = ProductsList.OrderBy(p => p.ProductName);

            PrintProducts(orderedProductsByName.ToList(), "Products Ordered by Name:");

            #endregion

            #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array. (missed)

            string[] WordsArray = { "aPPle", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var orderedWordsCaseInsensitive = WordsArray.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);

            PrintArray(orderedWordsCaseInsensitive.ToArray(), "Words Ordered Case-Insensitive:");

            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.

            var orderedProductsByUnitsInStock = ProductsList.OrderByDescending(p => p.UnitsInStock);

            PrintProducts(orderedProductsByUnitsInStock.ToList(), "Products Ordered by Units in Stock (Descending):");

            #endregion

            #region 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            string[] DigitsArray = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var orderedDigits = DigitsArray.OrderBy(digit => digit.Length).ThenBy(digit => digit);

            PrintArray(orderedDigits.ToArray(), "Digits Ordered by Length and Alphabetically:");

            #endregion

            #region 5. Sort first by-word length and then by a case-insensitive sort of the words in an array. (case-insensitive missed)

            string[] WordsArray2 = { "aPPle", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var orderedWordsByLengthThenCaseInsensitive = WordsArray2.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

            PrintArray(orderedWordsByLengthThenCaseInsensitive.ToArray(), "Words Ordered by Length and Case-Insensitive:");

            #endregion

            #region 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.

            var orderedProductsByCategoryThenPrice = ProductsList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            PrintProducts(orderedProductsByCategoryThenPrice.ToList(), "Products Ordered by Category and Unit Price (Descending):");

            #endregion

            #region 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.

            string[] WordsArray3 = { "aPPle", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var orderedWordsByLengthThenCaseInsensitiveDesc = WordsArray3.OrderBy(word => word.Length).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);

            PrintArray(orderedWordsByLengthThenCaseInsensitiveDesc.ToArray(), "Words Ordered by Length and Case-Insensitive Descending:");

            #endregion

            #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            string[] DigitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var filteredAndReversedDigits = DigitsArr.Where(digit => digit[1] == 'i').Reverse();

            PrintArray(filteredAndReversedDigits.ToArray(), "Digits with Second Letter 'i' Reversed:");

            #endregion

            #endregion

            #region Transformation Operators

            #region 1. Return a sequence of just the names of a list of products.

            var productNames = ProductsList.Select(p => p.ProductName);

            PrintArray(productNames.ToArray(), "Product Names:");

            #endregion

            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            string[] words = { "aPPle", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words.Select(word => new { Upper = word.ToUpper(), Lower = word.ToLower() });

            Console.WriteLine("\nUppercase and Lowercase Versions:");
            foreach (var word in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {word.Upper}, Lowercase: {word.Lower}");
            }

            #endregion

            #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            var productProperties = ProductsList.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

            Console.WriteLine("\nProduct Properties (with Price):");
            foreach (var product in productProperties)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Category: {product.Category}, Price: {product.Price}");
            }

            #endregion

            #region 4. Determine if the value of int in an array match their position in the array.

            int[] ARR = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var matchingValues = ARR.Where((value, index) => value == index);

            Console.WriteLine("\nValues that Match Their Position:");
            foreach (var value in ARR)
                Console.WriteLine(matchingValues.Contains(value) ? "True" : "False");

            #endregion

            #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var numberPairs = numbersA.SelectMany(a => numbersB, (a, b) => new { A = a, B = b })
                                      .Where(pair => pair.A < pair.B);

            Console.WriteLine("\nNumber Pairs (A < B):");
            foreach (var pair in numberPairs)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }

            #endregion

            #region 6. Select all orders where the order total is less than 500.00.

            var ordersLessThan500 = CustomersList.SelectMany(c => c.Orders)
                                                .Where(o => o.Total < 500.00m);

            PrintOrders(ordersLessThan500.ToList(), "Orders with Total Less than $500.00:");

            #endregion

            #region 7. Select all orders where the order was made in 1998 or later.

            var ordersFrom1998Onwards = CustomersList.SelectMany(c => c.Orders)
                                                  .Where(o => o.OrderDate.Year >= 1998);

            PrintOrders(ordersFrom1998Onwards.ToList(), "Orders from 1998 or Later:");

            #endregion

            #endregion

        }

        static void PrintProducts(List<Product> products, string title)
        {
            Console.WriteLine("\n" + title);

            Console.WriteLine($"\n{"Product Name",-35} {"Category",-20} {"Unit Price",-15} {"Units in Stock",-15}");

            Console.WriteLine(new string('-', 95));

            foreach (var product in products)
                Console.WriteLine($"{product.ProductName,-35} {product.Category,-20} {product.UnitPrice,-15} {product.UnitsInStock,-15}");
        }

        static void PrintArray(string[] arr, string title)
        {
            Console.WriteLine("\n" + title);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintOrders(List<Order> orders, string title)
        {
            Console.WriteLine("\n" + title);

            Console.WriteLine($"\n{"Order ID",-10} {"Order Date",-30} {"Total",-30}");
            Console.WriteLine(new string('-', 70));
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderID,-10} {order.OrderDate,-30} {order.Total,-30   }");
            }

        }
    }
}

