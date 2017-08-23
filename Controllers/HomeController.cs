using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using view_models.Models;

namespace view_models.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Home Message.";
            ViewData["Article-1-Heading"] = "Hire a Professional Handyman - Call 12345";
            ViewData["Article-1-Body"] = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.At eam doctus oportere, eam feugait delectus ne. Quo cu vulputate persecuti. Eum ut natum possim comprehensam, habeo dicta scaevola eu nec. Ea adhuc reformidans eam. Pri dolore epicuri eu, ne cum tantas fierent instructior. Pro ridens intellegam ut, sea at graecis scriptorem eloquentiam.";

            ViewData["Article-2-Heading"] = "Furniture Assembly";
            ViewData["Article-2-Body"] = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. At eam doctus oportere, eam feugait delectus ne. Quo cu vulputate persecuti. Eum ut natum possim comprehensam, habeo dicta scaevola eu nec. Ea adhuc reformidans eam.";

            ViewData["Article-3-Heading"] = "Expert Plumbers";
            ViewData["Article-3-Body"] = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. At eam doctus oportere, eam feugait delectus ne. Quo cu vulputate persecuti. Eum ut natum possim comprehensam, habeo dicta scaevola eu nec. Ea adhuc reformidans eam.";

            ViewData["Article-4-Heading"] = "Interior / Exterior Painting";
            ViewData["Article-4-Body"] = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. At eam doctus oportere, eam feugait delectus ne. Quo cu vulputate persecuti. Eum ut natum possim comprehensam, habeo dicta scaevola eu nec. Ea adhuc reformidans eam.";
            return View();
        }

        public IActionResult Pricelist()
        {
            var prices = new List<PriceModel>();

            var serviceOne = new PriceModel
            {
                Service = "Oil Change",
                Info = "Changing your oil",
                Price = "$20"
            };

            var serviceTwo = new PriceModel
            {
                Service = "Tune-up",
                Info = "Tuning up your engine",
                Price = "$30"
            };

            var serviceThree = new PriceModel
            {
                Service = "Mow Lawn",
                Info = "Mowing your lawn",
                Price = "$50"
            };
            prices.Add(serviceOne);
            prices.Add(serviceTwo);
            prices.Add(serviceThree);

            return View(prices);
        }

        [HttpPost]
        public IActionResult References()
        {
            var commentList = new List<ReferenceModel>();
            var firstComment = new ReferenceModel
            {
                Message = "hi there",
                Name = "tom",
                Email = "tom@tomtom.com",
                Website = "tom.com"
            };
            commentList.Add(firstComment);

            using (var reader = new StreamReader(System.IO.File.Open("comments.csv", FileMode.Open)))
                while (reader.Peek() >= 0)
                {
                    var objMessage = string.Empty;
                    var objName = string.Empty;
                    var objEmail = string.Empty;
                    var objWebsite = string.Empty;

                    var user = reader.ReadLine();
                    var data = user.Split(',');
                    for (int i = 0; i < data.Length; i+=4)
                    {
                        objMessage = data[i];
                        objName = data[i+1];
                        objEmail = data[i+2];
                        objWebsite = data[i+3];
                    
                        
                    }
                }
            return View(commentList);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
