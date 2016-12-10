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
    public class ClassServiceTest
    {
        private IClassService _classService;

        [SetUp]
        public void SetUp()
        {
            _classService = new ClassService();
        }

        [Test]
        public void WhenAlphabeticServiceFails()
        {
            var c = new Class
            {
                Subject = "Writing",
                ClassNumber = "Oops",
                ClassName = "Intro to Writing"
            };

            var result = _classService.ClassNumberIsNumeric(c);

            Assert.IsFalse(result);
        }

        [Test]
        public void WhenNumericServiceSucceeds()
        {
            var c = new Class
            {
                Subject = "Writing",
                ClassNumber = "101",
                ClassName = "Intro to Writing"
            };

            var result = _classService.ClassNumberIsNumeric(c);

            Assert.IsTrue(result);
        }

        [Test]
        public void WhenAlphaNumericServiceFails()
        {
            var c = new Class
            {
                Subject = "Writing",
                ClassNumber = "101aba101",
                ClassName = "Intro to Writing"
            };

            var result = _classService.ClassNumberIsNumeric(c);

            Assert.IsFalse(result);
        }
    }
}
