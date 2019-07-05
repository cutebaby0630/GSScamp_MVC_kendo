using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSystemkendo.Controllers
{
    public class BookController : Controller
    {
        readonly Models.CodeService codeService = new Models.CodeService();
        
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetClassNameDropDownList()
        {
            return Json(this.codeService.GetBookClassName());
        }
        [HttpPost]
        public JsonResult GetUserNameDropDownList()
        {
            return Json(this.codeService.GetUserName());
        }
        [HttpPost]
        public JsonResult GetCodeNameDropDownList()
        {
            return Json(this.codeService.GetCodeName());
        }
    }
}