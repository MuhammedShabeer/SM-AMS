using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM_AMS.Models;

namespace SM_AMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            var Branches = new List<BranchModel>();
            Branches.Add(new BranchModel { Id = 1, code = "A", Name = "Algiers" });
            Branches.Add(new BranchModel { Id = 2, code = "O", Name = "Oran" });
            Branches.Add(new BranchModel { Id = 3, code = "C", Name = "Constantine" });
            SelectList BranchesList = new SelectList(Branches, "Id", "Name");
            ViewBag.BranchesList = BranchesList;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // If successful, redirect to the desired page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If validation fails, redisplay the login form with error messages
                return View(model);
            }
        }

    }
}
