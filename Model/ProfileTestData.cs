using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class ProfileTestData
    {
        public string Scenario { get; set; } = string.Empty;

        public string AvailabilityText { get; set; } = string.Empty;
        public string AvailabilityValue { get; set; } = string.Empty;
        public string HoursText { get; set; } = string.Empty;
        public string HoursValue { get; set; } = string.Empty;
        public string EarnTargetText { get; set; } = string.Empty;
        public string EarnTargetValue { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class ProfileDataSet
    {
        public List<ProfileTestData> Profiles { get; set; } = new List<ProfileTestData>();
    }
}
