using MarsAdvanced.Model;
using MarsAdvanced.Pages;
using MARSCOMPETITION.Pages;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Steps
{
    public class HomeSteps
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;

        public HomeSteps(IWebDriver driver)
        {
            this.driver = driver;
            homePage = new HomePage(driver);
        }

        public void SetProfile(ProfileTestData profile)
        {
            homePage.SelectAvailability(profile.AvailabilityValue);
            homePage.SelectHours(profile.HoursValue);
            homePage.SelectEarn(profile.EarnTargetValue);
            string actualmsg = homePage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo("Availability updated"),
                $"Scenario: {profile.Scenario}. Expected success but got: {actualmsg}");
            Assert.That(actualmsg, Is.EqualTo("Availability updated"),
                $"Scenario: {profile.Scenario}. Expected success but got: {actualmsg}");
            Assert.That(actualmsg, Is.EqualTo("Availability updated"),
                $"Scenario: {profile.Scenario}. Expected success but got: {actualmsg}");
        }

       public void EditingProfile(EditProfileTestData profile)
        {
            
            homePage.SelectAvailability(profile.ExistingAvailabilityValue);
            homePage.SelectHours(profile.ExistingHoursValue);
            homePage.SelectEarn(profile.ExistingEarnTargetValue);

            Thread.Sleep(500);
         

            homePage.EditProfile(profile);
            string actualmsg = homePage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo("Availability updated"),
                $"Scenario: {profile.Scenario}. Expected success but got: {actualmsg}");
        }

        public void ManageNotificationShowLess()
        {
            homePage.ClickNotification();
            homePage.ClickSeeall();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1000);");
            Thread.Sleep(2000);
            homePage.ClickLoadMore();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1000);");
            homePage.ClickShowLess();
            string pageText = driver.PageSource;
            //Assert.IsFalse(pageText.Contains("Service Request"), "The word should not be present on the page.");
             Assert.IsFalse(pageText.Contains("...Show Less"), "The word should not be present on the page.");
        }

        public void ManageNotificationLoadMore()
        {
            homePage.ClickNotification();
            homePage.ClickSeeall();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1000);");
            
            homePage.ClickLoadMore();
            Thread.Sleep(2000);
            var element1 = driver.FindElement(By.XPath("//a[contains(text(),'...Show Less')]"));
            string actualstring=element1.Text.Trim();
            Assert.That(actualstring, Is.EqualTo("...Show Less"),
                $"Expected '...Show Less' but got: {actualstring}");
        }

        public void ManageNotificationByDelete()
        {
            homePage.ClickNotification();
            homePage.ClickSeeall();
            homePage.clickCheckBox();
            homePage.ClickDeleteBtn();
            string actualmsg = homePage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo("Notification updated"),
                $"Expected '1 record deleted' but got: {actualmsg}");

        }

        public void SelectandDeselectAllNotifications()
        {
            homePage.ClickNotification();
            homePage.ClickSeeall();
            homePage.ClickSelectAllBtn();
            Thread.Sleep(100);
            homePage.ClickDeselectAllBtn();
        }
        public void MarkasReadNotification()
        {
            homePage.ClickNotification();
            homePage.ClickSeeall();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1000);");
            Thread.Sleep(2000);
            homePage.ClickLoadMore();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, -1000);");
            homePage.ClickSelectAllBtn();
            homePage.ClickMarkasReadBtn();
            string actualmsg = homePage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo("Notification updated"),
                $"Expected 'Notification updated' but got: {actualmsg}");
        }



    }

}
