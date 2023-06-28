using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM_AMS.Models;
using SM_AMS.Services.UserAdmin;

namespace SM_AMS.Controllers
{
    public class UserManagment : Controller
    {
        UserManagmentServices _services = new UserManagmentServices();
        public ActionResult Index()
        {
            return View(_services.GetUsers());
        }
        public ActionResult Create()
        {
            ViewData["Title"] = "Create user";
            return View(new UserManagmentModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserManagmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _services.SaveUsers(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit user";
            UserManagmentModel model = _services.GetUsers(id)[0];
            return View("Create", model);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _services.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
