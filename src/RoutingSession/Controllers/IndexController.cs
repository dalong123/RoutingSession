using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingSession.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

    }
}
