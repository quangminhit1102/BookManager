using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Title, Description, Author, Images, Price")]Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Books.AddOrUpdate(book);
            context.SaveChanges();
            return View("ListBook", context.Books);
        }
        [Authorize]
        public ActionResult Edit(int? ID)
        {
            BookManagerContext context = new BookManagerContext();
            Book dbEdit = context.Books.FirstOrDefault(p => p.ID == ID);
            if(dbEdit == null)
            {
                return HttpNotFound();
            }    
            return View(dbEdit);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int ID,string Title,string Description,string Author,string Images,int Price)
        {
            BookManagerContext context = new BookManagerContext();
            Book dbEdit = context.Books.FirstOrDefault(p => p.ID == ID);
            
            if (dbEdit != null)
            {
                Book b = new Book(ID, Title, Description, Author, Images, Price);
                context.Books.AddOrUpdate(b);
                context.SaveChanges();
            }
            return View("ListBook", context.Books);
        }
        [Authorize]
        public ActionResult Delete(int? ID)
        {
            BookManagerContext context = new BookManagerContext();
            Book dbDelete = context.Books.FirstOrDefault(p => p.ID == ID);
            return View(dbDelete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int ID)
        {
            BookManagerContext context = new BookManagerContext();
            Book dbDelete = context.Books.FirstOrDefault(p => p.ID == ID);

            if (dbDelete != null)
            {
                context.Books.Remove(dbDelete);
                context.SaveChanges();
            }
            return View("ListBook", context.Books);
        }
    }
}