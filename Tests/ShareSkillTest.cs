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
    public class ShareSkillTest : BaseTest
    {
        private ShareSkillSteps shareSkillSteps;
        [SetUp]
        public void Setup()
        {
            shareSkillSteps = new ShareSkillSteps(driver);
        }
        [Test]
        [TestCaseSource(nameof(GetShareSkillData))]
        public void AddshareSkillTest(AddShareSkillTestData addSkills)
        {
            shareSkillSteps.AddingShareSkill(addSkills);
        }
        public static IEnumerable<AddShareSkillTestData> GetShareSkillData()
        {
            var data = JsonReader.LoadJson<AddShareSkillDataSet>("TestData/AddShareSkill.json");
            return data.AddSkills;
        }
        [Test]
        [TestCaseSource(nameof(GetCategoryData))]
        public void CategorySelectionTest(SearchSkillCategoryTestData searchSkill)
        {
            shareSkillSteps.CategorySelection(searchSkill);
        }
        public static IEnumerable<SearchSkillCategoryTestData> GetCategoryData()
        {
            var data = JsonReader.LoadJson<SearchSkillCategoryDataSet>("TestData/SearchSkillByCategory.json");
            return data.SearchSkill;
        }
        [Test]
        
        [TestCaseSource(nameof(GetSubcategoryData))]
        public void SubcategorySelectionTest(SearchSkillBySubcategoryTestData searchSkill)
        {
            shareSkillSteps.ClickSubCategory(searchSkill);
        }
        public static IEnumerable<SearchSkillBySubcategoryTestData> GetSubcategoryData()
        {
            var data = JsonReader.LoadJson<SearchSkillBySubcategoryDataSet>("TestData/SearchSkillBySubcategory.json");
            return data.SearchSkill;
        }
        [Test]
        [TestCaseSource(nameof(GetEditshareskillData))]
        public void EditShareSkillTest(EditShareSkillTestData searchSkill)
        {
            shareSkillSteps.EditingShareSkill(searchSkill);
        }
        public static IEnumerable<EditShareSkillTestData> GetEditshareskillData()
        {
            var data = JsonReader.LoadJson<EditShareSkillDataSet>("TestData/EditShareSkill.json");
            return data.ShareSkills;
        }
        [Test]
        [TestCaseSource(nameof(GetDeleteShareSkillData))]
        public void DeleteShareSkillTest(DeleteShareSkillTestData shareSkills)
        {
            shareSkillSteps.DeletingShareSkill(shareSkills);
        }
        public static IEnumerable<DeleteShareSkillTestData> GetDeleteShareSkillData()
        {
            var data = JsonReader.LoadJson<DeleteShareSkillDataSet>("TestData/DeleteShareSkill.json");
            return data.DeleteShareSkill;
        }
    }
}
