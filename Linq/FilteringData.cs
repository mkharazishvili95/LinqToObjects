﻿using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use of filter operations (method 'Where' and 'where' keywords) in LINQ queries.
    /// Filtering : <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{TSource}"/>
    /// Filtering refers to the operation of restricting the result set to contain only
    /// those elements that satisfy a specified condition. It is also known as selection.
    /// </summary>
    public static class FilteringData
    {
        /// <summary>
        /// Finds all elements of an array less than 5.
        /// </summary>
        /// <returns>All elements of an array less than 5.</returns>
        public static IEnumerable<int> LowNumbers()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lessThanFive = numbers.Where(number => number < 5);
            return lessThanFive;
        }

        /// <summary>
        /// Finds all products that are out of stock.
        /// </summary>
        /// <returns>All products that are out of stock.</returns>
        public static IEnumerable<Product> ProductsOutOfStock()
        {
            List<Product> products = Products.ProductList;

            var outOfStockProducts = products.Where(product => product.UnitsInStock == 0).ToList();
            return outOfStockProducts;
        }

        /// <summary>
        /// Finds all products that are in stock and cost more than 50.0 per unit.
        /// </summary>
        /// <returns>All products that are in stock and cost more than 50 per unit.</returns>
        public static IEnumerable<Product> ExpensiveProductsInStock()
        {
            List<Product> products = Products.ProductList;

            var inStockProducts = products.Where(product => product.UnitsInStock > 0 
            && product.UnitPrice > 50).ToList();
            return inStockProducts;
        }

        /// <summary>
        /// Finds digits whose name is shorter than their value.
        /// </summary>
        /// <returns>Digits whose name is shorter than their value.</returns>
        public static IEnumerable<string> IndexedWhere()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shorterNamedDigits = digits.Where((value, index) => value.Length < index);
            return shorterNamedDigits;
        }
    }
}