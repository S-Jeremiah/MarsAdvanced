using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class DeleteShareSkillTestData
    {
        public string Scenario { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }

    public class DeleteShareSkillDataSet
    {
        public List<DeleteShareSkillTestData> DeleteShareSkill { get; set; } = new List<DeleteShareSkillTestData>();
    }
}
