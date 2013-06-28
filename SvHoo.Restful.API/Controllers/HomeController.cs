using SvHoo.Restful.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SvHoo.Restful.API.Controllers
{
    class Pro
    {
        public string Title { get; set; }
    }
    public class HomeController : RestController
    {
        public ActionResult Index()
        {
            return View(new Pro() { Title = "title" });
        }
    }
}
