using System;
using System.Activities;
using System.Collections.Generic;
using HelloWorkFlow;
using Xunit;

namespace HelloWorkFlowTests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        public void Should_Return_Number_When_Input_Number(int number, int expected)
        {
            //Arrange
            var activity = new FizzBuzzActivity();

            //Act
            var result = WorkflowInvoker.Invoke(activity, new Dictionary<string, object>() {{ "x", number }});

            //Assert
            Assert.Equal($"{number} : {expected}", result["result"].ToString());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void Should_Return_Fizz_When_Input_Number(int number)
        {
            //Arrange
            var activity = new FizzBuzzActivity();

            //Act
            var result = WorkflowInvoker.Invoke(activity, new Dictionary<string, object>() { { "x", number } });

            //Assert
            Assert.Equal($"{number} : Fizz", result["result"].ToString());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void Should_Return_Buzz_When_Input_Number(int number)
        {
            //Arrange
            var activity = new FizzBuzzActivity();

            //Act
            var result = WorkflowInvoker.Invoke(activity, new Dictionary<string, object>() { { "x", number } });

            //Assert
            Assert.Equal($"{number} : Buzz", result["result"].ToString());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void Should_Return_FizzBuzz_When_Input_Number(int number)
        {
            //Arrange
            var activity = new FizzBuzzActivity();

            //Act
            var result = WorkflowInvoker.Invoke(activity, new Dictionary<string, object>() { { "x", number } });

            //Assert
            Assert.Equal($"{number} : FizzBuzz", result["result"].ToString());
        }
    }
}
