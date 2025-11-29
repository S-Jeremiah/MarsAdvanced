using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class EditLanguageTestData
    {
        
        public string Scenario { get; set; } = string.Empty;
        
        public string ExistingLanguage { get; set; } = string.Empty;
        public string NewLanguage { get; set; } = string.Empty;
        public string ExistingLevel { get; set; } = string.Empty;
        public string NewLevel { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class EditLanguageDataSet
    {
        public List<EditLanguageTestData> Languages { get; set; } = new List<EditLanguageTestData>();
    }
}
