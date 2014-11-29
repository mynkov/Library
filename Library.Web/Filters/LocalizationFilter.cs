using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Library.Web.Filters
{
    public class LocalizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cultureCookie = filterContext.RequestContext.HttpContext.Request.Cookies["culture"];
            if (cultureCookie != null)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCookie.Value);
        }
    }
}