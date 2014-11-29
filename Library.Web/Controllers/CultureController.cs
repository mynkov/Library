using System.Web;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public partial class CultureController : Controller
    {
        //
        // POST: /ChangeCulture/
        [HttpPost]
        public virtual ActionResult ChangeCulture(string culture)
        {
            Response.Cookies.Add(new HttpCookie("culture", culture));
            return new EmptyResult();
        }
    }
}
