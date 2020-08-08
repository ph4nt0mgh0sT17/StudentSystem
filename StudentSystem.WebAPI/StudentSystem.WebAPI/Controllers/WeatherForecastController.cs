using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly StudentSystemContext mStudentSystemContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, StudentSystemContext studentSystemContext)
        {
            _logger = logger;
            mStudentSystemContext = studentSystemContext;
        }

        [HttpGet]
        public IEnumerable<StudentEntity> Get()
        {
            UnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);
            return unitOfWork.Students.GetStudentsByUsername();
        }
    }
}
