using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class SearchSkillCategoryTestData
    {
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }

    public class SearchSkillCategoryDataSet
    {
        public List<SearchSkillCategoryTestData> SearchSkill = new List<SearchSkillCategoryTestData>();
    }
}
