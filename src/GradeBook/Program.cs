using System;
using System.Collections.Generic;

namespace GradeBook
{
  
    class Program
    {
        
        static void Main(string[] args)
        {   
            var book = new DiskBook("science");
            book.GradeAdded += OnGradeAdded; // cannot be declared beacause event
            EnterGrade(book);
            var stats= book.GetStatistics();
            Console.WriteLine($"Average is {stats.Average}");
            Console.WriteLine($"Letter Grade is {stats.letter}");
            Console.WriteLine();
          
        }
        private static void EnterGrade(IBook book)
        {
          
           while(true)
            { 
              Console.WriteLine("Enter a Grade or q to quit");
              var input =Console.ReadLine();
              if (input=="q")
              {
                  break;
              }
              try
              {
              var grade= double.Parse(input);
              book.AddGrade(grade);
              }
              catch(ArgumentException ex)
              {
                Console.WriteLine(ex.Message);
              }
              catch(FormatException ex)
              {
                Console.WriteLine(ex.Message);
              }
              finally
              {
                  Console.WriteLine("**");
              }

            };

        }

        static void OnGradeAdded (object sender , EventArgs e)
        {
           Console.WriteLine("A grade is added");
        }
    }
}
