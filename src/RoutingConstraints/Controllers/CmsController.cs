using System.Web.Mvc;

namespace RoutingSession.Controllers
{
    public class CmsController : Controller
    {
        //
        // GET: /Cmd/

        public ActionResult Article(string item, string title)
        {
            return View(new DefaultViewModel {Id = item, Title = title});
        }

    }
}
