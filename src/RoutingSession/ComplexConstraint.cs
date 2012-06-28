using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using RoutingSession.Models;

namespace RoutingSession
{
    public class ComplexConstraint : IRouteConstraint
    {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string value = (string)values[parameterName];

            return value == "match";
        }

    }

    public class DatabaseConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            using (var session = MvcApplication.DocumentStore.OpenSession()) {
                string name = (string) values[parameterName];
                return session.Query<User>().Any(u => u.Username.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}