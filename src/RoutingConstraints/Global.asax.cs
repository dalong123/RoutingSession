using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RoutingSession.Models;

namespace RoutingConstraints
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        #region Code Cleanup
        public static IList<User> DocumentStore { get; set; }

        private static void InitializeDocumentStore()
        {
            DocumentStore = new List<User>();
            DocumentStore.Add(new User
            {
                Username = "Ben"
            });
            DocumentStore.Add(new User
            {
                Username = "Jon"
            });
            DocumentStore.Add(new User
            {
                Username = "Scott"
            });
            DocumentStore.Add(new User
            {
                Username = "Kim"
            });
            DocumentStore.Add(new User
            {
                Username = "Jake"
            });
            DocumentStore.Add(new User
            {
                Username = "Victoria"
            });
            DocumentStore.Add(new User
            {
                Username = "Steve"
            });

        }


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitializeDocumentStore();
        }

        #endregion


        public static void RegisterRoutes(RouteCollection routes)
        {
            RegexRouteConstraint(routes);
            SimpleRouteConstraint(routes);
            DatabaseRouteConstraint(routes);
        }

        #region Database Route Constraint

        private static void DatabaseRouteConstraint(RouteCollection routes)
        {
            // RouteConstraint using a database
            routes.MapRoute(
                "DatabaseConstraint",
                "db/{id}",
                new
                {
                    controller = "Home",
                    action = "Index"
                },
                new
                {
                    id = new DatabaseConstraint()
                }
            );
        }

        #endregion

        #region Simple route constraint

        private static void SimpleRouteConstraint(RouteCollection routes)
        {
            // RouteConstraint by class
            routes.MapRoute(
                "SimpleConstraint",
                "simple/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new
                {
                    id = new SimpleConstraint()
                }
            );
        }

        #endregion

        #region Regex Route Constraint

        private static void RegexRouteConstraint(RouteCollection routes)
        {
            // // A route constraint that only accepts numeric ids
            routes.MapRoute(
                "Constraint",
                "constraint/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { id = "(\\d)+" } // regex, only match digits
            );
        }

        #endregion

    }
}