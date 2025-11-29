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
    public class LanguageSteps
    {
        private readonly IWebDriver driver;
        private readonly LanguagePage languagePage;

        public LanguageSteps(IWebDriver driver)
        {
            this.driver = driver;
            languagePage = new LanguagePage(driver);

        }
        public void AddingLanguage(LanguageTestData language)
        {
            languagePage.ClickAddNew();
            languagePage.EnterLanguage(language.Language);
            languagePage.SelectLevel(language.Level);
            languagePage.ClickAddButton();
            string actualmsg = languagePage.GetMessage();
            switch (language.ExpectedResult)
            {
                case "Success":
                    Assert.That(actualmsg, Is.EqualTo(language.Language + " has been added to your languages"),
                        $"Scenario: {language.Scenario}. Expected success but got: {actualmsg}");
                    break;
                case "BlankLanguage":
                case "BlankLevel":

                    Assert.That(actualmsg, Is.EqualTo("Please enter language and level"),
                        $"Scenario: {language.Scenario}. Expected 'Please enter language and level' but got: {actualmsg}");
                    break;

                case "Information already Exist":
                    Assert.That(actualmsg, Is.EqualTo("This language is already exist in your language list."),
                        $"Scenario: {language.Scenario}. Expected duplicate warning but got: {actualmsg}");
                    break;

            }
            BaseTest.TrackAddedLanguage(language.Language);
        }
            
        public void EditingLanguage(EditLanguageTestData language)
        {
            languagePage.OpenLanguageTab();
            languagePage.AddLanguage(new LanguageTestData
            {
                Language = language.ExistingLanguage,
                Level = language.ExistingLevel,
                ExpectedResult = "Success"
            });
            Thread.Sleep(1000); // Wait for the language to be added before editing
            languagePage.EditLanguage(language);
            string actualmsg = languagePage.GetMessage();   
            Assert.That(actualmsg, Is.EqualTo(language.NewLanguage + " has been updated to your languages"),
                $"Scenario: {language.Scenario}. Expected success but got: {actualmsg}");
            BaseTest.TrackAddedLanguage(language.NewLanguage);  
        }
        public void DeletingLanguage(DeleteLanguageTestData language)
        {
            languagePage.OpenLanguageTab();
            languagePage.AddLanguage(new LanguageTestData
            {
                Language = language.Language,
                Level = language.Level,
                ExpectedResult = "Success"
            });
            Thread.Sleep(500); 
            languagePage.DeleteLanguage(language);
            string actualmsg = languagePage.GetMessage();
            Assert.That(actualmsg, Is.EqualTo(language.Language + " has been deleted from your languages"),
                $"Expected deletion message but got: {actualmsg}");
            
        }
    }
}

