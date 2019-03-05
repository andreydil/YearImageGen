using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using YearImageGen.Logic.ImageGeneration;

namespace YearImageGen.Tests
{
    public class ImageSettingsTests
    {
        [Test]
        public void YearsValidationCorrectDataTest()
        {
            var goodSettings = new ImageSettings
            {
                FirstYear = 2010,
                LastYear = 2011,
            };
            goodSettings.EnsureValid();
        }

        [Test]
        public void YearsValidationIncorrectDataTest()
        {
            var badSettings = new ImageSettings
            {
                FirstYear = 2010,
                LastYear = 2009,
            };
            Assert.Throws<ArgumentException>(() => { badSettings.EnsureValid(); });
        }

        [Test]
        public void WidthValidationCorrectDataTest()
        {
            var goodSettings = new ImageSettings
            {
                Width = 10,
            };
            goodSettings.EnsureValid();
        }

        [Test]
        public void WidthValidationIncorrectDataTest()
        {
            var badSettings = new ImageSettings
            {
                Width = 0,
            };
            Assert.Throws<ArgumentException>(() => { badSettings.EnsureValid(); });
        }

        [Test]
        public void YearSpansValidationCorrectDataTest()
        {
            var goodSettings = new ImageSettings
            {
                MarkedYears = new[]
                {
                    new YearSpan
                    {
                        FirstYear = 2000,
                        LastYear = 2005,
                    },
                    new YearSpan
                    {
                        FirstYear = 2006,
                        LastYear = 2010,
                    },
                },
            };
            goodSettings.EnsureValid();
        }

        [Test]
        public void YearSpansValidationIncorrectDataTest()
        {
            var badSettings = new ImageSettings
            {
                MarkedYears = new[]
                {
                    new YearSpan
                    {
                        FirstYear = 2000,
                        LastYear = 2005,
                    },
                    new YearSpan
                    {
                        FirstYear = 2005,
                        LastYear = 2010,
                    },
                },
            };
            Assert.Throws<ArgumentException>(() => { badSettings.EnsureValid(); });
        }
    }
}
