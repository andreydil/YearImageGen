using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YearImageGen.Logic.ImageGeneration;
using YearImageGen.Web.Models;

namespace YearImageGen.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ImageSettingsModel
            {
                FirstYear = -2000,
                LastYear = 2099,
                Width = 100,
                BackGroundColor = "#ffffff",
                DrawnYearsColor = "#d4d4d4",
                ZeroYearColor = "000000",
                MarkedYears = new List<YearSpanModel>
                {
                    new YearSpanModel
                    {
                        FirstYear = 1900,
                        LastYear = 1999,
                        Color = "#00ff00",
                    }
                },
            });
        }

        [HttpPost]
        public IActionResult Index(ImageSettingsModel model)
        {
            var generator = new ImageGenerator();
            var outStream = new MemoryStream();

            /*var settings = new ImageSettings
            {
                FirstYear = 1900,
                LastYear = 2099,
                ZeroYearColor = Rgba32.Black,
                DrawnYearsColor = Rgba32.White,
                BackGroundColor = Rgba32.LightGray,
                Width = 10,
                MarkedYears = new[]
                {
                    new YearSpan
                    {
                        FirstYear = 1970,
                        LastYear = 2019,
                        Color = Rgba32.Red,
                    }
                },
            };*/
            try
            {
                generator.GenerateImage(model.ToImageSettings(), outStream);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Index", model);
            }

            outStream.Seek(0, SeekOrigin.Begin);
            return File(outStream, "image/png", "YearImage.png");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
