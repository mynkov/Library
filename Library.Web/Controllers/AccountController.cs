using System.Web.Mvc;
using System.Web.Security;
using Library.BusinessLayer.Repositories;
using Library.Web.Models.Account;

namespace Library.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //
        // GET: /Account/Login

        public virtual ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        public virtual ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_usersRepository.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Logout

        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
        }

        //
        // GET: /Account/Register

        public virtual ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public virtual ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus status;
                _usersRepository.Create(model.UserName, model.Password, model.Email, out status);
                if (status == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
                }
                ModelState.AddModelError("", ErrorCodeToString(status));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
