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

namespace CST356Final.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IDataRepository _dataRepo;
        private readonly ITeacherService _teacherService;

        public TeachersController(IDataRepository dataRepository, ITeacherService teacherService)
        {
            _dataRepo = dataRepository;
            _teacherService = teacherService;
        }

        // GET: Teachers
        public ActionResult Index()
        {
            List<Teacher> teachers = new List<Teacher>();
            var allTeachers = _dataRepo.GetTeachers();

            foreach (Teacher teacher in allTeachers)
            {
                // If the current user is the user who posted the teacher, then add it
                if (teacher.User == User.Identity.Name)
                {
                    teachers.Add(teacher);
                }

                // Check and set if the teacher is a senior
                teacher.Senior = _teacherService.TeacherIsSenior(teacher);                
            }

            return View(teachers);
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = _dataRepo.GetTeacher(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            // Get classes
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,FirstName,LastName,EmailAddress,YearsExperience")] Teacher teacher, List<int> classIds)
        {
            if (ModelState.IsValid)
            {
                /* Add classes
                teacher.Classes = new List<Class>();
                foreach (var classId in classIds)
                {

                }
                */
                _dataRepo.AddTeacher(teacher, User.Identity.Name);
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = _dataRepo.GetTeacher(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,FirstName,LastName,EmailAddress,YearsExperience")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            _dataRepo.UpdateTeacher(teacher);

            return RedirectToAction("Index");
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = _dataRepo.GetTeacher(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            _dataRepo.RemoveTeacher(teacher);

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = _dataRepo.GetTeacher(id);
            return RedirectToAction("Index");
        }
    }
}
