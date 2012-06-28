using System.Web;
using System.Web.Routing;

namespace RoutingConstraints
{
    public class SimpleConstraint : IRouteConstraint
    {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string value = (string)values[parameterName];

            return value == "match";
        }

    }
}