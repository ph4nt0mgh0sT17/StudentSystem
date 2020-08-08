using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentSystemContext mStudentSystemContext;

        public StudentsController(StudentSystemContext studentSystemContext)
        {
            mStudentSystemContext = studentSystemContext;
        }

        [HttpPost]
        public void AddStudent(StudentEntity studentEntity)
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);
            unitOfWork.Students.Add(studentEntity);
            unitOfWork.Complete();
        }
    }
}
