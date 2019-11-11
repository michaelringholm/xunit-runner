using Xunit.Runners;

public static class TestInfoExtension {
    public static string ToHumanString(this TestPassedInfo info) {
        return $"Name:{info.TestDisplayName}\nMethod:{info.MethodName}:ExecutionTime:{info.ExecutionTime}";
    }

    public static string ToHumanString(this ExecutionCompleteInfo info) {
        return $"TotalTests:{info.TotalTests}\nTestsFailed:{info.TestsFailed}\nTestsSkipped:{info.TestsSkipped}:\nExecutionTime:{info.ExecutionTime}";
    }    
}