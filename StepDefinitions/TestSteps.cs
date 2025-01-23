using TechTalk.SpecFlow;

[Binding]
public class TestSteps
{
    [Given(@"I have initialized the ExtentReport")]
    public void GivenIHaveInitializedTheExtentReport()
    {
        // Hooks.ExtentReportInit();
    }

    [When(@"I create a feature named ""(.*)""")]
    public void WhenICreateAFeatureNamed(string featureName)
    {
        
    }

    [When(@"I create a scenario named ""(.*)""")]
    public void WhenICreateAScenarioNamed(string scenarioName)
    {
        
    }

    [When(@"I create a step named ""(.*)""")]
    public void WhenICreateAStepNamed(string stepName)
    {
        
    }

    [When(@"I log step info ""(.*)""")]
    public void WhenILogStepInfo(string info)
    {
        Hooks.LogStepInfo(info);
    }

    [Then(@"the report should be generated successfully")]
    public void ThenTheReportShouldBeGeneratedSuccessfully()
    {
        
    }
}