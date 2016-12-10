using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CST356Final.Models;
using CST356Final.Data;
using CST356Final.Services;
using CST356Final.Proxies;

namespace CST356Final.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IDataRepository _dataRepo;
        private readonly IRestClassProxy _proxy;

        public ClassesController(IDataRepository dataRepository, IRestClassProxy proxy)
        {
            _dataRepo = dataRepository;
            _proxy = proxy;
            _proxy.GetClassesAsync();
        }

        // GET: Classes
        public ActionResult Index()
        {
            var classes = new List<Class>();
            var allClasses = _dataRepo.GetClasses();

            foreach (Class _class in allClasses)
            {
                // If the current user is the user who posted the teacher, then add it
                if (_class.User == User.Identity.Name)
                {
                    classes.Add(_class);
                }
            }

            return View(classes);
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _dataRepo.GetClass(id.Value);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            // Get students
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,Subject,ClassNumber,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                // Add students
                _dataRepo.AddClass(@class, User.Identity.Name);
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _dataRepo.GetClass(id.Value);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,Subject,ClassNumber,ClassName")] Class @class)
        {
            if (!ModelState.IsValid)
            {
                return View(@class);
            }

            _dataRepo.UpdateClass(@class);

            return RedirectToAction("Index");
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _dataRepo.GetClass(id.Value);
            if (@class == null)
            {
                return HttpNotFound();
            }

            _dataRepo.RemoveClass(@class);

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = _dataRepo.GetClass(id);
            return RedirectToAction("Index");
        }
    }
}
