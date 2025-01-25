
using SimpleSpecflowExtentReport.Utility;

namespace SimpleSpecflowExtentReport.PagesObjectModels
{
    public class Launch
    {
        public void PagePrint()
        {
            ExtentReport.LogStepInfo("I am coming from Pages.cs", "info");
        }
    }
}