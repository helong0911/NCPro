using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SvHoo.UI.Merchant.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var product = new Product()
            {
                Title = "xxxxxxx"
            };
            ViewBag.Title = "xxx";
            ViewBag.List = new List<int>();
            return View(product);
        }

    }
}
