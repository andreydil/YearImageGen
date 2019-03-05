using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace YearImageGen.Logic.ImageGeneration
{
    public class ImageGenerator
    {
        public void GenerateImage(ImageSettings settings, Stream outStream)
        {
            settings.EnsureValid();

            var height = Calc.LinesNumFromYearsAndWidth(settings.FirstYear, settings.LastYear, settings.Width);
            using (var image = new Image<Rgba32>(settings.Width, height))
            {
                //background
                image.Mutate(i => i.BackgroundColor(settings.BackGroundColor));

                //selected years
                for (int y = settings.FirstYear; y <= settings.LastYear; ++y)
                {
                    var coord = Calc.GetCoordForYear(settings.FirstYear, settings.LastYear, settings.Width, y);
                    image[coord.X, coord.Y] = settings.DrawnYearsColor;
                }

                //marked years
                foreach (var yearSpan in settings.MarkedYears)
                {
                    for (int y = yearSpan.FirstYear; y <= yearSpan.LastYear; ++y)
                    {
                        var coord = Calc.GetCoordForYear(settings.FirstYear, settings.LastYear, settings.Width, y);
                        image[coord.X, coord.Y] = yearSpan.Color;
                    }
                }

                //mark zero year
                if (settings.FirstYear <= 0 && 0 <= settings.LastYear)
                {
                    var zeroYearCoord = Calc.GetCoordForYear(settings.FirstYear, settings.LastYear, settings.Width, 0);
                    image[zeroYearCoord.X, zeroYearCoord.Y] = settings.ZeroYearColor;
                }

                image.SaveAsPng(outStream);
            }
        }
    }
}
