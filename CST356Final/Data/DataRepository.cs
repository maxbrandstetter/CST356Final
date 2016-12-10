using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST356Final.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dataContext = new ApplicationDbContext();

        public List<Teacher> GetTeachers()
        {
            return _dataContext.Teachers.ToList();
        }

        public void AddTeacher(Teacher teacher)
        {
            _dataContext.Teachers.Add(teacher);
            _dataContext.SaveChanges();
        }

        public Teacher GetTeacher(int id)
        {
            return _dataContext.Teachers.Find(id);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _dataContext.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void RemoveTeacher(Teacher teacher)
        {
            _dataContext.Teachers.Remove(teacher);
            _dataContext.SaveChanges();
        }


        public List<Class> GetClasses()
        {
            return _dataContext.Classes.ToList();
        }

        public void AddClass(Class _class)
        {
            _dataContext.Classes.Add(_class);
            _dataContext.SaveChanges();
        }

        public Class GetClass(int id)
        {
            return _dataContext.Classes.Find(id);
        }

        public void UpdateClass(Class _class)
        {
            _dataContext.Entry(_class).State = System.Data.Entity.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void RemoveClass(Class _class)
        {
            _dataContext.Classes.Remove(_class);
            _dataContext.SaveChanges();
        }


        public List<Student> GetStudents()
        {
            return _dataContext.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            return _dataContext.Students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            _dataContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            _dataContext.Students.Remove(student);
            _dataContext.SaveChanges();
        }
    }
}
