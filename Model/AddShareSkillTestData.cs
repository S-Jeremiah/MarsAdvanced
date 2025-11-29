using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class AddShareSkillTestData
    {
        public string Scenario { get; set; } = string.Empty;
       public string Title { get; set; } = string.Empty;
       public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string ServiceType { get; set; } = string.Empty;
        public string LocationType { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string SkillTrades { get; set; } = string.Empty;
        public string Credit { get; set; } = string.Empty;
        public string Active { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
        public string TargetDate { get; set; } = string.Empty;

        public string SkillExchange { get; set; } = string.Empty;


    }
    public class AddShareSkillDataSet
    {
        public List<AddShareSkillTestData> AddSkills= new List<AddShareSkillTestData>();
    }
}
