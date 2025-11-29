using MarsAdvanced.Model;
using MARSCOMPETITION.Driver;
using MARSCOMPETITION.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Pages
{

    public class LanguagePage : CommonDriver

    {

        private By languageTab = By.XPath("//a[@data-tab='first']");
        private By addNewButton = By.XPath("//div[@data-tab='first']//div[contains(@class,'ui teal button') and text()='Add New']");
        private By languageInput = By.XPath("//div[@data-tab='first']//input[@placeholder='Add Language']");
        private By languageLevelDropdown = By.XPath("//div[@data-tab='first']//select[@name='level']");
        private By addButton = By.XPath("//div[@data-tab='first']//input[@type='button' and @value='Add']");
        private By languageRows = By.XPath("//div[@data-tab='first']//table/tbody/tr");
        private By messagebox = By.XPath("//div[@class='ns-box-inner']");

        public LanguagePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));
        }

        public void OpenLanguageTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageTab)).Click();
        }
        public void ClickAddNew()
        {
            OpenLanguageTab();
            wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addNewButton)).Click();
        }

        public void EnterLanguage(string Language)
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            var element = driver.FindElement(languageInput);
            element.Clear();
            if (!string.IsNullOrWhiteSpace(Language))
                element.SendKeys(Language);
        }
        public void SelectLevel(string Level)
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            var levelElement = driver.FindElement(languageLevelDropdown);
            var selectlanglevel = new SelectElement(levelElement);
            if (!string.IsNullOrWhiteSpace(Level))
                selectlanglevel.SelectByValue(Level);
        }
        public void ClickAddButton()
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            driver.FindElement(addButton).Click();
        }

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
        public void AddLanguage(LanguageTestData language)
        {
            ClickAddNew();
            EnterLanguage(language.Language);
            SelectLevel(language.Level);
            ClickAddButton();
            wait!.Until(d => GetMessage().Contains(language.Language + " has been added to your languages"));
        }
        public void ClickEditIcon()
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            var editIcon = driver.FindElement(By.XPath("//div[@data-tab='first']//i[@class='outline write icon']"));
            editIcon.Click();
        }
        public void EditLanguage(EditLanguageTestData language)
        {
            OpenLanguageTab();
            var rows = driver.FindElements(languageRows);
            foreach (var row in rows)
            {
                string langname = row.FindElement(By.XPath(".//td[1]")).Text.Trim();
                string langlevel = row.FindElement(By.XPath(".//td[2]")).Text.Trim();

                if (langname.Equals(language.ExistingLanguage, StringComparison.OrdinalIgnoreCase)
                    && langlevel.Equals(language.ExistingLevel, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]")).Click();
                    var editInput = wait.Until(d => row.FindElement(By.XPath(".//input[@placeholder='Add Language']")));
                    editInput.Clear();
                    editInput.SendKeys(language.NewLanguage);
                    var levelDropdown = new SelectElement(row.FindElement(By.XPath(".//select[@name='level']")));
                    levelDropdown.SelectByValue(language.NewLevel);
                    row.FindElement(By.XPath(".//input[@type='button' and @value='Update']")).Click();

                    wait!.Until(d => GetMessage().Contains(language.NewLanguage + " has been updated to your languages"));
                    break;
                }
            }
        }
        public void DeleteLanguage(DeleteLanguageTestData language)
        {
            OpenLanguageTab();
            var rows = driver.FindElements(languageRows);
            foreach (var row in rows)
            {
                string langname = row.FindElement(By.XPath(".//td[1]")).Text.Trim();
                string langlevel = row.FindElement(By.XPath(".//td[2]")).Text.Trim();
                if (langname.Equals(language.Language, StringComparison.OrdinalIgnoreCase) && langlevel.Equals(language.Level))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]")).Click();
                    wait!.Until(d => GetMessage().Contains(language.Language + " has been deleted from your languages"));
                    break;
                }
            }
        }
    }
}
