using System;
using Xunit;

namespace GradeBook.Tests
{ 
    public delegate string WriteLogDelegate(string logMessage);
        
    public class TypeTests
    {
        int count =0;
        public delegate string WriteLogDelegate(string logMessage);
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log= ReturnMessage;
            log +=ReturnMessage;
            log += IncrementCount;
            var result=log("Hello!");
           Assert.Equal(result,"hello!");
        }
        
        string IncrementCount(string message )
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message )
        {
            count++;
            return message;
        }

        
        [Fact]
        public void StringsBehaveAsValueTypes()
        {
            string name = "scott";
            MakeUpperCase(name);
            Assert.Equal("scott",name);
        }
        private void MakeUpperCase(string x)
        {
            x.ToUpper();
        }
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt () ;
            SetInt(ref x);
            Assert.Equal(5,x);
        }
        private void SetInt(ref int x)
        {
            x= 5 ;
        }
        private int GetInt()
        {
            return 3 ;
        }
        [Fact]
         public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1,"New Name");
            Assert.Equal(book1.Name,"New Name");
        }
        private void GetBookSetName(ref  InMemoryBook book, string name)// out must initialized
        {
         book= new InMemoryBook(name)  ;
        }
        [Fact]
         public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New Name");
            Assert.Equal(book1.Name,"Book 1");
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
         book= new InMemoryBook(name)  ;
        }
        [Fact]
         public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");
            Assert.Equal(book1.Name,"New Name");
        }
        private void SetName(InMemoryBook book, string name)
        {
         book.Name=name  ;
        }
        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2=GetBook("Book 2");

            Assert.NotSame(book1,book2);
        }
         [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2=book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
            
         
        }
        InMemoryBook GetBook(string name )
        {
              return new InMemoryBook(name);
        }
    }
}
