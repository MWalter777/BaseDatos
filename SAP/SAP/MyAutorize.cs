using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAP
{
    public class MyAutorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            System.Web.Routing.RouteValueDictionary rd;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                String user = filterContext.HttpContext.User.Identity.Name;
                System.Console.WriteLine(user);
                rd = new System.Web.Routing.RouteValueDictionary(new { action = "About", controller = "Home" });
            }
            else
            {
                String user = filterContext.HttpContext.User.Identity.Name;
                System.Console.WriteLine(user);
                //user is not authenticated
                rd = new System.Web.Routing.RouteValueDictionary(new { action = "NotAuthorized", controller = "Home" });
            }
            filterContext.Result = new RedirectToRouteResult(rd);
        }
    }
}