using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MARSCOMPETITION.Driver;
using MARSCOMPETITION.Pages;
using MARSCOMPETITION.Utilities;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSCOMPETITION.Tests
{
    public class BaseTest : CommonDriver
    {
        private static List<string> AddedLanguage = new();
        private static List<string> AddedSkill = new();

        private static readonly List<string> ProtectedLanguageRecords = new()
        {
            "English"

        };
        private static readonly List<string> ProtectedSkillRecords = new()
        {
            "Coding"

        };
        protected static ExtentReports extent = ExtentManager.GetExtent();

        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            extent = ExtentManager.GetExtent();
        }

        [SetUp]
        public void Setup()
        {

            Initialise(); // Starts the browser once

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            LoginToMars();
        }

        public void LoginToMars()
        {
            try
            {
                driver!.Navigate().GoToUrl("http://localhost:5003/Home");
                test.Log(Status.Info, "Navigated to MARS Home Page");


                IWebElement SigninButton = driver.FindElement(By.XPath("//a[@class='item' and text() ='Sign In']"));
                SigninButton.Click();
                IWebElement Email = driver.FindElement(By.XPath("//input[@name='email']"));
                Email.SendKeys("jeroshirley@gmail.com");

                IWebElement password = driver.FindElement(By.XPath("//input[@name='password']"));
                password.SendKeys("World!123");
                Wait.WaitToBeClicakable(driver, "XPath", "//button[@class='fluid ui teal button']", 10);
                IWebElement LoginButton = driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
                LoginButton.Click();
                test.Log(Status.Pass, "Successfully logged in");
            }
            catch (Exception ex)
            {

                string screenshotPath = ScreenshotHelpers.CaptureScreenshot(driver!, "LoginFailed");
                test.Fail($"Login failed: {ex.Message}");
                test.AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }


        [TearDown]
        public void CleanUp()
        {
            if (driver == null) return;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            string screenshotPath;


            switch (status)
            {
                case TestStatus.Failed:
                    screenshotPath = ScreenshotHelpers.CaptureScreenshot(driver, "FailedTest");
                    test.Fail($"Test failed: {errorMessage}");
                    test.AddScreenCaptureFromPath(screenshotPath);
                    break;

                case TestStatus.Skipped:
                    test.Log(Status.Skip, "Test skipped");
                    break;

                default:
                    test.Log(Status.Pass, "Test passed");
                    break;
            }



            try
            {
                {
                    if (AddedLanguage.Any())

                        driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();

                    foreach (var lang in AddedLanguage)
                    {
                        if (ProtectedLanguageRecords.Contains(lang)) continue;
                        try
                        {
                            var row = driver.FindElement(By.XPath($"//td[text()='{lang}']/.."));
                            var deleteBtn = row.FindElement(By.XPath(".//i[@class='remove icon']"));
                            deleteBtn.Click();

                            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                .Until(d => d.FindElements(By.XPath($"//td[text()='{lang}']")).Count == 0);
                        }
                        catch
                        {

                        }
                    }
                }




                {
                    if (AddedSkill.Any())

                        driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();

                    foreach (var skl in AddedSkill)
                    {
                        if (ProtectedSkillRecords.Contains(skl)) continue;
                        try
                        {
                            var row = driver.FindElement(By.XPath($"//td[text()='{skl}']/.."));
                            var deleteBtn = row.FindElement(By.XPath(".//i[@class='remove icon']"));
                            deleteBtn.Click();

                            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                .Until(d => d.FindElements(By.XPath($"//td[text()='{skl}']")).Count == 0);
                        }
                        catch
                        {

                        }
                    }
                }

            }

            finally
            {
                // Always quit browser to ensure a clean session next time

                driver.Quit();
                driver = null;


                AddedLanguage.Clear();
                AddedSkill.Clear();

            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
            

        }

        public static void TrackAddedLanguage(string language)
        {
            if (!AddedLanguage.Contains(language))
                AddedLanguage.Add(language);
        }

        public static void TrackAddedSkill(string skill)
        {
            if (!AddedSkill.Contains(skill))
                AddedSkill.Add(skill);

        }

        
    }
}

