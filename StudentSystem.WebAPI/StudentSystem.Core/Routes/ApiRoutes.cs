using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.Core.Routes
{
    /// <summary>
    /// The wrapper for all controller routes.
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// All API routes for Students controller.
        /// </summary>
        public static class Students
        {
            /// <summary>
            /// The API route for adding the student into the database.
            /// </summary>
            public const string AddStudent = "add";

            /// <summary>
            /// The API route for obtaining the details of all students in the database.
            /// </summary>
            public const string StudentsDetail = "detail";
        }
    }
}
