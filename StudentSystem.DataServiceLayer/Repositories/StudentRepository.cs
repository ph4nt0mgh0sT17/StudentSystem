using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves all student entities from the database.
        /// </summary>
        public override IQueryable<StudentEntity> GetAll()
        {
            // Includes the student address
            return base.GetAll().IncludeStudentAddress();
        }

        /// <summary>
        /// Gets all asynchronously
        /// </summary>
        /// <returns></returns>
        public override async Task<IQueryable<StudentEntity>> GetAllAsync()
        {
            return await Task.Run(() => base.GetAllAsync().Result.IncludeStudentAddress());
        }

        /// <summary>
        /// Retrieves all students from the database ordered by its username.
        /// </summary>
        public IEnumerable<StudentEntity> GetStudentsByUsername()
        {
            return GetAll().OrderBy(student => student.Username);
        }

        /// <summary>
        /// Gets all students from the database ordered by its username asynchronously.
        /// </summary>
        public async Task<IEnumerable<StudentEntity>> GetStudentsByUsernameAsync()
        {
            return await Task.Run(() => GetAllAsync().Result.OrderBy(student => student.Username));
        }

        /// <summary>
        /// The main database context for this repository.
        /// </summary>
        private StudentSystemContext StudentSystemContext => mContext as StudentSystemContext;
    }
}
