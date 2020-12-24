using System;
using System.Collections.Generic;
using Xunit;

namespace Enumerable.Facts
{
    public class EnumerableFacts
    {
        [Fact]
        public void AllShouldReturnTrueIfAllElementsMeetTheCondition()
        {
            int[] absNums = { 1, 45, 376 };
            Assert.True(absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldReturnFalseIfAtLeastOneElementDoesntMeetTheCondition()
        {
            int[] absNums = { 1, 45, -376 };
            Assert.False(absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.All(null));
        }

        [Fact]
        public void AnyShouldReturnTrueIfAtLeastOneElementMeetTheCondition()
        {
            int[] absNums = { -1, 45, -376 };
            Assert.True(absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldReturnFalseIfAllElementsDoesntMeetTheCondition()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.False(absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.Any(null));
        }

        [Fact]
        public void FirstShouldReturnFirstElementThatMeetTheCondition()
        {
            int[] absNums = { -1, -45, 376 };
            Assert.True(absNums.First(num => num > 0) == 376);
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfNoneOfTheElementsMeetTheCondition()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.Throws<InvalidOperationException>(() => absNums.First(num => num > 0));
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.First(num => num > 0));
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.Throws<ArgumentNullException>(() => absNums.First(null));
        }

        [Fact]
        public void SelectShouldReturnACollectionWithElementsInNewFormIndicatedBySelector()
        {
            int[] absNums = { -1, -45, -376 };
            IEnumerable<int> newCollection = absNums.Select(num => Math.Abs(num));
            Assert.Equal(new[] { 1, 45, 376 }, newCollection);
        }

        [Fact]
        public void SelectShouldThrowAnExceptionIfSourceCollectionIsNull()
        {
            int[] absNums = null;
            IEnumerable<int> newCollection = absNums.Select(num => Math.Abs(num));
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void SelectManyShouldReturnACollectionWithElementsInNewFormIndicatedBySelector()
        {
            int[][] nums =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 }
            };
            IEnumerable<int> newCollection = nums.SelectMany(num => num);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, newCollection);
        }

        [Fact]
        public void SelectManyShouldThrowAnExceptionIfSourceCollectionIsNull()
        {
            int[][] nums = null;
            IEnumerable<int> newCollection = nums.SelectMany(num => num);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void WhereShouldReturnANewCollectionWithElementThatMeetTheCondition()
        {
            int[] absNums = { 1, -45, 376 };
            IEnumerable<int> newCollection = absNums.Where(num => num > 0);
            Assert.Equal(new[] { 1, 376 }, newCollection);
        }

        [Fact]
        public void WhereShouldShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            IEnumerable<int> newCollection = absNums.Where(num => num > 0);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void WhereShouldShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = { 1, -45, 376 };
            IEnumerable<int> newCollection = absNums.Where(null);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void ToDictionaryShouldReturnADictionaryWithKeysAndValuesAccordingToSelectors()
        {
            int[] absNums = { 1, 2, 3, 4 };
            Dictionary<int, string> dict =
                absNums.ToDictionary(key => key * 2, val => val.ToString());
            Assert.True(dict[2] == "1" && dict[4] == "2"
                && dict[6] == "3" && dict[8] == "4");
        }

        [Fact]
        public void ToDictionaryShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(()
                => absNums.ToDictionary(key => key * 2, val => val.ToString()));
        }

        [Fact]
        public void ZipShouldReturnANewCollectionSameSizeAsShortestContainingFirstAndSecondCollectionsElementsMerged()
        {
            int[] absNums = { 1, 2, 3, 4 };
            string[] strings = { "one", "two", "three" };
            IEnumerable<string> newCollection =
                absNums.Zip(strings, (first, second) => first + " - " + second);
            Assert.Equal(new[] { "1 - one", "2 - two", "3 - three" }, newCollection);
        }

        [Fact]
        public void ZipShouldThrowAnExceptionIfFirstCollectionIsNull()
        {
            int[] first = null;
            string[] second = { "one", "two", "three" };
            IEnumerable<string> newCollection =
                first.Zip(second, (first, second) => first + " - " + second);
            Assert.Throws<ArgumentNullException>(()
                => newCollection.All(predicate => predicate != null));
        }

        [Fact]
        public void ZipShouldThrowAnExceptionIfSecondCollectionIsNull()
        {
            int[] first = { 1, 2, 3, 4 };
            string[] second = null;
            IEnumerable<string> newCollection =
                first.Zip(second, (first, second) => first + " - " + second);
            Assert.Throws<ArgumentNullException>(()
                => newCollection.All(predicate => predicate != null));
        }

        [Fact]
        public void AggregateShouldApplyAccumulatorFuncOverEachElementInTheCollectionAndReturnTheResult()
        {
            int[] absNums = { 1, 2, 3, 4 };
            var result = absNums.Aggregate(0, (sum, current) => sum + current);
            Assert.Equal(10, result);
        }

        [Fact]
        public void AggregateShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(()
                => absNums.Aggregate(0, (sum, current) => sum + current));
        }

        [Fact]
        public void AggregateShouldThrowAnExceptionIfFuncIsNull()
        {
            int[] absNums = { 1, 2, 3, 4 };
            Assert.Throws<ArgumentNullException>(()
                => absNums.Aggregate(0, null));
        }
    }
}