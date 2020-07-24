using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.ConsoleApplication
{
    public static class Constants
    {
        /// <summary>
        /// The class that contains all error messages used in the application.
        /// </summary>
        public static class ErrorMessages
        {
            /// <summary>
            /// Text when the selected option is selected wrong. There is wrong number or wrong text...
            /// </summary>
            public const string WrongSelectedOptionFromConsoleMenu = "Sorry, you have selected wrong option.";
        }

        /// <summary>
        /// The class that contains all menu options used in the console.
        /// </summary>
        public static class MenuOptions
        {
            public const int WrongOption = 0;
            public const int PrintAllStudents = 1;
            public const int AddStudent = 2;
            public const int RemoveStudent = 3;
            public const int UpdateStudent = 4;
        }

        public static class Messages
        {
            public const string ApplicationStarted = "The Student System application has started";
            public const string IntroductionMessage = "Welcome to the Student system application.";
            public const string AskForSelectionMenu = "Select an option (1 - 4): ";
            public const string RetrievingStudents = "Retrieving students...";
        }

    }
}
