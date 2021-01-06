﻿using System;
using System.Linq;

namespace Linq
{
    public class LinqMethods
    {
        public LinqMethods()
        {
        }

        public (int, int) ConsonantAndVowelCounter(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            const string vowels = "aeiou";
            int vowelsCount = text.Count(character => vowels.Contains(character));
            int consonantsCount = text.Length - vowelsCount;
            return (vowelsCount, consonantsCount);
        }

        public char FirstUniqueCharacter(string text)
        {
            return text.First(chr => text.Count(character => character == chr) == 1);
        }

        public int ConvertToInt(string text)
        {
            int[] array = text.Select(x => (int)char.GetNumericValue(x)).ToArray();
            return array.Aggregate((x, y) => x * 10 + y);
        }

        public char MostOccurences(string text)
        {
            return text.OrderByDescending(chr => text.Count(character => character == chr)).First();
        }
    }
}
