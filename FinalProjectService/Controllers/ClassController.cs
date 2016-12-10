using CST356Final.Data;
using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProjectService.Controllers
{
    public class ClassController : ApiController
    {
        private IDataRepository _dataRepo;

        public ClassController()
        {
            _dataRepo = new DataRepository();
        }
        
        public List<Class> GetAllClasses()
        {
            var classes = _dataRepo.GetClasses();

            return classes;
        }

        public IHttpActionResult GetClass(int id)
        {
            var _class = _dataRepo.GetClass(id);

            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }
    }
}
