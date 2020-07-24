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
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace StudentSystem.ConsoleApplication
{
    internal class Program
    {
        private static Logger logger;
        private static StudentSystemContext studentSystemContext;
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
            studentSystemContext = DependencyInjectionManager.StudentSystemContext;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\t1. - Print all students");
            Console.WriteLine("\t2. - Add a student");
            Console.WriteLine("\t3. - Remove a student");
            Console.WriteLine("\t4. - Update a student\n");
        }

        /// <summary>
        /// Asks user to select the option from menu...
        /// </summary>
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
                    AddStudent();
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

        private static void AddStudent()
        {
            Console.WriteLine("Adding new user:");

            Console.Write("\tUsername: ");
            string username = Console.ReadLine();

            Console.Write("\tFirst name: ");
            string firstName = Console.ReadLine();

            Console.Write("\tLast name: ");
            string lastName = Console.ReadLine();

            Console.Write("\tBirth date: ");
            string birthDateText = Console.ReadLine();

            StudentEntity student = new StudentEntity()
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = DateTime.Parse(birthDateText)
            };

            IUnitOfWork unitOfWork = new UnitOfWork(studentSystemContext);
            unitOfWork.Students.Add(student);
            unitOfWork.Complete();

            Console.WriteLine("User created.");
        }
    }
}
