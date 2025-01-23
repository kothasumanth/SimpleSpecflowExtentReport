using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

public class ExtentReport
{
    public static String dir = AppDomain.CurrentDomain.BaseDirectory;
    public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
    private static ExtentReports extent;
    private static ExtentTest feature;
    private static ExtentTest scenario;
    private static ExtentTest step;

    public static void ExtentReportInit()
    {
        var htmlReporter = new ExtentSparkReporter(testResultPath + "test.html");
        htmlReporter.Config.ReportName = "Automation Status Report";
        htmlReporter.Config.DocumentTitle = "Automation Status Report";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    public static void CreateFeature(string featureName)
    {
        feature = extent.CreateTest<Feature>(featureName);
    }

    public static void CreateScenario(string scenarioName)
    {
        scenario = feature.CreateNode<Scenario>(scenarioName);
    }

    public static void CreateStep(string stepName)
    {
        step = scenario.CreateNode<Given>(stepName);
    }

    public static void LogStepInfo(string info)
    {
        step.Info(info);
    }

    public static void FlushReport()
    {
        extent.Flush();
    }
}