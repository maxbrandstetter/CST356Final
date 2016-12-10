using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST356Final.Services
{
    public interface IClassService
    {
        bool ClassNumberIsNumeric(Class c);
    }
}
