using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringNetMvc.Controllers
{
    using SpringNetMvc.Models;

    public class HomeController : Controller
    {
        public IHello Hello { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = Hello.HelloWord();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的应用程序说明页。";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你的联系方式页。";

            return View();
        }
    }
}
