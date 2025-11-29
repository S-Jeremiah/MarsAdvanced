using MarsAdvanced.Model;
using MarsAdvanced.Pages;
using MARSCOMPETITION.Tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Steps
{
    public class SkillSteps
    {
        private readonly IWebDriver driver;
        private readonly SkillPage skillPage;

        public SkillSteps(IWebDriver driver)
        {
            this.driver = driver;
            skillPage = new SkillPage(driver);
        }

        public void AddingSkill(SkillTestData skill)
        {
            skillPage.ClickAddNewSkill();
            skillPage.EnterSkill(skill.Skill);
            skillPage.EnterSkillLevel(skill.SkillLevel);
            skillPage.ClickAddSkillButton();
            string actualmsg = skillPage.GetMessage();
            switch (skill.ExpectedResult)
            {
                case "Success":
                    Assert.That(actualmsg, Is.EqualTo(skill.Skill + " has been added to your skills"),
                        $"Scenario: {skill.Scenario}. Expected success but got: {actualmsg}");
                    break;
                case "BlankSkill":
                case "BlankLevel":
                    Assert.That(actualmsg, Is.EqualTo("Please enter skill and experience level"),
                        $"Scenario: {skill.Scenario}. Expected 'Please enter skill and level' but got: {actualmsg}");
                    break;
                case "Information already Exist":
                    Assert.That(actualmsg, Is.EqualTo("This skill is already exist in your skill list."),
                        $"Scenario: {skill.Scenario}. Expected duplicate warning but got: {actualmsg}");
                    break;
            }
        }

        public void Editingskill(EditSkillTestData skill)
        {
            skillPage.OpenSkillsTab();
            skillPage.AddSkill(new SkillTestData
            {
                Skill = skill.ExistingSkill,
                SkillLevel = skill.ExistingLevel,
                ExpectedResult = "Success",
            });
            Thread.Sleep(500);
            skillPage.EditSkill(skill);
            string actualmsg = skillPage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo(skill.NewSkill + " has been updated to your skills"),
                $"Scenario: {skill.Scenario}. Expected success but got: {actualmsg}");  
            BaseTest.TrackAddedSkill(skill.NewSkill);
        }

        public void DeletingSkill(DeleteSkillTestData skill)
        {
            skillPage.OpenSkillsTab();
            skillPage.AddSkill(new SkillTestData
            {
                Skill = skill.Skill,
                SkillLevel = skill.Level,
                ExpectedResult = "Success"
            });
            Thread.Sleep(500);
            skillPage.DeleteSkill(skill);
            string actualmsg = skillPage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo(skill.Skill + " has been deleted"),
                $"Scenario: {skill.Scenario}. Expected success but got: {actualmsg}");
            

        }
    }
}
