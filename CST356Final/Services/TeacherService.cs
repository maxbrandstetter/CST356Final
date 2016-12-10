using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST356Final.Services
{
    public class TeacherService : ITeacherService
    {
        public bool TeacherIsSenior(Teacher teacher)
        {
            bool isSenior = false;
            int experience;
            Int32.TryParse(teacher.YearsExperience, out experience);

            // Teacher is only a senior if they have 25 or more years experience
            if (experience >= 25)
            {
                isSenior = true;
            }

            return isSenior;
        }
    }
}