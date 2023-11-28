using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use quantifier operators (methods 'All', 'Any', 'SequenceEqual' and `Contains`) in LINQ queries.
    /// Quantifier operation definition:
    /// <see cref="IEnumerable{T}"/> → bool
    /// Quantifier operations return a Boolean value that indicates whether some or all of the elements
    /// in a sequence satisfy a condition.
    /// </summary>
    public static class QuantifierOperations
    {
        /// <summary>
        /// Checks if two sequences match on all elements in the same order.
        /// </summary>
        /// <returns>true.</returns>
        public static bool EqualSequence()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "cherry", "apple", "blueberry" };

            if(wordsA.SequenceEqual(wordsB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if two sequences match on all elements in the same order.
        /// </summary>
        /// <returns>false.</returns>
        public static bool NotEqualSequence()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "apple", "blueberry", "cherry" };

            if(wordsA.SequenceEqual(wordsB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if there is at least one word in the list containing “ei”.
        /// </summary>
        /// <returns>true.</returns>
        public static bool AnyMatchingElements()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool containsEi = words.Any(word => word.Contains("ei"));
            return containsEi;
        }

        /// <summary>
        /// Creates product categories with zero units in stock. 
        /// </summary>
        /// <returns>Grouped product categories with zero units in stock.</returns>
        public static IEnumerable<(string category, IEnumerable<Product> products)> GroupedAnyMatchedElements()
        {
            List<Product> products = Products.ProductList;

            var groupedProducts = products
        .GroupBy(p => p.Category)
        .Select(g => (category: g.Key, products: g.AsEnumerable()));

            var categoriesWithZeroStock = groupedProducts
                .Where(group => group.products.Any(p => p.UnitsInStock == 0));

            return categoriesWithZeroStock;
        }

        /// <summary>
        /// Determines whether all elements are odd.
        /// </summary>
        /// <returns>true.</returns>
        public static bool AllMatchedElements()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            bool oddNumbers = numbers.All(number => number % 2 != 0);
            return oddNumbers;
        }

        /// <summary>
        /// Creates product categories with more than zero units in stock. 
        /// </summary>
        /// <returns>Grouped product categories with more than zero units in stock.</returns>
        public static IEnumerable<(string category, IEnumerable<Product> products)> GroupedAllMatchedElements()
        {
            List<Product> products = Products.ProductList;

            var orderedCategories = new List<string>
            {
                "Beverages",
                "Produce",
                "Seafood",
                "Confections",
                "Grains/Cereals"
            };
            var groupedProducts = orderedCategories
        .Select(category =>
        {
            var categoryProducts = products
                .Where(p => p.Category == category && p.UnitsInStock > 0)
                .OrderBy(p => p.ProductId)
                .ToList();

            return (category, (IEnumerable<Product>)categoryProducts);
        });

            return groupedProducts;
        }

        /// <summary>
        /// Determines whether the sequence contains the given element.
        /// </summary>
        /// <returns>true.</returns>
        public static bool HasAThree()
        {
            int[] numbers = { 2, 3, 4 };

            bool hasAtree = numbers.Contains(3);
            if (hasAtree)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}