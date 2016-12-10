using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CST356Final.Services;
using CST356Final.Models;

namespace CST356Final.Tests
{
    [TestFixture]
    public class TeacherServiceTest
    {
        private ITeacherService _teacherService;

        [SetUp]
        public void SetUp()
        {
            _teacherService = new TeacherService();
        }

        [Test]
        public void WhenLessThan25NotSenior()
        {
            var teacher = new Teacher
            {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "johndoe@email.com",
                YearsExperience = "15"
            };

            var result = _teacherService.TeacherIsSenior(teacher);

            Assert.IsFalse(result);
        }

        [Test]
        public void WhenMoreThan25Senior()
        {
            var teacher = new Teacher
            {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "johndoe@email.com",
                YearsExperience = "30"
            };

            var result = _teacherService.TeacherIsSenior(teacher);

            Assert.IsTrue(result);
        }

        [Test]
        public void When25Senior()
        {
            var teacher = new Teacher
            {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "johndoe@email.com",
                YearsExperience = "25"
            };

            var result = _teacherService.TeacherIsSenior(teacher);

            Assert.IsTrue(result);
        }
    }
}
