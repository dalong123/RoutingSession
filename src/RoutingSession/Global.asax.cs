using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RoutingSession.Models;

namespace RoutingSession
{
    public class MvcApplication : HttpApplication
    {
        #region Cleaner code

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }

        #endregion

        public static void RegisterRoutes(RouteCollection routes)
        {
            DontRouteExistingFiles(routes);
            WildcardRouting(routes);
            IgnoringARoute(routes);
            DefaultRoute(routes);
            OrderingARoute(routes);
        }

        #region Default Route

        private static void DefaultRoute(RouteCollection routes)
        {
            // this is the default route
            routes.MapRoute(
                "Default", //  Route name - how is this used?
                // http:// www.somesite.com/en/controller/action/id/some-more/seo-keywords/for-search
                @"{controller}/{action}/{id}", //  URL with parameters - what are each of the parameters
                // items contained within {} are considered named segments
                // items without {} are literals and must exist to be processed

                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } //  Parameter defaults
                // default values for when none are specified
            );
        }

        private static void OrderingARoute(RouteCollection routes)
        {
            routes.MapRoute(
                "OutOfOrderRoute",
                @"home/outoforder",
                new
                {
                    controller = "Home",
                    action = "Default"
                }
            );
        }

        #endregion

        #region Route that will never match

        private static void NeverMatchRoute(RouteCollection routes)
        {
            // This route will never match
            routes.MapRoute(
                "ThisRouteWillNeverMatch",
                "sampleRoute/willNeverMatch",
                new
                {
                    controller = "sampleRoute",
                    action = "youshouldntseethis"
                }
                );
        }

        #endregion

        #region Ignoring a route

        private static void IgnoringARoute(RouteCollection routes)
        {
            routes.IgnoreRoute("ignore/{*wildcard}");
        }

        #endregion

        #region Wildcard routing

        private static void WildcardRouting(RouteCollection routes)
        {
            // Wildcard routing match
            routes.MapRoute(
                "Article",
                "article/{item}/{*title}",
                new
                {
                    controller = "Cms",
                    action = "Article",
                });
        }

        #endregion

        #region Don't route existing files
        private static void DontRouteExistingFiles(RouteCollection routes)
        {
            // This route will be ignored
            routes.RouteExistingFiles = false;
        }
        #endregion
    }
}