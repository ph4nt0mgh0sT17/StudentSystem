using StudentSystem.DataServiceLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentSystem.DataServiceLayer
{
    public class StudentAddressRepository : BaseRepository<StudentAddressEntity>, IStudentAddressRepository
    {
        public StudentAddressRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves all student addresses from the database sorted by the city element.
        /// </summary>
        public IEnumerable<StudentAddressEntity> GetStudentAddressesByCity()
        {
            return GetAll().ToList().OrderBy(studentAddress => studentAddress.City);
        }

        /// <summary>
        /// Retrieves all student addresses from the database sorted by the city element asynchronously.
        /// </summary>
        public async Task<IEnumerable<StudentAddressEntity>> GetStudentAddressesByCityAsync()
        {
            return await Task.Run(() =>
            {
                return GetAll().OrderBy(studentAddress => studentAddress.City).ToList();
            });
        }

        /// <summary>
        /// The main database context for this repository.
        /// </summary>
        private StudentSystemContext StudentSystemContext => mContext as StudentSystemContext;
    }
}