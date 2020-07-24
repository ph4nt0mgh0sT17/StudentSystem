using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer.Repositories.Interfaces
{

    /// <summary>
    /// The repository for the students. This interface can be used for databases, XML or text files.
    /// </summary>
    public interface IStudentRepository : IBaseRepository<StudentEntity>
    {
        IEnumerable<StudentEntity> GetStudentsByUsername();

        Task<IEnumerable<StudentEntity>> GetStudentsByUsernameAsync();
    }
}
