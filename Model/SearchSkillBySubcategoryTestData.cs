using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class SearchSkillBySubcategoryTestData
    {
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
       
    }
    public class SearchSkillBySubcategoryDataSet
    {
        public List<SearchSkillBySubcategoryTestData> SearchSkill = new List<SearchSkillBySubcategoryTestData>();
    }
}
