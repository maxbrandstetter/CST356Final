using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CST356Final.Services
{
    public class ClassService : IClassService
    {
        public bool ClassNumberIsNumeric(Class c)
        {
            // Check if class number is all numbers
            if (Regex.IsMatch(c.ClassNumber, @"^\d+$"))
            {
                return true;
            }
            else
                return false;
        }
    }
}