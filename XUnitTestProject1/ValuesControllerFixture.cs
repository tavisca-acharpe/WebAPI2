using System;
using Xunit;
using WebApi.Controllers;

namespace XUnitTestProject1
{
    public class ValuesControllerFixture
    {
        ValuesController valuesController = new ValuesController();

        [Fact]
        public void TestForHi()
        {
            var getResult = valuesController.Get("hi").Value;
            Assert.Equal("hello",getResult);
        }

        [Fact]
        public void TestForHello()
        {
            var getResult = valuesController.Get("hello").Value;
            Assert.Equal("hi", getResult);
        }

        [Fact]
        public void TestForInvalide()
        {
            var getResult = valuesController.Get("hellohi").Value;
            Assert.Equal("invalid", getResult);
        }

    }
}
