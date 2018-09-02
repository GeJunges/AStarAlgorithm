using System.Collections.Generic;
using Algorithms.TwoDimensionalMap;
using NUnit.Framework;

namespace Algorithms.UnitTests.TwoDimensionalMap {
    public class FindOutHowToGetOutTests {

        public FindOutHowToGetOut _findOut;

        [SetUp]
        public void SetUp() {
            _findOut = new FindOutHowToGetOut();
        }

        [TestCaseSource(nameof(GetMatrix))]
        public void CalculateStepsNumber_should_return_a_minimum_number_of_steps_required(int[][] map, int expected) {
            var actual = _findOut.CalculateStepsNumber(map);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object> GetMatrix() {
            yield return new TestCaseData(CreateJaggedArray1(), 18);
            yield return new TestCaseData(CreateJaggedArray2(), 19);
            yield return new TestCaseData(CreateJaggedArray3(), 14);
        }

        private static int[][] CreateJaggedArray1() {
            return new int[][]{
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
        }

        private static int[][] CreateJaggedArray2() {
            return new int[][]{
                new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new int[] { 0, 1, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0},
                new int[] { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                new int[] { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
        }

        private static int[][] CreateJaggedArray3() {
            return new int[][]{
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 3, 0},
                new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0},
                new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
        }
    }
}
