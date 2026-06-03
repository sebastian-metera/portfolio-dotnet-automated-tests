using NUnit.Framework.Internal;

namespace Automation.Tests.Core.Logging;

public static class TestLogger
{
    public static void Info(string message)
    {
        TestContext.Progress.WriteLine($"[INFO] {message}");
    }

    public static void Error(string message)
    {
        TestContext.Error.WriteLine($"[ERROR] {message}");
    }
}
