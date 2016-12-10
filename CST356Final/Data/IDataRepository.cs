using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST356Final.Data
{
    public interface IDataRepository
    {
        List<Teacher> GetTeachers();
        void AddTeacher(Teacher teacher);
        Teacher GetTeacher(int id);
        void UpdateTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);

        List<Class> GetClasses();
        void AddClass(Class _class);
        Class GetClass(int id);
        void UpdateClass(Class _class);
        void RemoveClass(Class _class);

        List<Student> GetStudents();
        void AddStudent(Student student);
        Student GetStudent(int id);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}