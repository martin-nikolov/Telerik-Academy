namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Web.ViewModels;

    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
        }

        public ManageController(UserManager userManager)
        {
            this.UserManager = userManager;
        }

        private UserManager _userManager;

        public UserManager UserManager
        {
            get
            {
                return this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                this._userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage =
                                        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                                        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                                          : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                                            : message == ManageMessageId.Error ? "An error has occurred."
                                              : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                                                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                                                  : "";

            var model = new IndexViewModel
            {
                HasPassword = this.HasPassword(),
                PhoneNumber = await this.UserManager.GetPhoneNumberAsync(this.User.Identity.GetUserId()),
                TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(this.User.Identity.GetUserId()),
                Logins = await this.UserManager.GetLoginsAsync(this.User.Identity.GetUserId()),
                BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(this.User.Identity.GetUserId())
            };
            return this.View(model);
        }

        //
        // GET: /Manage/RemoveLogin
        public ActionResult RemoveLogin()
        {
            var linkedAccounts = this.UserManager.GetLogins(this.User.Identity.GetUserId());
            this.ViewBag.ShowRemoveButton = this.HasPassword() || linkedAccounts.Count > 1;
            return this.View(linkedAccounts);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await this.UserManager.RemoveLoginAsync(this.User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInAsync(user, isPersistent: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return this.RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return this.View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            // Generate the token and send it
            var code = await this.UserManager.GenerateChangePhoneNumberTokenAsync(this.User.Identity.GetUserId(), model.Number);
            if (this.UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await this.UserManager.SmsService.SendAsync(message);
            }
            return this.RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), true);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInAsync(user, isPersistent: false);
            }
            return this.RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), false);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInAsync(user, isPersistent: false);
            }
            return this.RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await this.UserManager.GenerateChangePhoneNumberTokenAsync(this.User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? this.View("Error") : this.View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var result = await this.UserManager.ChangePhoneNumberAsync(this.User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInAsync(user, isPersistent: false);
                }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Failed to verify phone");
            return this.View(model);
        }

        //
        // GET: /Manage/RemovePhoneNumber
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await this.UserManager.SetPhoneNumberAsync(this.User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return this.RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInAsync(user, isPersistent: false);
            }
            return this.RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInAsync(user, isPersistent: false);
                }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            this.AddErrors(result);
            return this.View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return this.View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                    if (user != null)
                    {
                        await this.SignInAsync(user, isPersistent: false);
                    }
                    return this.RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage =
                                        message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                                        : message == ManageMessageId.Error ? "An error has occurred."
                                          : "";
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user == null)
            {
                return this.View("Error");
            }
            var userLogins = await this.UserManager.GetLoginsAsync(this.User.Identity.GetUserId());
            var otherLogins = this.AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            this.ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return this.View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, this.Url.Action("LinkLoginCallback", "Manage"), this.User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, this.User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await this.UserManager.AddLoginAsync(this.User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? this.RedirectToAction("ManageLogins") : this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        #region Helpers
        
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";
        
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }
        
        private async Task SignInAsync(User user, bool isPersistent)
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            this.AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(this.UserManager));
        }
        
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }
        
        private bool HasPassword()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        
        private bool HasPhoneNumber()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }
        
        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
        
        #endregion
    }
}