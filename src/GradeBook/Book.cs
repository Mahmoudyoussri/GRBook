using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender , EventArgs args);
    
    public class NamedObject //derive implicitly from object
    {
        public NamedObject(string name)
        {
            Name=name;
        }
        public string Name
        {
          get;
          set;  
            
        }
    }

    public interface IBook
    {
        void AddGrade(Double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    
    public abstract class Book:NamedObject, IBook
    {
        public Book(string name ):base(name)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line!=null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook :Book
    {
        List<double> grades ;
        readonly string category="";//only cahnge in constr or declaration
        //const string CATEGORY="sci"; treated as static
        public override event GradeAddedDelegate GradeAdded;
        
        
        
        public InMemoryBook(string name) : base(name)
        {
            category="";
            grades=new List<double>();
        }
        public void AddletterGrade(char letter)//Signature(not return type)
        {
            
            switch(letter)
            {
                case 'A':
                     AddGrade(90);
                     break;

                case 'B':
                     AddGrade(80);
                     break;
                case 'C':
                     AddGrade(70);
                     break;
                default:
                     AddGrade(0);
                     break;     
            }
        }
        public override void AddGrade(double grade)
        {
            if ( grade<=100  && grade>=0 ) //validate grade
            {
            grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());//event

            }
            else throw new ArgumentException($"invalid {nameof(grade)}");
        }
        public override Statistics GetStatistics()
       {
            var result=new Statistics();
         
            for(var index=0; index<grades.Count; index+=1)
            {
                result.Add(grades[index]);
   
            }
            return result; 
         }
    }
}