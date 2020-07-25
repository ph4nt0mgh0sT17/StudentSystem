using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// The unit of work that facades together all repositories to work with them.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The student repository.
        /// </summary>
        IStudentRepository Students { get; }

        /// <summary>
        /// The student address repository.
        /// </summary>
        IStudentAddressRepository StudentAddresses { get; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Determination if saving changes were done successfully.</returns>
        int Complete();

        /// <summary>
        /// Saves the changes asynchronously.
        /// </summary>
        /// <returns>Determination if saving changes were done successfully.</returns>
        Task<int> CompleteAsync();
    }
}
