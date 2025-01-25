using NUnit.Framework;
using SimpleSpecflowExtentReport.PagesObjectModels;
using SimpleSpecflowExtentReport.Utility;
using TechTalk.SpecFlow;

namespace SimpleSpecflowExtentReport.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        Launch pages = new Launch();
        [Given(@"I have initialized the ExtentReport")]
        public void GivenIHaveInitializedTheExtentReport()
        {
            ExtentReport.LogStepInfo("Given step info", "info");

            pages.PagePrint();
        }

        [When(@"I create a feature named ""(.*)""")]
        public void WhenICreateAFeatureNamed(string featureName)
        {
            ExtentReport.LogStepInfo("When step info 2", "info");
            pages.PagePrint();
        }

        [When(@"I create a scenario named ""(.*)""")]
        public void WhenICreateAScenarioNamed(string scenarioName)
        {
            ExtentReport.LogStepInfo("When step info 1", "info");
        }

        [When(@"I create a scenario named y ""(.*)""")]
        public void WhenICreateAScenariyoNamed(string scenarioName)
        {
            ExtentReport.LogStepInfo("When step info 1", "warning");
            Assert.Fail("This step should fail");
        }
        [When(@"I create a step named ""(.*)""")]
        public void WhenICreateAStepNamed(string stepName)
        {
            ExtentReport.LogStepInfo("When step info", "info");
        }

        [When(@"I log step info ""(.*)""")]
        public void WhenILogStepInfo(string info)
        {
            ExtentReport.LogStepInfo(info, "info");
        }

        [When(@"I log step info y ""(.*)""")]
        public void WhenILogStepYInfo(string info)
        {
            ExtentReport.LogStepInfo(info, "fail");
            Assert.Fail("This step should fail");
        }

        [Then(@"the report should be generated successfully")]
        public void ThenTheReportShouldBeGeneratedSuccessfully()
        {

        }
    }
}