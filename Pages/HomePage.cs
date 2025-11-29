using MarsAdvanced.Model;
using MARSCOMPETITION.Driver;
using MARSCOMPETITION.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.DevTools.V140.Profiler;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSCOMPETITION.Pages
{
    public class HomePage : CommonDriver
    {

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private By loggedInUserName = By.XPath("//div[@class='ui compact menu']//span[contains(@class,'dropdown') and contains(@class,'link')][last()]");
        private By dropdownAvailability = By.XPath("//select[@name='availabiltyType']");
        private By dropdownHours = By.XPath("//select[@name='availabiltyHour']");
        private By dropdownEarnTarget = By.XPath("//select[@name='availabiltyTarget']");
        private By editBtn = By.XPath("//i[contains(@class,'right floated outline small write icon')]");
        private By editBtn1 = By.XPath("//i[contains(@class,'right floated outline small write icon')]");
        private By dropdownbtn = By.XPath("//div[@class='title']//i[contains(@class,'dropdown icon')]");
        private By cancelBtn = By.XPath("//div[@class='title active']//button[contains(text(),'remove icon')]");
        private By messagebox = By.XPath("//div[@class='ns-box-inner']");
        private By shareSkillBtn = By.XPath("//a[contains(text(),'Share Skill')]");
        private By notificationTab = By.XPath("//div[@class='ui top left pointing dropdown item']");
        private By SeeAllBtn = By.XPath("//a[contains(text(),'See All')]");
        private By LoadMoreBtn = By.XPath("//a[contains(text(),'Load More...')]");
        private By ShowLessBtn = By.XPath("//a[contains(text(),'...Show Less')]");
        private By CheckBoxbtn=By.XPath("(//input[@type='checkbox'])[1]");
        private By DeleteBtn= By.XPath("//div[@data-tooltip='Delete selection']");
        private By SelectAllBtn = By.XPath("//div[@data-tooltip='Select all']");
        private By DeselectAllBtn = By.XPath("//div[@data-tooltip='Unselect all']"); 
        private By MarkasReadBtn=By.XPath("//div[@data-tooltip='Mark selection as read']");

        //tagname[contains(@attribute, 'value')]
        //tagname[contains(text(), 'partialText')]
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }


        public string GetLoggedInUserName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));


            IWebElement userElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loggedInUserName));
            return userElement.Text;  // Returns the displayed username
        }
        public void ClickEditProfile()
        {
            var editProfileBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editBtn));
            editProfileBtn.Click();
        }


        public void SelectAvailability(string AvailabilityValue)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var editbtun = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'item') and .//strong[text()='Availability']]//i[contains(@class,'write icon')]")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editbtun);
            editbtun.Click();
            var levelElement = driver.FindElement(dropdownAvailability);
            var select = new SelectElement(levelElement);
            if (!string.IsNullOrWhiteSpace(AvailabilityValue))
                select.SelectByValue(AvailabilityValue);

        }

        public void SelectHours(string HoursValue)
        {
            var editbtun1 = driver.FindElement(By.XPath("//div[contains(@class,'item') and .//strong[text()='Hours']]//i[contains(@class,'write icon')]"));
            editbtun1.Click();
            var levelElement = driver.FindElement(dropdownHours);
            var select = new SelectElement(levelElement);
            if (!string.IsNullOrWhiteSpace(HoursValue))
                select.SelectByValue(HoursValue);


        }

        public void SelectEarn(string EarnTargetValue)
        {
            var editbtun2 = driver.FindElement(By.XPath("//div[contains(@class,'item') and .//strong[text()='Earn Target']]//i[contains(@class,'write icon')]"));
            editbtun2.Click();

            var levelElement = driver.FindElement(dropdownEarnTarget);
            var select = new SelectElement(levelElement);
            if (!string.IsNullOrWhiteSpace(EarnTargetValue))
                select.SelectByValue(EarnTargetValue);


        }
        /* public void SelectEarn(string Earntarget)
         {

             ClickEditProfile();
             var earn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(dropdownEarnTarget));
             var select = new SelectElementearn);
             select.SelectByText(Earntarget);
             IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             js.ExecuteScript("arguments[0].dispatchEvent(new Event('change'))", earn);
             Thread.Sleep(200);

         }*/
        public string GetMessage()
        {
            try
            {
                var errorElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(messagebox));
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

        public void Clickdropdown()
        {
            var dropdown = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(dropdownbtn));
            dropdown.Click();
        }

        public void setProfileData(ProfileTestData profile)
        {

            ClickEditProfile();
            SelectAvailability(profile.AvailabilityValue);
            SelectHours(profile.HoursValue);
            SelectEarn(profile.EarnTargetValue);
        }
        public void EditProfile(EditProfileTestData profile)
        {

            SelectAvailability(profile.NewAvailabilityValue);
            SelectHours(profile.NewHoursValue);
            SelectEarn(profile.NewEarnTargetValue);
        }
        public void ClickShareSkillBtn()
        {
            var addShareNewBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(shareSkillBtn));
            addShareNewBtn.Click();
        }
        public void ClickNotification()
        {
            var notification = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(notificationTab));
            notification.Click();
        }
        public void ClickSeeall()
        {

            var clickallBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SeeAllBtn));
            clickallBtn.Click();
            Thread.Sleep(1000);
        }

        public void ClickLoadMore()
        {
            var loadmoreBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LoadMoreBtn));
            loadmoreBtn.Click();
        }
        public void ClickShowLess()
        {
            var showlessBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ShowLessBtn));
            showlessBtn.Click();
        }

        public void clickCheckBox()
        {
            var checkboxbtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(CheckBoxbtn));
            checkboxbtn.Click();
        }

        public void ClickDeleteBtn()
        {
            var deletebtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(DeleteBtn));
            deletebtn.Click();
        }
        public void ClickSelectAllBtn()
        {
            var selectallbtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SelectAllBtn));
            selectallbtn.Click();
        }
        public void ClickDeselectAllBtn()
        {
            var deselectallbtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(DeselectAllBtn));
            deselectallbtn.Click();
        }
        public void ClickMarkasReadBtn()
        {
            var markasreadbtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(MarkasReadBtn));
            markasreadbtn.Click();
        }

    }
}