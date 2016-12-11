#region

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace LinqTocnblogs {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Posts.svc/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Post", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}