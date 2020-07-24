using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using Autofac;
using log4net;
using log4net.Config;

namespace StudentSystem.ConsoleApplication
{
    internal class Program
    {
        private static Logger logger;
        /// <summary>
        /// The main entry of the console application.
        /// </summary>
        private static void Main()
        {
            DependencyInjectionManager.BuildContainer();
            InitializeMemberFields();

            Console.WriteLine(Constants.Messages.IntroductionMessage);
            while (true)
            {
                PrintMenu();
                ChooseOptionFromMenu();
            }


        }

        private static void InitializeMemberFields()
        {
            logger = DependencyInjectionManager.Logger;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\t1. - Print all students");
            Console.WriteLine("\t2. - Add a student");
            Console.WriteLine("\t3. - Remove a student");
            Console.WriteLine("\t4. - Update a student\n");
        }

        private static void ChooseOptionFromMenu()
        {
            Console.Write(Constants.Messages.AskForSelectionMenu);
            int selectedOption = 0;
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedOption);

            Console.WriteLine("\n");

            EvaluateSelectedOptionFromMenu(selectedOption);
        }

        /// <summary>
        /// Evaluates the option that user selected.
        /// </summary>
        /// <param name="selectedOption">The number that user selected.</param>
        private static void EvaluateSelectedOptionFromMenu(int selectedOption)
        {

            switch (selectedOption)
            {
                case Constants.MenuOptions.WrongOption:
                    Console.WriteLine(Constants.ErrorMessages.WrongSelectedOptionFromConsoleMenu);
                    break;

                case Constants.MenuOptions.PrintAllStudents:
                    PrintAllStudents();
                    break;

                case Constants.MenuOptions.AddStudent:
                    // TODO: Add a student...
                    break;

                case Constants.MenuOptions.RemoveStudent:
                    // TODO: Remove student...
                    break;

                case Constants.MenuOptions.UpdateStudent:
                    // TODO update student
                    break;
            }
        }
        
        /// <summary>
        /// Prints all students into console from the database.
        /// </summary>
        private static void PrintAllStudents()
        {
            Console.WriteLine(Constants.Messages.RetrievingStudents + "\n");
            IUnitOfWork unitOfWork = new UnitOfWork(DependencyInjectionManager.StudentSystemContext);

            List<StudentEntity> students = unitOfWork.Students.GetStudentsByUsername().ToList();
            students.ForEach(student =>
            {
                Console.WriteLine($"Student ID: {student.Id}; Username: {student.Username}; Full name: {student.FirstName} {student.LastName}; Age: {student.BirthDate.GetAge()}");
            });

            // Need to put an empty line to indent...
            Console.WriteLine();
        }
    }
}
