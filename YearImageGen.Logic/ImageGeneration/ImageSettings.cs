using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp.PixelFormats;

namespace YearImageGen.Logic.ImageGeneration
{
    public class ImageSettings
    {
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public int Width { get; set; }
        public Rgba32 BackGroundColor { get; set; }
        public Rgba32 DrawnYearsColor { get; set; }
        public Rgba32 ZeroYearColor { get; set; }
        public IReadOnlyCollection<YearSpan> MarkedYears { get; set; }

        public ImageSettings()
        {
            Width = 100;
        }

        public void EnsureValid()
        {
            if (FirstYear > LastYear)
            {
                throw new ArgumentException($"First year must be less than or equal to Last year ({FirstYear} > {LastYear})");
            }

            if (Width <= 0)
            {
                throw new ArgumentException($"Width must be more than zero (got {Width})");
            }

            if (MarkedYears != null)
            {
                foreach (var yearSpan in MarkedYears)
                {
                    var intersectingYearSpan = MarkedYears.FirstOrDefault(ys =>
                        ys.FirstYear <= yearSpan.LastYear && ys.LastYear >= yearSpan.FirstYear && ys.FirstYear != yearSpan.FirstYear);
                    if (intersectingYearSpan != null)
                    {
                        throw new ArgumentException(
                            $"Year span '{yearSpan.FirstYear} - {yearSpan.LastYear}' intersects with year span '{intersectingYearSpan.FirstYear} - {intersectingYearSpan.LastYear}'");
                    }
                }
            }
        }
    }
}
