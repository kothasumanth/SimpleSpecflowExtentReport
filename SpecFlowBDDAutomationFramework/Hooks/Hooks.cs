using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    public static String dir = AppDomain.CurrentDomain.BaseDirectory;
    public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
    private static ExtentReports extent;
    private static ExtentTest feature;
    private static ExtentTest scenario;
    private static ExtentTest step;

    [BeforeTestRun]
    public static void ExtentReportInit()
    {
        var htmlReporter = new ExtentSparkReporter(testResultPath + "test.html");
        htmlReporter.Config.ReportName = "Automation Status Report";
        htmlReporter.Config.DocumentTitle = "Automation Status Report";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    [BeforeFeature]
    public static void CreateFeature(FeatureContext featureContext)
    {
        feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }

    [BeforeScenario]
    public static void CreateScenario(ScenarioContext scenarioContext)
    {
        scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
    }

    [BeforeStep]
    public void BeforeStep(ScenarioContext scenarioContext)
    {
        step = scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
    }

    [AfterStep]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        step.Log(Status.Pass, "Step passed");
    }

    public static void LogStepInfo(string info)
    {
        step.Info(info);
    }

    [AfterTestRun]
    public static void FlushReport()
    {
        extent.Flush();
    }
}