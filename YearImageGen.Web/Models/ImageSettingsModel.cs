using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;
using YearImageGen.Logic.ImageGeneration;

namespace YearImageGen.Web.Models
{
    public class ImageSettingsModel
    {
        public string Error { get; set; }

        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public int Width { get; set; }
        public string BackGroundColor { get; set; }
        public string DrawnYearsColor { get; set; }
        public string ZeroYearColor { get; set; }
        public IList<YearSpanModel> MarkedYears { get; set; }

        public ImageSettings ToImageSettings()
        {
            return new ImageSettings{
                FirstYear = FirstYear,
                LastYear = LastYear,
                Width = Width,
                BackGroundColor = Rgba32.FromHex(BackGroundColor),
                DrawnYearsColor = Rgba32.FromHex(DrawnYearsColor),
                ZeroYearColor = Rgba32.FromHex(ZeroYearColor),
                MarkedYears = MarkedYears == null? new YearSpan[0]: MarkedYears.Select(y => new YearSpan
                {
                    FirstYear = y.FirstYear,
                    LastYear = y.LastYear,
                    Color = Rgba32.FromHex(y.Color),
                }).ToArray(),
            };
        }
    }

    public class YearSpanModel
    {
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public string Color { get; set; }
    }
}
