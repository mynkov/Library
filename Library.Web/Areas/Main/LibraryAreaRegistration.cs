using System.Web.Mvc;

namespace Library.Web.Areas.Main
{
    public class LibraryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Main";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Main_default",
                "Main/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
