using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.DataServiceLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentSystemContext mContext;

        /// <summary>
        /// Initializes the <see cref="UnitOfWork"/> with the database context.
        /// </summary>
        /// <param name="context">The database context to operate with the database.</param>
        public UnitOfWork(StudentSystemContext context)
        {
            mContext = context;
            InitializeAppRepositories();
        }

        /// <summary>
        /// Initializes all repositories needed in the application.
        /// 
        /// <br/><br/>
        /// 
        /// The <see cref="IStudentRepository"/> is assigned to <see cref="StudentRepository"/> as the database repository.
        /// </summary>
        private void InitializeAppRepositories()
        {
            Students = new StudentRepository(mContext);
            StudentAddresses = new StudentAddressRepository(mContext);
        }

        /// <summary>
        /// Completes all database actions and saves them.
        /// </summary>
        /// <returns>The integer action.</returns>
        public int Complete()
        {
            return mContext.SaveChanges();
        }

        /// <summary>
        /// Completes all database actions and saves them asynchronously.
        /// </summary>
        /// <returns>The integer action.</returns>
        public async Task<int> CompleteAsync()
        {
            return await mContext.SaveChangesAsync();
        }

        /// <summary>
        /// Student repository for database communication.
        /// </summary>
        public IStudentRepository Students { get; private set; }

        /// <summary>
        /// Student address repository for database communication.
        /// </summary>
        public IStudentAddressRepository StudentAddresses { get; private set; }
    }
}
