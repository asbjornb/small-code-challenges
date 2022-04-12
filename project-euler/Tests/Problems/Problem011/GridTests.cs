using NUnit.Framework;
using project_euler.Problems.ConcreteProblems.Problem011Model;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Problem011Tests
{
    [TestFixture]
    internal class GridTests
    {
        [Test]
        [TestCaseSource(nameof(GetTestObjects))]
        public void ShouldReturnRows(TestObject test)
        {
            var sut = new Grid(test.Grid);

            var result = sut.GetRows().ToList();

            result.Count.ShouldBe(test.Rows.Count);
            result.ShouldBe(test.Rows, true);
        }

        [Test]
        [TestCaseSource(nameof(GetTestObjects))]
        public void ShouldReturnCols(TestObject test)
        {
            var sut = new Grid(test.Grid);

            var result = sut.GetCols().ToList();

            result.Count.ShouldBe(test.Cols.Count);
            result.ShouldBe(test.Cols, true);
        }

        [Test]
        [TestCaseSource(nameof(GetTestObjects))]
        public void ShouldReturnRightDiagonals(TestObject test)
        {
            var sut = new Grid(test.Grid);

            var result = sut.GetRightDiagonals().ToList();

            result.ShouldBe(test.RightDiagonals, true);
        }

        [Test]
        [TestCaseSource(nameof(GetTestObjects))]
        public void ShouldReturnLeftDiagonals(TestObject test)
        {
            var sut = new Grid(test.Grid);

            var result = sut.GetLeftDiagonals().ToList();

            result.ShouldBe(test.LeftDiagonals, true);
        }

        private static readonly int[][] testArray1 =
        {
            new int[] {1, 2},
            new int[] {11, 34},
        };

        private static readonly int[][] testArray2 =
        {
            new int[] {1, 2, 3, 4},
            new int[] {11, 34, 67, 2 },
            new int[] {89, 23, 2, 8 },
            new int[] {0, 45, 78, 99 }
        };

        public static IEnumerable<TestObject> GetTestObjects()
        {
            yield return new TestObject(testArray1
                , new List<int[]>() {
                    new int[] { 1, 2 },
                    new int[] { 11, 34 }
                }
                , new List<int[]>() {
                    new int[] { 1, 11 },
                    new int[] { 2, 34 }
                }
                , new List<int[]>() {
                    new int[] { 1 },
                    new int[] { 11, 2 },
                    new int[] { 34 }
                }
                , new List<int[]>() {
                    new int[] { 11 },
                    new int[] { 1, 34 },
                    new int[] { 2 }
                }
                );
            yield return new TestObject(testArray2
                , new List<int[]>() {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 11, 34, 67, 2 },
                    new int[] { 89, 23, 2, 8 },
                    new int[] { 0, 45, 78, 99 }
                }
                , new List<int[]>() {
                    new int[] { 1, 11, 89, 0 },
                    new int[] { 2, 34, 23, 45 },
                    new int[] { 3, 67, 2, 78 },
                    new int[] { 4, 2, 8, 99 }
                }
                , new List<int[]>() {
                    new int[] { 1 },
                    new int[] { 11, 2 },
                    new int[] { 89, 34, 3 },
                    new int[] { 0, 23, 67, 4 },
                    new int[] { 45, 2, 2 },
                    new int[] { 78, 8 },
                    new int[] { 99 }
                }
                , new List<int[]>() {
                    new int[] { 0 },
                    new int[] { 89, 45 },
                    new int[] { 11, 23, 78 },
                    new int[] { 1, 34, 2, 99 },
                    new int[] { 2, 67, 8 },
                    new int[] { 3, 2 },
                    new int[] { 4 },
                }
                );
        }

        public class TestObject
        {
            public int[][] Grid { get; set; }
            public List<int[]> Rows { get; set; }
            public List<int[]> Cols { get; set; }
            public List<int[]> RightDiagonals { get; set; }
            public List<int[]> LeftDiagonals { get; set; }

            public TestObject(int[][] grid, List<int[]> rows, List<int[]> cols, List<int[]> rightDiagonals, List<int[]> leftDiagonals)
            {
                Grid = grid;
                Rows = rows;
                Cols = cols;
                RightDiagonals = rightDiagonals;
                LeftDiagonals = leftDiagonals;
            }
        }
    }
}
