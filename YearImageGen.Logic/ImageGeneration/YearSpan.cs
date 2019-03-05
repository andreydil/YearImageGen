using System;
using SixLabors.ImageSharp.PixelFormats;

namespace YearImageGen.Logic.ImageGeneration
{
    public class YearSpan
    {
        private int _firstYear;
        private int _lastYear;

        public int FirstYear
        {
            get => _firstYear;
            set
            {
                if (value > _lastYear)
                {
                    _lastYear = value;
                }

                _firstYear = value;
            }
        }

        public int LastYear
        {
            get => _lastYear;
            set
            {
                if (value < _firstYear)
                {
                    _firstYear = value;
                }

                _lastYear = value;
            }
        }

        public Rgba32 Color { get; set; }
    }
}
