using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class SkillTestData
    {

        public string Scenario { get; set; } = string.Empty;
        public string Skill { get; set; } = string.Empty;
        public string SkillLevel { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class SkillDataSet
    {
        public List<SkillTestData> Skills { get; set; } = new List<SkillTestData>();
    }
}
