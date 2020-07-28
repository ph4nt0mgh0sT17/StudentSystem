using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using Autofac;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentSystem.Core;
using StudentSystem.DataServiceLayer.Entities;

namespace StudentSystem.ConsoleApplication
{
    internal class Program
    {
        private static ILogger mLogger;
        private static StudentSystemContext mStudentSystemContext;

        /// <summary>
        /// The main entry of the console application.
        /// </summary>
        private static void Main()
        {
            DependencyInjectionProvider.BuildProvider();
            InitializeMemberFields();

            mLogger.LogInformationSource("Testing logger...");

            /*Console.WriteLine(Constants.Messages.IntroductionMessage);
            while (true)
            {
                PrintMenu();
                ChooseOptionFromMenu();
            }*/
        }

        private static void InitializeMemberFields()
        {
            mLogger = DependencyInjectionProvider.Logger;
            mStudentSystemContext = DependencyInjectionProvider.StudentSystemContext;
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
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out int selectedOption);

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
            IUnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);

            List<StudentEntity> students = unitOfWork.Students.GetStudentsByUsername().ToList();
            students.ForEach(student => Console.WriteLine(student.ToString()));

            // Need to put an empty line to indent...
            Console.WriteLine();
        }

        /// <summary>
        /// Adds student to the database.
        /// </summary>
        private static void AddStudent()
        {
            Console.WriteLine("Adding new user:");

            CreateStudentDto createStudentDto = AskForCreateStudent();
            StudentEntity student = BuildStudentEntityFromCreateStudentDto(createStudentDto);

            IUnitOfWork unitOfWork = new UnitOfWork(mStudentSystemContext);
            unitOfWork.Students.Add(student);
            unitOfWork.Complete();
            

            Console.WriteLine(Constants.Messages.StudentCreatedSuccessfully + "\n");
        }

        /// <summary>
        /// Asks user to create the student and builds the <seealso cref="CreateStudentDto"/>.
        /// </summary>
        private static CreateStudentDto AskForCreateStudent()
        {
            string username = AskForInput("\tUsername: ");
            string firstName = AskForInput("\tFirst name: ");
            string lastName = AskForInput("\tLast name: ");
            string birthDateText = AskForInput("\tBirth date (yyyy-mm-dd): ");
            string address1 = AskForInput("\tAddress 1: ");
            string address2 = AskForInput("\tAddress 2: ");
            string city = AskForInput("\tCity: ");
            string region = AskForInput("\tRegion: ");
            string country = AskForInput("\tCountry: ");
            string postalCode = AskForInput("\tPostal code: ");

            return new CreateStudentDto()
            {
                Username = username,
                FirstName =  firstName,
                LastName = lastName,
                BirthDate = DateTime.Parse(birthDateText),
                Address1 =  address1,
                Address2 = address2,
                City = city,
                Region = region,
                Country = country,
                PostalCode = postalCode
            };
        }

        /// <summary>
        /// Asks user for the input in the console. If input is empty then null is returned.
        /// </summary>
        /// <returns>The input written by the user.</returns>
        private static string AskForInput(string askMessage)
        {
            Console.Write(askMessage);
            return Console.ReadLine().IfEmptyThenNull();
        }

        /// <summary>
        /// Builds the <seealso cref="StudentEntity"/> from the <seealso cref="CreateStudentDto"/>
        /// </summary>
        /// <param name="createStudentDto"></param>
        /// <returns></returns>
        private static StudentEntity BuildStudentEntityFromCreateStudentDto(CreateStudentDto createStudentDto)
        {
            return new StudentEntity()
            {
                Username = createStudentDto.Username,
                FirstName = createStudentDto.FirstName,
                LastName = createStudentDto.LastName,
                BirthDate = createStudentDto.BirthDate,
                StudentAddress = new StudentAddressEntity()
                {
                    Address1 = createStudentDto.Address1,
                    Address2 = createStudentDto.Address2,
                    City = createStudentDto.City,
                    Region = createStudentDto.Region,
                    Country = createStudentDto.Country,
                    PostalCode = createStudentDto.PostalCode
                }
            };
        }



    }
}
