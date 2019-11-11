using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Xunit.Abstractions;
using Xunit.Runners;

namespace sample_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting sample console...");
            RunTests();
            Console.WriteLine("Ended sample console.");
        }

        private static string[] TestCategoryFilter = new string[]{"SmokeTest", "StabilityTest"};
        private static void RunTests()
        {
            var testProjectAssembly = $@"..\sample-test-project\bin\Debug\netcoreapp2.2\publish\sample-test-project.dll";
            Assembly assembly = Assembly.LoadFrom(testProjectAssembly);
            var runner = AssemblyRunner.WithoutAppDomain(assembly.Location);

            runner.OnTestFinished = TestFinished;
            runner.OnTestPassed = TestPassed;
            runner.OnTestSkipped = TestSkipped;
            runner.OnDiscoveryComplete = DiscoveryComplete;
            runner.OnErrorMessage = Error;
            runner.OnExecutionComplete = ExecutionComplete;
            runner.OnTestFailed = TestFailed;
            runner.OnTestOutput = TestOutput;
            runner.TestCaseFilter = FilterTests;
            runner.Start();

            while (runner.Status != AssemblyRunnerStatus.Idle)
            {
                Thread.Sleep(500);
                Console.WriteLine($"AssemblyRunnerStatus:{runner.Status}");
            }
            runner.Dispose();
        }

        private static bool FilterTests(ITestCase testCase)
        {
            var traitValues = testCase.Traits.Values.SelectMany( t => t);
            var found = TestCategoryFilter.Intersect(traitValues).Any();
            return found;
        }

        private static void TestOutput(TestOutputInfo info)
        {
            Console.WriteLine("TestOutput.");
        }

        private static void TestFailed(TestFailedInfo info)
        {
            Console.WriteLine("TestFailed.");
        }

        private static void ExecutionComplete(ExecutionCompleteInfo info)
        {
            Console.WriteLine(info.ToHumanString());
        }

        private static void Error(ErrorMessageInfo info)
        {
            Console.WriteLine("Error.");
        }

        private static void DiscoveryComplete(DiscoveryCompleteInfo info)
        {
            Console.WriteLine("DiscoveryComplete.");
        }

        private static void TestPassed(TestPassedInfo info)
        {
            Console.WriteLine(info.ToHumanString());
        }

        private static void TestFinished(TestFinishedInfo info)
        {
            Console.WriteLine("TestFinished.");
        }

        private static void TestSkipped(TestSkippedInfo info)
        {
            Console.WriteLine("TestSkipped.");
        }

    }
}
