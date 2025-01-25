using TechTalk.SpecFlow;
using NUnit.Framework;

[Binding]
public class CalcSteps
{
    private string input1;
    private string input2;
    private string result;

    [Given(@"I have entered ""(.*)"" and ""(.*)""")]
    public void GivenIHaveEnteredAnd(string input1, string input2)
    {
        this.input1 = input1;
        this.input2 = input2;
    }

    [When(@"I press add")]
    public void WhenIPressAdd()
    {
        if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2))
        {
            result = (num1 + num2).ToString();
        }
        else
        {
            result = "Please enter valid numbers";
        }
    }

    [Then(@"the result should be ""(.*)""")]
    public void ThenTheResultShouldBe(string expectedResult)
    {
        Assert.AreEqual(expectedResult, result);
    }
}