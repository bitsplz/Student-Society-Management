using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test3
{
    public class CustomAuth : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Error/Unauthorized");
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}