using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class EditShareSkillTestData
    {
        public string Scenario { get; set; } = string.Empty;
        public string ExistingTitle { get; set; } = string.Empty;
        public string NewTitle { get; set; } = string.Empty;
        public string ExistingDescription { get; set; } = string.Empty;
        public string NewDescription { get; set; } = string.Empty;
        public string ExistingCategory { get; set; } = string.Empty;
        public string NewCategory { get; set; } = string.Empty;
        public string ExistingSubCategory { get; set; } = string.Empty;
        public string NewSubCategory { get; set; } = string.Empty;
        
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class EditShareSkillDataSet
    {
        public List<EditShareSkillTestData> ShareSkills { get; set; } = new List<EditShareSkillTestData>();


    }
}
