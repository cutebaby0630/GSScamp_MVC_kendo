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
        readonly Models.BookService bookService = new Models.BookService();
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

        public JsonResult GetGridData(Models.BookSearchArg arg)
        {
            return Json(this.bookService.GetBookByCondtioin(arg));
        }
        [HttpPost()]
        public JsonResult DeleteBook(int BookID)
        {
            try
            {
                bookService.DeleteBook(BookID);
                return this.Json(true);
            }
            catch (Exception ex)
            {
                return this.Json(false);
            }
        }
    }
}