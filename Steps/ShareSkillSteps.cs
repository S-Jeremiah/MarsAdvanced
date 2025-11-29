using MarsAdvanced.Model;
using MarsAdvanced.Pages;
using MARSCOMPETITION.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Steps
{
    public class ShareSkillSteps
    {
        private readonly IWebDriver driver;
        private ShareSkillPage shareSkillPage;
        private HomePage homePage;

        public ShareSkillSteps(IWebDriver driver)
        {
            this.driver = driver;
            shareSkillPage = new ShareSkillPage(driver);
            homePage = new HomePage(driver);
        }

        public void AddingShareSkill(AddShareSkillTestData addskills)
        {
            homePage.ClickShareSkillBtn();
            shareSkillPage.AddTitle(addskills.Title);
            shareSkillPage.AddDescription(addskills.Description);
            shareSkillPage.SelectCategory(addskills.Category);
            shareSkillPage.SelectSubCategory(addskills.SubCategory);
            shareSkillPage.AddTags(addskills.Tags);
            // shareSkillPage.SelectServiceType("1");
            shareSkillPage.SelectRadioBtn("serviceType", "1");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
            shareSkillPage.SelectRadioBtn("locationType", "0");
            Thread.Sleep(500);
            // shareSkillPage.SelectDate(addskills.TargetDate);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
            shareSkillPage.SelectRadioBtn("skillTrades", "false");
            shareSkillPage.EnterCredit(addskills.Credit);
            shareSkillPage.SelectRadioBtn("isActive", "true");

            Thread.Sleep(2000);

            //shareSkillPage.SelectDate(addskills.TargetDate);
            shareSkillPage.SaveSkill();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1000);");
            Thread.Sleep(2000);

            shareSkillPage.GetLastListedSkill(addskills.Title);


        }

        public void CategorySelection(SearchSkillCategoryTestData searchSkill)
        {
            shareSkillPage.ClickSearchSkill();

            shareSkillPage.ClickCategory(searchSkill.Category);
            shareSkillPage.Getskillname(searchSkill.Title);
        }
        public void ClickSubCategory(SearchSkillBySubcategoryTestData searchSkill)
        {
            shareSkillPage.ClickSearchSkill();
            shareSkillPage.ClickSubCategory(searchSkill.Category, searchSkill.SubCategory);
            shareSkillPage.Getskillname(searchSkill.Title);
        }

        public void EditingShareSkill(EditShareSkillTestData shareSkills)
        {
            shareSkillPage.ClickManageListings();
            shareSkillPage.ClickEditIcon(shareSkills);
            shareSkillPage.EditShareSkill(shareSkills);
            shareSkillPage.Getskillname(shareSkills.NewTitle);


        }

        public void DeletingShareSkill(DeleteShareSkillTestData deleteshareskills)
        {
            shareSkillPage.ClickManageListings();
            shareSkillPage.DeleteShareSkill(deleteshareskills);
        }
    }
}
