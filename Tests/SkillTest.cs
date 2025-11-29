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
    public class SkillTest: BaseTest
    {
        private SkillSteps skillSteps;

        [SetUp]
        public void Setup()
        {
            skillSteps = new SkillSteps(driver);
        }
        [Test]  
        [TestCaseSource(nameof(GetSkillData))]
        public void AddingSkill(SkillTestData skill)
        {
            skillSteps.AddingSkill(skill);
        }
        [Test]
        [TestCaseSource(nameof(GetEditSkillData))]
        public void EditingSkillTest(EditSkillTestData skill)
        {
            skillSteps.Editingskill(skill);
        }
        [Test]
        [TestCaseSource(nameof(GetDeleteSkillData))]
        public void DeletingSkillTest(DeleteSkillTestData skill)
        {
            skillSteps.DeletingSkill(skill);
        }
        public static IEnumerable<SkillTestData> GetSkillData()
        {
            var data = JsonReader.LoadJson<SkillDataSet>("TestData/SkillData.json");
            return data.Skills;
        }

        public static IEnumerable<EditSkillTestData> GetEditSkillData()
        {
            var data = JsonReader.LoadJson<EditSkillDataSet>("TestData/EditSkillData.json");
            return data.Skills;
        }

        public static IEnumerable<DeleteSkillTestData> GetDeleteSkillData()
        {
            var data = JsonReader.LoadJson<DeleteSkillDataSet>("TestData/DeleteSkillData.json");
            return data.Skills;
        }
    }
}
