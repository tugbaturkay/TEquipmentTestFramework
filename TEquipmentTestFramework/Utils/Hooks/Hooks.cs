using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEquipmentTestFramework.Pages;
using TEquipmentTestFramework.Utils.Drivers;

namespace TEquipmentTestFramework.Utils.Hooks
{
    [Binding]
    class Hooks : Page
    {
        [BeforeScenario]
        internal void StartWebDriver()
        {
            string browser = Settings.Browser;

            if (browser.Equals("Chrome") || browser.Equals("DebugChrome"))
                DriverController.Instance.StartChrome();
            else
            if (browser.Equals("Debug") || browser.Equals("InternetExplorer"))
            {
                DriverController.Instance.StartChrome();
            }
            else
            if (browser.Equals("Headless"))
                DriverController.Instance.StartHeadlessChrome();
            else
                DriverController.Instance.StartChrome();

            DriverController.Instance.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }
        [AfterScenario]
        internal static void StopWebDriver()
        {
            if (!Settings.Browser.Equals("Debug") && !Settings.Browser.Equals("DebugChrome"))
                DriverController.Instance.StopWebDriver();
        }

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extentReport;
        private static ExtentHtmlReporter htmlReporter;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            htmlReporter = new ExtentHtmlReporter(System.IO.Directory.GetCurrentDirectory() + "\\ExtentReports\\TEquipmentReports.html");
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extentReport.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }





        [BeforeScenario]
        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }


        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var stepStatus = ScenarioContext.Current.ScenarioExecutionStatus.ToString();


            if (stepStatus == "OK")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass(ScenarioContext.Current["OrderNumber"].ToString(),MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "But")
                    scenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (stepStatus == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "But")
                    scenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");


            }
            else if (stepStatus == "TestError")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                else if (stepType == "But")
                    scenario.CreateNode<But>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());

            }

            




        }
        
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReport.Flush();
        }
        public static string TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)DriverController.Instance.WebDriver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
