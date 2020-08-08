using System.Collections.Generic;
using System.Threading.Tasks;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// The main repository for Student Address entities.
    /// </summary>
    public interface IStudentAddressRepository : IBaseRepository<StudentAddressEntity>
    {
        /// <summary>
        /// Retrieves the Enumerable of <see cref="StudentAddressEntity"/> sorted by city.
        /// </summary>
        IEnumerable<StudentAddressEntity> GetStudentAddressesByCity();

        /// <summary>
        /// Retrieves the Enumerable of <see cref="StudentAddressEntity"/> sorted by city asynchronously.
        /// </summary>
        Task<IEnumerable<StudentAddressEntity>> GetStudentAddressesByCityAsync();
    }
}