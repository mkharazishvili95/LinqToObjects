using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.EqualityComparers
{
    /// <summary>
    /// Compares two strings to see if they are anagrams.
    /// Anagrams are pairs of words formed from the same letters.
    /// </summary>
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null)
                return false;

            return GetCanonicalString(x) == GetCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return GetCanonicalString(obj).GetHashCode();
        }

        private string GetCanonicalString(string word)
        {
            char[] wordChars = word.ToUpper().Where(char.IsLetterOrDigit).OrderBy(c => c).ToArray();
            return new string(wordChars);
        }
    }
}
