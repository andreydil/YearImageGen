using System;
namespace YearImageGen.Logic.ImageGeneration
{
    public static class Calc
    {
        public static int LinesNumFromYearsAndWidth(int firstYear, int lastYear, int width)
        {
            var totalLength = lastYear - firstYear + 1;
            int firstNotFullLineYears;
            if (firstYear < 0)
            {
                firstNotFullLineYears = Math.Abs(firstYear % width);
            }
            else
            {
                firstNotFullLineYears = width - Math.Abs(firstYear % width);
            }

            int lastNotFullLineYears = Math.Abs(lastYear % width) + 1;
            if (lastNotFullLineYears == width)
            {
                lastNotFullLineYears = 0;
            }

            var numOfFullLines = (totalLength - firstNotFullLineYears - lastNotFullLineYears) / width;
            var totalLines = numOfFullLines;
            if (firstNotFullLineYears > 0)
            {
                ++totalLines;
            }

            if (lastNotFullLineYears > 0)
            {
                ++totalLines;
            }

            return totalLines;
        }

        public static Coord GetCoordForYear(int firstYear, int lastYear, int width, int year)
        {
            if (year < firstYear)
            {
                throw new ArgumentOutOfRangeException(nameof(year), $"Year ({year}) cannot be less than firstYear ({firstYear})");
            }

            if (year > lastYear)
            {
                throw new ArgumentOutOfRangeException(nameof(year), $"Year ({year}) cannot be greater than lastYear ({firstYear})");
            }

            int x;
            if (year < 0)
            {
                x = width + year % width;
            }
            else
            {
                x = year % width;
            }
            if (x == width)
            {
                x = 0;
            }

            var firstNotFullLineYears = Math.Abs(firstYear % width);
            var y = (year - firstYear) / width;
            if (firstNotFullLineYears > 0)
            {
                ++y;
            }

            return new Coord(x, y);
        }
    }
}
