using Microsoft.AspNetCore.Mvc;
using SM_AMS.Models;
using SM_AMS.Services;
using SM_AMS.Services.UserAdmin;

namespace SM_AMS.Controllers
{
    public class BranchController : Controller
    {
        BranchMasterServices _services = new BranchMasterServices();
        public ActionResult Index()
        {
            return View(_services.GetBranches());
        }
        public ActionResult Create()
        {
            ViewData["Title"] = "Create Branch";
            return View(new BranchModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BranchModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _services.SaveBranch(model);
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
            ViewData["Title"] = "Edit branch";
            BranchModel model = _services.GetBranches(id)[0];
            return View("Create", model);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _services.DeleteBranch(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
