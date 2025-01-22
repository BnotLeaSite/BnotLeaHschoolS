using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BnotLeaHschool.Pages
{
    public class GalleryModel : PageModel
    {
        private static readonly Random random = new Random();
        private const int NumberOfImagesToShow = 5;

        [HttpGet]
        public JsonResult OnGetGetRandomImages()
        {
            var imagesPath = Path.Combine(Environment.CurrentDirectory, "wwwroot/images");
            var allImages = Directory.GetFiles(imagesPath)
                                     .Select(img => $"/images/{Path.GetFileName(img)}")
                                     .ToList();

            var randomImages = allImages.OrderBy(x => random.Next()).Take(NumberOfImagesToShow).ToList();

            return new JsonResult(randomImages);
        }
    }
}
