using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CheckAddGrade()
        {/*
            var book =new InMemoryBook("phy");
            var check= book.AddGrade(50);
           
            Assert.Equal(check,true);
            check = book.AddGrade(130);
            Assert.Equal(check,false);
            check = book.AddGrade(-10);
            Assert.Equal(check,false);
            */
        }
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
        //arrange
        var book = new InMemoryBook("science");
        book.AddGrade(11.2);
        book.AddGrade(11.3);
        book.AddGrade(11.4);

        //act 
       var result =  book.GetStatistics();

        //assert
        Assert.Equal(11.3,result.Average,1);
        Assert.Equal('F',result.letter);
        
        }
        
    }
}
