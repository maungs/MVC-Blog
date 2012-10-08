using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcBlog.Models;
using System.Web.Security;
using System.Data;
namespace mvcBlog.Controllers
{
    public class ControlPanelController : Controller
    {

        private UsersContext db = new UsersContext();
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            UpdateSuccess
        }
        //
        // GET: /ControlPanel/

        [Authorize(Roles = "Administrator,Blogger,Reader")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/UserAdministration
        [Authorize(Roles = "Administrator")]
        public ActionResult UserAdministration(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "User password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "User password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.UpdateSuccess ? "User account details updated successfully."
                : "";
            return View(db.UserProfiles.ToList());
        }
        // GET: /Account/UserAdministration
        [Authorize(Roles = "Administrator")]
        public ActionResult EditUser(int id=0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            UserProfileWithRolesModel viewitem = new UserProfileWithRolesModel { UserId = userprofile.UserId,UserName = userprofile.UserName,FirstName = userprofile.FirstName,
                                                                                 LastName = userprofile.LastName, EMail = userprofile.EMail, isActive = userprofile.isActive,
                                                                                 Twitter = userprofile.Twitter, Facebook = userprofile.Facebook, WebSite = userprofile.WebSite,
                                                                                 Roles = Roles.GetRolesForUser(userprofile.UserName)
                                                                                };
            ViewBag.SystemRoles= Roles.GetAllRoles();
            ViewBag.Roles = viewitem.Roles;
            return View(viewitem);
        }
        // Post: /Account/UserAdministration
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditUser(UserProfileWithRolesModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfile userprofile = new UserProfile{  UserId = model.UserId, UserName = model.UserName, FirstName = model.FirstName,
                                                            LastName = model.LastName, EMail = model.EMail, isActive = model.isActive,
                                                            Twitter = model.Twitter, Facebook = model.Facebook, WebSite = model.WebSite};
                string[] roles = Roles.GetRolesForUser(model.UserName);
                if(roles.Length>0)
                    Roles.RemoveUserFromRoles(model.UserName, roles);
                if(model.Roles!= null && model.Roles.Length>0)
                    Roles.AddUserToRoles(model.UserName, model.Roles);
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserAdministration", new { Message = ManageMessageId.UpdateSuccess });
            }
            return View();
        }

    }
}
