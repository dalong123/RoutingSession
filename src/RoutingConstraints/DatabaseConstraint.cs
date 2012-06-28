using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using RoutingSession.Models;

namespace RoutingConstraints
{
    public class DatabaseConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
                string name = (string)values[parameterName];
                return MvcApplication.DocumentStore.Any(u => u.Username.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}