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

namespace CST356Final.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IDataRepository _dataRepo;

        public StudentsController(IDataRepository dataRepository)
        {
            _dataRepo = dataRepository;
        }

        // GET: Students
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            var allStudents = _dataRepo.GetStudents();

            foreach (Student student in allStudents)
            {
                // If the current user is the user who posted the teacher, then add it
                if (student.User == User.Identity.Name)
                {
                    students.Add(student);
                }
            }

            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _dataRepo.GetStudent(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                _dataRepo.AddStudent(student, User.Identity.Name);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _dataRepo.GetStudent(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _dataRepo.UpdateStudent(student);

            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _dataRepo.GetStudent(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }

            _dataRepo.RemoveStudent(student);

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = _dataRepo.GetStudent(id);
            return RedirectToAction("Index");
        }
    }
}
