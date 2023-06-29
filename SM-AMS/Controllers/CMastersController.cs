using Microsoft.AspNetCore.Mvc;
using SM_AMS.Models;
using SM_AMS.Services.UserAdmin;
using static SM_AMS.Models.EnumModel;
namespace SM_AMS.Controllers
{
    public class CMastersController : Controller
    {
        CMastersServices _services = new CMastersServices();
        public ActionResult Index(int CMasters)
        {
            ViewBag.CMasters = CMasters;
            return View(_services.GetCMasters((enmCMasters)CMasters));
        }
        public ActionResult Create(int CMasters)
        {
            enmCMasters eCMasters = (enmCMasters)CMasters;
            ViewBag.CMasters = CMasters;
            ViewData["Title"] = $"Create {eCMasters}";
            return View(new CMastersModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CMastersModel model, int CMasters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _services.SaveCMasters((enmCMasters)CMasters,model);
                    return RedirectToAction("Index", new { @CMasters = CMasters });
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
        public ActionResult Edit(int id, int CMasters)
        {
            enmCMasters eCMasters = (enmCMasters)CMasters;
            ViewBag.CMasters = CMasters;
            ViewData["Title"] = $"Edit {eCMasters}";
            CMastersModel model = _services.GetCMasters((enmCMasters)CMasters,id)[0];
            return View("Create", model);
        }
        public ActionResult Delete(int id, int CMasters)
        {
            try
            {
                _services.DeleteCMasters((enmCMasters)CMasters,id);
                return RedirectToAction("Index", new { @CMasters = CMasters});
            }
            catch
            {
                return View();
            }
        }
    }
}
