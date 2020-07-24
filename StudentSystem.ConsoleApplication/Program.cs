using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using Autofac;

namespace StudentSystem.ConsoleApplication
{
    internal class Program
    {

        /// <summary>
        /// The main entry of the console application.
        /// </summary>
        private static void Main()
        {
            // Builds the dependencies using injection
            DependencyInjectionManager.BuildContainer();

            Console.WriteLine(Constants.Messages.IntroductionMessage);
            PrintMenu();
            ChooseOptionFromMenu();

        }

        private static void PrintMenu()
        {
            Console.WriteLine("\t1. - Print all students");
            Console.WriteLine("\t2. - Add a student");
            Console.WriteLine("\t3. - Remove a student");
            Console.WriteLine("\t4. - Update a student");
        }

        private static void ChooseOptionFromMenu()
        {
            int selectedOption = 0;
            try
            {
                selectedOption = int.Parse(Console.ReadLine());
            }

            catch (FormatException ex)
            {
                
            }

            switch (selectedOption)
            {
                case Constants.MenuOptions.WrongOption:
                    Console.WriteLine(Constants.ErrorMessages.WrongSelectedOptionFromConsoleMenu);
                    break;

                case Constants.MenuOptions.PrintAllStudents:
                    IUnitOfWork unitOfWork = new UnitOfWork(DependencyInjectionManager.StudentSystemContext);

                    List<StudentEntity> students = unitOfWork.Students.GetStudentsByUsername().ToList();
                    students.ForEach(student =>
                    {
                        Console.WriteLine($"Student ID: {student.Id}; Username: {student.Username}; Full name: {student.FirstName} {student.LastName}; Age: {student.BirthDate.GetAge()}");
                    });
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
    }
}
