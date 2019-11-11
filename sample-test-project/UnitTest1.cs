using System;
using Xunit;

namespace sample_test_project
{
    public class UnitTest1
    {
        [Fact]
        [Trait("Category", "UnitTest")]
        public void MethodA()
        {
            Console.WriteLine("UnitTest1::MethodA");
        }

        [Fact]
        [Trait("Category", "SmokeTest")]
        public void MethodB()
        {
            Console.WriteLine("UnitTest1::MethodB");
        }

        [Fact]
        [Trait("Category", "SmokeTest")]
        public void MethodC()
        {
            Console.WriteLine("UnitTest1::MethodC");
        }
    }
}
