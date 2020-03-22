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

        
        // 下拉選單
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

        //kendoGrid
        [HttpPost]
        public JsonResult GetGridData(Models.BookSearchArg arg)
        {
            return Json(this.bookService.GetBookByCondtioin(arg));
        }

        //刪除資料
        [HttpPost]
        public JsonResult DeleteBook(int BookID)
        {
            try
            {
                bookService.DeleteBook(BookID);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        //新增圖書
        public ActionResult InsertBook()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InsertBook(Models.BookData book)
        {
            try
            {
                bookService.InsertBook(book);
                return this.Json(true);
            }
            catch (Exception ex)
            {
                return this.Json(false);
            }

        }
        [HttpPost]
        public JsonResult GetBookData(int BookID)
        {
            return Json(this.bookService.GetBookData(BookID));
        }
        public JsonResult LendBookRecord(int BookID)
        {
            return Json(this.bookService.GetBookLendRecord(BookID));
        }
        
    }
}