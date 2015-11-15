using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Metricaencuesta.Utils
{
    public class SessionValidator : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            if (ctx.Session != null)
            {
                // check if a new session id was generated
                if (ctx.Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must
                    // have timed out
                    string sessionCookie = ctx.Request.Headers["Cookie"];
                    if (null == sessionCookie)
                    {
                        FormsAuthentication.SignOut();

                        const string loginUrl = @"~/login/auth";
                        var rr = new RedirectResult(loginUrl);
                        filterContext.Result = rr;


                    }
                    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") <= 0))
                    {
                        FormsAuthentication.SignOut();
                        const string loginUrl = @"~/login/auth";
                        var rr = new RedirectResult(loginUrl);
                        filterContext.Result = rr;
                    }
                }
                else if (ctx.Session["usuario"] == null)
                {
                    const string loginUrl = @"~/login/auth";
                    var rr = new RedirectResult(loginUrl);
                    filterContext.Result = rr;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
