using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace RoutingSession.Controllers
{

    public class DefaultViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
    }

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string id)
        {
            return View(new DefaultViewModel { Id = id });
        }

        [Route("user/{id}/{*userName}")]
        public new ActionResult User(string id, string userName)
        {
            return View(new DefaultViewModel { Id = id, Username = userName });
        }

        public ActionResult NewRoute()
        {
            return View();
        }

        public ActionResult Article(string item, string title)
        {
            return View(new DefaultViewModel { Id = item, Title = title });
        }

        public ActionResult OutOfOrder()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }
    }
}












































