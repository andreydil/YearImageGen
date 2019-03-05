using System;
using NUnit.Framework;
using YearImageGen.Logic.ImageGeneration;

namespace YearImageGen.Tests
{
    public class CalcTests
    {
        [TestCase(4, 1987, 2019, 10)]
        [TestCase(3, 1999, 2019, 10)]
        [TestCase(2, 2001, 2019, 10)]
        [TestCase(1, 2002, 2007, 10)]
        [TestCase(2, -10, 27, 1000)]
        [TestCase(4, -9, 27, 10)]
        [TestCase(3, -6, 12, 10)]
        [TestCase(3, -13, 9, 10)]
        [TestCase(4, -13, 10, 10)]
        [TestCase(4, -13, 12, 10)]
        [TestCase(2, -13, -2, 10)]
        public void CalcLinesNumFromYearsAndWidthTests(int res, int firstYear, int lastYear, int width)
        {
            Assert.AreEqual(res, Calc.LinesNumFromYearsAndWidth(firstYear, lastYear, width));
        }

        [TestCase(5, 0, 1994, 2012, 10, 1995)]
        [TestCase(9, 0, 1994, 2012, 10, 1999)]
        [TestCase(0, 1, 1994, 2012, 10, 2000)]
        [TestCase(0, 2, 1994, 2012, 10, 2010)]
        [TestCase(1, 1, 2000, 2013, 10, 2011)]
        [TestCase(0, 0, -2000, 2013, 100, -2000)]
        [TestCase(1, 0, -2000, 2013, 100, -1999)]
        [TestCase(4, 0, -6, 12, 10, -6)]
        [TestCase(0, 1, -6, 12, 10, 0)]
        [TestCase(2, 2, -6, 12, 10, 12)]
        public void GetCoordForYearTests(int x, int y, int firstYear, int lastYear, int width, int year)
        {
            var coord = Calc.GetCoordForYear(firstYear, lastYear, width, year);
            Assert.AreEqual(x, coord.X);
        }

        [TestCase(true, 2000, 2100, 10, 1999)]
        [TestCase(true, 2000, 2100, 20, 2150)]
        [TestCase(false, 2000, 2100, 8, 2010)]
        public void GetCoordForYearErrorsTests(bool shouldThrow, int firstYear, int lastYear, int width, int year)
        {
            if (shouldThrow)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    Calc.GetCoordForYear(firstYear, lastYear, width, year);
                });
            }
            else
            {
                Calc.GetCoordForYear(firstYear, lastYear, width, year);
            }
        }
    }

}