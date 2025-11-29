using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class EditSkillTestData
    {
        public string Scenario { get; set; } = string.Empty;
        public string ExistingSkill { get; set; } = string.Empty;
        public string NewSkill { get; set; } = string.Empty;
        public string ExistingLevel { get; set; } = string.Empty;
        public string NewLevel { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class EditSkillDataSet
    {
        public List<EditSkillTestData> Skills { get; set; } = new List<EditSkillTestData>();
    }
  }