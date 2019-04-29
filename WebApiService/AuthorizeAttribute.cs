using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApiService
{
    public class MyAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                var CurrentRole = this.Roles.Split(',').Last();
                //actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Forbidden, "ليس لديك الصلاحية لتنفيذ هذا الاجراء");
                UnauthorizedAccess.WarningEmail(HttpContext.Current.User.Identity, CurrentRole);
            }
        }
    }
}