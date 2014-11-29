using System.Web.Mvc;
using Kendo.Mvc.UI;
using Library.BusinessLayer.Models;
using Library.BusinessLayer.Repositories;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Repositories.Operations;
using Library.Web.Controllers;

namespace Library.Web.Areas.Main.Controllers
{
    public partial class PeopleController : BaseController
    {
        private readonly IPeopleRepository _peopleRepository;

        private readonly IPeopleOperationsRepository _peopleOperationsRepository;

        public PeopleController(IPeopleRepository peopleRepository, IPeopleOperationsRepository peopleOperationsRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleOperationsRepository = peopleOperationsRepository;
        }

        //
        // GET: /People/

        public virtual ActionResult Index()
        {
            return View();
        }

        //
        // GET: /People/GetList

        public virtual ActionResult GetList([DataSourceRequest]DataSourceRequest request)
        {
            var result = new DataSourceResult
            {
                Data = _peopleRepository.GetList(new Paging(request.Page, request.PageSize)),
                Total = _peopleRepository.GetCount()
            };
            return Json(result);
        }

        //
        // GET: /People/Create

        public virtual ActionResult Create()
        {
            return PartialView(MVC.Main.People.Views.Edit, new Person());
        }

        //
        // GET: /People/Create

        [HttpPost]
        public virtual ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.Insert(person);
                return new EmptyResult();
            }
            return PartialView(MVC.Main.People.Views.Edit, person);
        }

        //
        // GET: /People/Edit/5

        public virtual ActionResult Edit(int id)
        {
            var person = _peopleRepository.Get(id);
            return PartialView(person);
        }

        //
        // POST: /People/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.Update(person);
                return new EmptyResult();
            }
            return PartialView(person);
        }

        //
        // POST: /People/Delete/5

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            _peopleRepository.Delete(id);
            return new EmptyResult();
        }

        //
        // GET: /People/

        public virtual ActionResult Operations(int id)
        {
            return PartialView(id);
        }

        //
        // GET: /People/Operations/5

        public virtual ActionResult GetOperations(int id, [DataSourceRequest]DataSourceRequest request)
        {
            var result = new DataSourceResult
            {
                Data = _peopleOperationsRepository.GetList(id, new Paging(request.Page, request.PageSize)),
                Total = _peopleOperationsRepository.GetCount(id)
            };
            return Json(result);
        }
    }
}