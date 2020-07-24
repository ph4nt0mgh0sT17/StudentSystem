﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;
using StudentSystem.DataServiceLayer.Entities;
using StudentSystem.DataServiceLayer.Repositories;

namespace StudentSystem.ConsoleApplication
{
    internal class Program
    {
        /// <summary>
        /// The main entry of the console application.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            StudentSystemContext studentSystemContext = new StudentSystemContext();

            UnitOfWork unitOfWork = new UnitOfWork(studentSystemContext);

            List<StudentEntity> students = unitOfWork.Students.GetAll().ToList();

            students.ForEach(student =>
            {
                Console.WriteLine($"Student: {student.Id}; username: {student.Username}");
            });

        }
    }
}
