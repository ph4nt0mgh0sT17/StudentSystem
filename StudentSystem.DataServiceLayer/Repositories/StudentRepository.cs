using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer.Entities;
using StudentSystem.DataServiceLayer.Repositories.Interfaces;

namespace StudentSystem.DataServiceLayer.Repositories
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<StudentEntity> GetStudentsByUsername()
        {
            return GetAll().OrderBy(student => student.Username);
        }

        public async Task<IEnumerable<StudentEntity>> GetStudentsByUsernameAsync()
        {
            return await Task.Run(() =>
            {
                return GetAllAsync().Result.OrderBy(student => student.Username);
            });
        }

        /// <summary>
        /// The main database context for this repository.
        /// </summary>
        private StudentSystemContext StudentSystemContext
        {
            get
            {
                return mContext as StudentSystemContext;
            }
        }
    }
}
