using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingWithWebForms {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            WebFormsRoute(routes);
        }

        #region Webforms routing

        private static void WebFormsRoute(RouteCollection routes) {
            // Routing to a webforms page
            routes.MapPageRoute(
                "WebFormsRoute",
                "samplewebformspage.html",
                "~/samplewebformspage.aspx", // must be to the page and not include querystring parameters
                false,
                new RouteValueDictionary { { "id", "this-is-an-id" } }
            );
        }

        #endregion

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}