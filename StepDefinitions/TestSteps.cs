using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class TestSteps
{
    Pages pages = new Pages();
    [Given(@"I have initialized the ExtentReport")]
    public void GivenIHaveInitializedTheExtentReport()
    {
        Hooks.LogStepInfo("Given step info","info");
        
        pages.PagePrint();
    }

    [When(@"I create a feature named ""(.*)""")]
    public void WhenICreateAFeatureNamed(string featureName)
    {
        Hooks.LogStepInfo("When step info 2","info");
        pages.PagePrint();
    }

    [When(@"I create a scenario named ""(.*)""")]
    public void WhenICreateAScenarioNamed(string scenarioName)
    {
        Hooks.LogStepInfo("When step info 1","info");
    }

 [When(@"I create a scenario named y ""(.*)""")]
    public void WhenICreateAScenariyoNamed(string scenarioName)
    {
        Hooks.LogStepInfo("When step info 1","warning");
         Assert.Fail("This step should fail");
    }
    [When(@"I create a step named ""(.*)""")]
    public void WhenICreateAStepNamed(string stepName)
    {
        Hooks.LogStepInfo("When step info","info");
    }

    [When(@"I log step info ""(.*)""")]
    public void WhenILogStepInfo(string info)
    {
        Hooks.LogStepInfo(info,"info");
    }

    [When(@"I log step info y ""(.*)""")]
    public void WhenILogStepYInfo(string info)
    {
        Hooks.LogStepInfo(info, "fail");
        Assert.Fail("This step should fail");
    }

    [Then(@"the report should be generated successfully")]
    public void ThenTheReportShouldBeGeneratedSuccessfully()
    {
        
    }
}