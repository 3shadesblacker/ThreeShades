using I_did_those.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace I_did_those.Controllers
{
    [Route("Duties")]
    public class DutyController : Controller
    {
        [HttpGet]
        public IActionResult Duties()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(DutyView view)
        {
            return PartialView("_Details", view);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return PartialView("_Details", new DutyView());
        }
        
        [HttpPost]
        public JsonResult Save(DutyView view)
        {
            return Json(StatusCode(200));
        }
        
        [HttpDelete]
        public JsonResult Delete(DutyView view)
        {
            return Json(StatusCode(200));
        }
    }
}
