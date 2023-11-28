using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use aggregate operations (methods 'Min', 'Max', 'Count', 'Sum', 'Average', and `Aggregate`) in LINQ queries.
    /// Aggregation operation definition:
    /// <see cref="IEnumerable{TSource}"/> → scalar.
    /// An aggregation operation computes a single value from a collection of values.
    /// </summary>
    public static class AggregationOperations
    {
        /// <summary>
        /// Calculates the count of elements in sequence.
        /// </summary>
        /// <returns>Count of elements in sequence.</returns>
        public static int CountNumbers()
        {
            int[] numbers = { 2, 2, 3, 5, 5 };

            var numbersCount = numbers.Count();
            return numbersCount;
        }

        /// <summary>
        /// Calculates the number of odd numbers in the array.
        /// </summary>
        /// <returns>Count of of odd numbers in the array.</returns>
        public static int CountOddNumbers()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddCount = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0 && numbers[i] != 0)
                {
                    oddCount += 1;
                }
            }
            return oddCount;
        }

        /// <summary>
        /// Calculates for each customer count of his orders.
        /// </summary>
        /// <returns>The sequence of customers and how many orders each has.</returns>
        public static IEnumerable<(string customerId, int orderCount)> CustomersOrdersCount()
        {
            List<Customer> customers = Customers.CustomerList;

            var customerOrderCounts = customers.Select(cust =>
        (customerId: cust.CustomerId, orderCount: cust.Orders?.Length ?? 0)
    );
            return customerOrderCounts;
        }

        /// <summary>
        /// Defines a sequence of categories and how many products each has.
        /// </summary>
        /// <returns>The sequence of categories and how many products each has.</returns>
        public static IEnumerable<(string category, int productCount)> ProductsInCategoryCount()
        {
            List<Product> products = Products.ProductList;

            var productsInCategory = products
        .GroupBy(product => product.Category)
        .Select(group => (category: group.Key, productCount: group.Count()));

            return productsInCategory;
        }

        /// <summary>
        /// Calculates the sum of the numbers in an array.
        /// </summary>
        /// <returns>Sum of elements of numbers.</returns>
        public static int Sum()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var count = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                count += numbers[i];
            }
            return count;
        }

        /// <summary>
        /// Calculates the total number of characters of all words in the array.
        /// </summary>
        /// <returns>The total number of characters of all words in the array.</returns>
        public static int SumByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var countWords = 0;
            for(int i = 0; i <  words.Length; i++)
            {
                countWords += words[i].Length;
            }
            return (int)countWords;
        }

        /// <summary>
        /// Calculates the total units in stock for each product category.
        /// </summary>
        /// <returns>The total units in stock for each product category.</returns>
        public static IEnumerable<(string category, int totalUnitsInStock)> TotalUnitsInStock()
        {
            List<Product> products = Products.ProductList;

            var totalUnitsInStock = products
        .GroupBy(product => product.Category)
        .Select(group =>
            (category: group.Key, totalUnitsInStock: group.Sum(product => product.UnitsInStock))
        );
            return totalUnitsInStock;
        }

        /// <summary>
        /// Calculates the lowest number in an array.
        /// </summary>
        /// <returns>The lowest number in an array.</returns>
        public static int Min()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Array.Sort(numbers);
            var minNumber = numbers[0];
            return minNumber;

        }

        /// <summary>
        /// Calculates the length of the shortest word in an array.
        /// </summary>
        /// <returns></returns>
        public static int MinByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var shortestWord = words.Min(word => word.Length);
            return shortestWord;

        }

        /// <summary>
        /// Calculates the cheapest price among each category's products.
        /// </summary>
        /// <returns>The cheapest price among each category's products.</returns>
        public static IEnumerable<(string category, decimal cheapestPrice)> GetCheapestPrice()
        {
            List<Product> products = Products.ProductList;

            var cheapestPrice = products
        .GroupBy(product => product.Category)
        .Select(group =>
            (category: group.Key, cheapestPrice: group.Min(product => product.UnitPrice))
        );

            return cheapestPrice;
        }

        /// <summary>
        /// Calculates the highest number in an array.
        /// </summary>
        /// <returns>The highest number in an array.</returns>
        public static int Max()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Array.Sort(numbers);
            var maxNumber = numbers[numbers.Length - 1];
            return maxNumber;
            
        }

        /// <summary>
        /// Calculates the length of the longest word in an array.
        /// </summary>
        /// <returns>The length of the longest word in an array.</returns>
        public static int MaxByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var longestWord = words.Max(word => word.Length);
            return longestWord;
        }

        /// <summary>
        /// Calculates the most expensive price among each category's products.
        /// </summary>
        /// <returns>The most expensive price among each category's products.</returns>
        public static IEnumerable<(string category, decimal mostExpensivePrice)> GetMostExpensivePrice()
        {
            List<Product> products = Products.ProductList;

            var mostExpensiveProduct = products
                .GroupBy(product => product.Category)
                .Select(group =>
    (category: group.Key, mostExpensiveProduct: group.Max(product => product.UnitPrice)));
            return mostExpensiveProduct;

        }

        /// <summary>
        /// Gets the average of all numbers in an array.
        /// </summary>
        /// <returns>The average of all numbers in an array.</returns>
        public static double Average()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var average = numbers.Average();
            return average;
        }

        /// <summary>
        /// Gets the average length of the words in the array.
        /// </summary>
        /// <returns>The average length of the words in the array.</returns>
        public static double AverageByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var averageByLength = words.Average(word => word.Length);
            return averageByLength;
        }

        /// <summary>
        /// Gets the average price of each category's products.
        /// </summary>
        /// <returns>The average price of each category's products.</returns>
        public static IEnumerable<(string Category, decimal averagePrice)> AveragePrice()
        {
            List<Product> products = Products.ProductList;

            var averagePrice = products
                .GroupBy(product => product.Category)
                .Select(group =>
    (category: group.Key, averagePrice: group.Average(product => product.UnitPrice)));
            return averagePrice;

        }

        /// <summary>
        /// Calculates the total product of all elements.
        /// </summary>
        /// <returns>The total product of all elements.</returns>
        public static double Aggregate()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            double totalProduct = doubles.Aggregate((accumulator, currentValue) => accumulator * currentValue);
            return totalProduct;
        }

        /// <summary>
        /// Subtracts each withdrawal from the initial balance of 100, as long as the balance never drops below 0.
        /// </summary>
        /// <returns>Final balance.</returns>
        public static double SeededAggregate()
        {
            double startBalance = 100.0;

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            double finalBalance = attemptedWithdrawals.Aggregate(startBalance, (balance, withdrawal) =>
            {
                double newBalance = balance - withdrawal;
                if(newBalance >= 0)
                {
                    return newBalance;
                }
                else
                {
                    return balance;
                }
            });

            return finalBalance;
        }
    }
}