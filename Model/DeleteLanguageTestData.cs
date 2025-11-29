using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Model
{
    public class DeleteLanguageTestData
    {
        public string Scenario { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Level { get; set; }= string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
    public class DeleteLanguageDataSet
    {
        public List<DeleteLanguageTestData> Languages { get; set; } = new List<DeleteLanguageTestData>();
    }
}
