using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using YearImageGen.Logic.ImageGeneration;

namespace YearImageGen.Tests
{
    public class YearSpanTests
    {
        [Test]
        public void LastYearGreaterThanFirstYearTest()
        {
            var yearSpan = new YearSpan();
            yearSpan.LastYear = 5;
            Assert.AreEqual(5, yearSpan.LastYear);

            yearSpan.FirstYear = 3;
            Assert.AreEqual(3, yearSpan.FirstYear);
            Assert.AreEqual(5, yearSpan.LastYear);

            yearSpan.FirstYear = 10;
            Assert.AreEqual(10, yearSpan.FirstYear);
            Assert.AreEqual(10, yearSpan.LastYear);

            yearSpan.LastYear = -90;
            Assert.AreEqual(-90, yearSpan.FirstYear);
            Assert.AreEqual(-90, yearSpan.LastYear);
        }
    }
}
