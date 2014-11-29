using System.Web.Mvc;
using Library.BusinessLayer.Repositories;
using Library.BusinessLayer.Entities;

namespace Library.Web.Areas.Main.Controllers
{
    public partial class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        //
        // GET: /Person/

        public virtual ViewResult Index()
        {
            return View(_booksRepository.GetList());
        }

        //
        // GET: /Person/Details/5

        public virtual ViewResult Details(int id)
        {
            var person = _booksRepository.Get(id);
            return View(person);
        }

        //
        // GET: /Person/Create

        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        public virtual ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _booksRepository.Insert(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Person/Edit/5

        public virtual ActionResult Edit(int id)
        {
            var person = _booksRepository.Get(id);
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _booksRepository.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Person/Delete/5

        public virtual ActionResult Delete(int id)
        {
            var person = _booksRepository.Get(id);
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _booksRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}