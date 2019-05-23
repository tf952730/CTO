using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.A01.Entities;
using ContosoUniversity.A03.EntitiesProcess;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _PersonService;   // 人员数据处理服务
        public PersonController(IPersonRepository service)
        {
            _PersonService = service;
        }

        public ActionResult Index(string keyword = null)
        {
            var persons = new List<Person>();
            if (String.IsNullOrEmpty(keyword))
                persons = _PersonService.GetPersons();
            else
                persons = _PersonService.GetPersons(keyword);

            var personVMCollection = new List<PersonViewModel>();
            var counter = 0;
            foreach (var item in persons)
            {
                var personVM = new PersonViewModel(item);
                personVM.OrderNumber = (++counter).ToString();
                personVMCollection.Add(personVM);
            }

            ViewData["Title"] = "员工数据维护管理";
            ViewData["Keyword"] = keyword;

            return View(personVMCollection);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var person = new Person();
            var personVM = new PersonViewModel(person);
            ViewData["Title"] = "新建员工数据";
            return View(personVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,Email,Mobile,Description, SortCode")]PersonViewModel personVM)
        {
            if (ModelState.IsValid)
            {
                _PersonService.Add(personVM.ToPerson());
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "新建员工数据";
            return View(personVM);
        }


        // GET: Person/Edit/5
        public ActionResult Edit(Guid id)
        {
            var personVM = new PersonViewModel(_PersonService.GetPerson(id));
            ViewData["Title"] = "编辑员工数据";

            return View(personVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Name,Email,Mobile,Description, SortCode")]PersonViewModel personVM)
        {
            if (ModelState.IsValid)
            {

                _PersonService.Update(personVM.ToPerson());
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "编辑员工数据";
            return View(personVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _PersonService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var personVM = new PersonViewModel(_PersonService.GetPerson(id));
                ViewData["Title"] = "删除员工数据";
                return View("Delete", personVM);
            }
        }

        public ActionResult IsDelete(Guid id)
        {
            var personVM = new PersonViewModel(_PersonService.GetPerson(id));
            ViewData["Title"] = "删除员工数据";
            return View("Delete", personVM);
        }
    }
}