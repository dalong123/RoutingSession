using System.Web.Mvc;

namespace RoutingSession.Controllers
{
    public class SampleRouteController : Controller
    {
        //
        // GET: /SampleRoute/

        public ActionResult Index()
        {
            
            return new ContentResult
            {
                Content = "SampelRoute Controller"
            };
        }

        public ActionResult YouShouldntSeeThis()
        {
            return new ContentResult
            {
                Content = "SampleRoute Controller"
            };
        }

    }
}
