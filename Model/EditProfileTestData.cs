using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class EditProfileTestData
    {
        public string Scenario { get; set; } = string.Empty;
        
        public string ExistingAvailabilityText {  get; set; } = string.Empty;

        public string ExistingAvailabilityValue { get; set; } = string.Empty;
        public string NewAvailabilityText { get; set; } = string.Empty;
        public string NewAvailabilityValue { get; set; } = string.Empty;
        public string ExistingHoursText { get; set; } = string.Empty;
        public string ExistingHoursValue { get; set; } = string.Empty;
        public string NewHoursText { get; set; } = string.Empty;
        public string NewHoursValue { get; set; } = string.Empty;
        public string ExistingEarnTargetText { get; set; } = string.Empty;
        public string ExistingEarnTargetValue { get; set; } = string.Empty;
        public string NewEarnTargetText { get; set; } = string.Empty;
        public string NewEarnTargetValue { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class EditProfileDataSet()
    {
        public List<EditProfileTestData> Profiles {  get; set; }= new List<EditProfileTestData>();
    }
}
