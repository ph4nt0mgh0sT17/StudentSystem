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

        [HttpPost("add")]
        public void AddStudent(StudentEntity studentEntity)
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);

            if (studentEntity.StudentAddress != null)
            {
                // Check if student address already exists
                StudentAddressEntity address = unitOfWork.StudentAddresses.Find(studentAddress =>
                    studentAddress.Id == studentEntity.StudentAddress.Id &&
                    studentAddress.Address1 == studentEntity.StudentAddress.Address1 &&
                    studentAddress.Address2 == studentEntity.StudentAddress.Address2 &&
                    studentAddress.City == studentEntity.StudentAddress.City) as StudentAddressEntity;

                if (address == null)
                {
                    unitOfWork.StudentAddresses.Add(new StudentAddressEntity
                    {
                        Address1 = studentEntity.StudentAddress.Address1,
                        Address2 = studentEntity.StudentAddress.Address2,
                        City = studentEntity.StudentAddress.City,
                        Country = studentEntity.StudentAddress.Country,
                        Region = studentEntity.StudentAddress.Region,
                        PostalCode = studentEntity.StudentAddress.PostalCode
                    });
                }
            }

            unitOfWork.Students.Add(studentEntity);
            unitOfWork.Complete();
        }

        [HttpGet("detail")]
        public IEnumerable<StudentEntity> GetAllStudents()
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);
            return unitOfWork.Students.GetStudentsByUsername();
        }
    }
}
