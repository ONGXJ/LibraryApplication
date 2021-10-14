using LibraryApplication.Data;
using LibraryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : BaseController
    {
        private readonly LibraryDbContext _db;

        public BookController(LibraryDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var BookDb = _db.Books.ToList();
            var books = new Book();
            books.BookList = new List<Book>();

            foreach (var book in BookDb)
            {
                var item = new Book();
                item.Id = book.Id;
                item.Name = book.Name;
                item.Code = book.Code;

                books.BookList.Add(item);
            }

            return GetView(books);
        }

        public ActionResult Create()
        {
            return GetView();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookInDb = _db.Books.FirstOrDefault(m => m.Id == id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            var bookDetails = new Book();
            bookDetails.Id = bookInDb.Id;
            bookDetails.Name = bookInDb.Name;
            bookDetails.Code = bookInDb.Code;

            return GetView(bookDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBook = new LibraryApplication.Data.Data.Book();
                    newBook.Name = book.Name;
                    newBook.Code = book.Code;

                    _db.Books.Add(newBook);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception error)
            {
            }

            return GetView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var bookUpdate = new LibraryApplication.Data.Data.Book();
                    bookUpdate.Id = book.Id;
                    bookUpdate.Name = book.Name;
                    bookUpdate.Code = book.Code;

                    _db.Books.Update(bookUpdate);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception error)
                {

                }
            }

            return GetView(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookInDb = _db.Books.FirstOrDefault(m => m.Id == id);

        //    if (bookInDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookDetails = new Book();
        //    bookDetails.Id = bookInDb.Id;
        //    bookDetails.Name = bookInDb.Name;
        //    bookDetails.Code = bookInDb.Code;

        //    return GetView(bookDetails);
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var obj = _db.Books.Find(id);
                if (obj == null)
                    return NotFound();

                _db.Books.Remove(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //Book book = new Book() { Id = id };
                //_db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                //await _db.SaveChangesAsync();
            }
            catch (Exception error)
            {

            }

            return GetView(nameof(Index));
        }
    }
}
