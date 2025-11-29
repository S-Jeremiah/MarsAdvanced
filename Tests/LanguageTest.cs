using MarsAdvanced.Model;
using MarsAdvanced.Steps;
using MARSCOMPETITION.Tests;
using MARSCOMPETITION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Tests
{
    public class LanguageTest :BaseTest
    {
        private LanguageSteps languageSteps;

        [SetUp]
        public void Setup()
        {
            languageSteps = new LanguageSteps(driver);

        }
        [Test]
        [TestCaseSource(nameof(GetLanguageData))]
        public void AddLanguageTests(LanguageTestData language)
        {
            languageSteps.AddingLanguage(language);
        }

        [Test]
        [TestCaseSource(nameof(GetEditLanguageData))]
        public void EditLanguageTests(EditLanguageTestData language)
        {
            languageSteps.EditingLanguage(language);
        }
        [Test]  
        [TestCaseSource(nameof(GetDeleteLanguageData))]
        public void DeleteLanguageTests(DeleteLanguageTestData language)
        {
            languageSteps.DeletingLanguage(language);
        }
        public static IEnumerable<LanguageTestData> GetLanguageData()
        {
            var data = JsonReader.LoadJson<LanguageDataSet>("TestData/LanguageData.json");
            return data.Languages;
        }
        public static IEnumerable<EditLanguageTestData> GetEditLanguageData()
        {
            var data = JsonReader.LoadJson<EditLanguageDataSet>("TestData/EditLanguageData.json");
            return data.Languages;
        }
        public static  IEnumerable<DeleteLanguageTestData> GetDeleteLanguageData()
        {
            var data = JsonReader.LoadJson<DeleteLanguageDataSet>("TestData/DeleteLanguageData.json");
            return data.Languages;
        }
        
    }

}
