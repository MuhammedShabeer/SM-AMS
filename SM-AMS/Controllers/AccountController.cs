using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM_AMS.Models;
using System.Text;
using SM_AMS.Services.Security;
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
        public ActionResult DptRdt(string encryptedUrl)
        {
            // Decrypt the URL
            string decryptedUrl = SMSecurity.DecryptUrl(encryptedUrl);

            // Redirect to the decrypted URL
            return Redirect(decryptedUrl);
        }
    }
}
