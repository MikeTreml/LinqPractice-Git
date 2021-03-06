﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticeProblemsLINQ
{
    public static class LinqProblems
    {
        //Weighted project points: /10
        //Project points: /25
       
        #region Problem 1 
        //(5 points) Problem 1
        //Using LINQ, write a method that takes in a list of strings and returns all words that contain the substring “th” from a list.
        public static List<string> RunProblem1(List<string> words)
        {
            List<string> result = new List<string>();
            //code
            result = words.Where(w => w.Contains("th")).ToList();
         
           
            //return
            foreach(string i in result)
            {
                Console.WriteLine(i);
            }
            return result;
        }
        #endregion

        #region Problem 2 
        //(5 points) Problem 2
        //Using LINQ, write a method that takes in a list of strings and returns a copy of the list without duplicates.
        public static List<string> RunProblem2(List<string> names)
        {
            List<string> result = new List<string>();
            //code
            result = names.Distinct().ToList();
          
            //return
            foreach (string i in result)
            {
                Console.WriteLine(i);
            }
            return result;

        }
        #endregion

        #region Problem 3
        //(5 points) Problem 3
        //Using LINQ, write a method that takes in a list of customers and returns the lone customer who has the name of Mike. 
        public static Customer RunProblem3(List<Customer> customers)
        {
            
            //code
            Customer name = customers.Find(m => m.FirstName == "Mike");
            //return
            Console.WriteLine($"{name.Id} {name.FirstName} {name.LastName}");
            return name;
        }
        #endregion

        #region Problem 4
        //(5 points) Problem 4
        //Using LINQ, write a method that takes in a list of customers and returns the customer who has an id of 3. 
        //Then, update that customer's first name and last name to completely different names and return the newly updated customer from the method.
        public static Customer RunProblem4(List<Customer> customers)
        {

            //code
            Customer name = customers.Find(m => m.Id == 3);
            name.FirstName = "Lebron";
            name.LastName = "James";
            Console.WriteLine($"{name.Id} {name.FirstName} {name.LastName}");

            //return
            return name;

        }
        #endregion

        #region Problem 5
        //(5 points) Problem 5
        //Using LINQ, write a method that calculates the class grade average after dropping the lowest grade for each student.
        //The method should take in a list of strings of grades (e.g., one string might be "90,100,82,89,55"), 
        //drops the lowest grade from each string, averages the rest of the grades from that string, then averages the averages.
        //Expected output: 86.125
        public static double RunProblem5(List<string> classGrades)
        {
            List<double> newClassGrades = new List<double>();
            //code
            foreach(string i in classGrades)
            {
                List<int> grades = i.Split(',').Select(m => int.Parse(m)).ToList();
                grades.Remove(grades.Min(g => g));
                newClassGrades.Add(grades.Average());
            }
         
            //return
            return newClassGrades.Average();
        }
        #endregion

        #region Bonus Problem 1
        //(5 points) Bonus Problem 1
        //Write a method that takes in a string of letters(i.e. “Terrill”) 
        //and returns an alphabetically ordered string corresponding to the letter frequency(i.e. "E1I1L2R2T1")
        public static string RunBonusProblem1(string word)
        {
            StringBuilder build = new StringBuilder();
            //code
            List<char> chars = word.ToCharArray().OrderBy(m => m).ToList();

            while (chars.Count() > 0)
            {
                build.Append(chars[0]);
                build.Append(chars.Count(m => m == chars[0]));
                chars.RemoveAll(a => a == chars[0]);
            }

            return Convert.ToString(build).ToUpper();
        }
        #endregion
    }
}
