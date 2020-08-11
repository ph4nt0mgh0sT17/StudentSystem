using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mikrite.Core.Extensions;
using StudentSystem.Core.Routes;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.WebAPI.Controllers
{
    [Route(ApiControllerRoutes.Students)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// The <see cref="StudentSystemContext"/> for database.
        /// </summary>
        private readonly StudentSystemContext mStudentSystemContext;

        /// <summary>
        /// The main constructor of the <see cref="StudentsController"/> that builds the <see cref="StudentSystemContext"/>.
        /// </summary>
        public StudentsController(StudentSystemContext studentSystemContext, ILogger logger)
        {
            mStudentSystemContext = studentSystemContext;
            logger.LogInformationSource("Students Controller xd...");
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
