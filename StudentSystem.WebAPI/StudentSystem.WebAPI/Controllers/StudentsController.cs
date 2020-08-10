using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Core.Routes;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.WebAPI.Controllers
{
    [Route(ApiControllerRoutes.Students)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentSystemContext mStudentSystemContext;

        public StudentsController(StudentSystemContext studentSystemContext)
        {
            mStudentSystemContext = studentSystemContext;
        }

        [HttpPost(ApiRoutes.Students.AddStudent)]
        public void AddStudent(StudentEntity studentEntity)
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);

            unitOfWork.Students.Add(studentEntity);
            unitOfWork.Complete();
        }

        [HttpGet(ApiRoutes.Students.StudentsDetail)]
        public IEnumerable<StudentEntity> GetAllStudents()
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);
            return unitOfWork.Students.GetStudentsByUsername();
        }
    }
}
