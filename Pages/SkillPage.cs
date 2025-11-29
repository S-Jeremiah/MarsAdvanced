using MarsAdvanced.Model;
using MARSCOMPETITION.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Pages
{
    public class SkillPage : CommonDriver
    {

        private By skillsTab = By.XPath("//a[@data-tab='second']");
        private By addingNewButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        private By skillInput = By.XPath("//div[@data-tab='second']//input[@placeholder='Add Skill' and @name='name']");
        private By skillLevelDropdown = By.XPath("//div[@data-tab='second']//select[@name='level']");
        private By addSkillButton = By.XPath("//div[@data-tab='second']//input[@type='button' and @value='Add']");
        private By skillRows = By.XPath("//div[@data-tab='second']//table/tbody/tr");
        private By messagebox = By.XPath("//div[@class='ns-box-inner']");
        public SkillPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));
        }

        public void OpenSkillsTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(skillsTab)).Click();
        }
        public void ClickAddNewSkill()
        {
            OpenSkillsTab();
            wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addingNewButton)).Click();
        }
        public void EnterSkill(string Skill)
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            var element = driver.FindElement(skillInput);
            element.Clear();
            if (!string.IsNullOrWhiteSpace(Skill))
                element.SendKeys(Skill);
        }
        public void EnterSkillLevel(string SkillLevel)
        {
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized. Did you call Initialise()?");
            var levelElement = driver.FindElement(skillLevelDropdown);
            var selectSkill = new SelectElement(levelElement);
            if (!string.IsNullOrWhiteSpace(SkillLevel))
                selectSkill.SelectByValue(SkillLevel);
        }
        public void ClickAddSkillButton()
        {
            wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addSkillButton)).Click();

        }
        public string GetMessage()
        {
            try
            {
                var duplicateSkillElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(messagebox));
                return duplicateSkillElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public void AddSkill(SkillTestData skill)
        {
            ClickAddNewSkill();
            EnterSkill(skill.Skill);
            EnterSkillLevel(skill.SkillLevel);
            ClickAddSkillButton();
        }
        public void EditSkill(EditSkillTestData skill)
        {
            OpenSkillsTab();
            var rows = driver!.FindElements(skillRows);
            foreach (var row in rows)
            {
                string skillname = row.FindElement(By.XPath(".//td[1]")).Text.Trim();
                string skilllevel = row.FindElement(By.XPath(".//td[2]")).Text.Trim();
                if (skillname.Equals(skill.ExistingSkill, StringComparison.OrdinalIgnoreCase) &&
                    skilllevel.Equals(skill.ExistingLevel, StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]")).Click();
                    Console.WriteLine("Editing skill: " + skill.ExistingSkill);
                    var editInput = wait.Until(d => row.FindElement(By.XPath(".//input[@placeholder='Add Skill']")));
                    editInput.Clear();
                    editInput.SendKeys(skill.NewSkill);
                    Console.WriteLine("Editing skill: " + skill.ExistingSkill);
                    var levelDropdown = new SelectElement(row.FindElement(By.XPath(".//select[@name='level']")));
                    levelDropdown.SelectByValue(skill.NewLevel);
                    row.FindElement(By.XPath(".//input[@type='button' and @value='Update']")).Click();

                    wait!.Until(d => GetMessage().Contains(skill.NewSkill + " has been updated to your skills"));
                    break;
                }
            }
        }

        public void DeleteSkill(DeleteSkillTestData skill)
        {
            OpenSkillsTab();
            var rows = driver!.FindElements(skillRows);
            foreach (var row in rows)
            {
                string skillname = row.FindElement(By.XPath(".//td[1]")).Text.Trim();
                string skilllevel = row.FindElement(By.XPath(".//td[2]")).Text.Trim();
                if (skillname.Equals(skill.Skill, StringComparison.OrdinalIgnoreCase)&& 
                    skilllevel.Equals(skill.Level,StringComparison.OrdinalIgnoreCase))
                {
                    row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]")).Click();
                    wait!.Until(d => GetMessage().Contains(skill.Skill + " has been deleted"));
                    break;
                }
            }
        }


    }

}
