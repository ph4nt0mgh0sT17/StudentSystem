﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DataServiceLayer.Repositories.Interfaces
{
    /// <summary>
    /// The unit of work that facades together all repositories to work with them.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The student repository.
        /// </summary>
        IStudentRepository Students { get; }

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
