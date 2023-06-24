using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM_AMS.Models;
using SM_AMS.Services.UserAdmin;

namespace SM_AMS.Controllers
{
    public class UserManagment : Controller
    {
        UserManagmentServices _services = new UserManagmentServices();
        // GET: UserManagment
        public ActionResult Index()
        {
            return View(_services.GetUsers());
        }

        // GET: UserManagment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserManagment/Create
        public ActionResult Create()
        {
            UserManagmentModel model = new UserManagmentModel();
            return View(model);
        }

        // POST: UserManagment/Create
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

        // GET: UserManagment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
