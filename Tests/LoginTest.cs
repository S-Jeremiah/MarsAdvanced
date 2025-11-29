using MarsAdvanced.Steps;
using MARSCOMPETITION.Model;
using MARSCOMPETITION.Tests;
using MARSCOMPETITION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Tests
{
    public class LoginTest : BaseTest
    {

        private LoginSteps loginSteps;
        [SetUp]
        public void Setup()
        {
            loginSteps = new LoginSteps(driver);
        }
        [Test]
        [TestCaseSource(nameof(GetLoginData))]
        public void LoginAction(LoginTestData login)
        {
            loginSteps.LoginAction(login);
        }

        public static IEnumerable<LoginTestData> GetLoginData()
        {
            var data = JsonReader.LoadJson<LoginDataSet>("TestData/LoginData.json");
            return data.Logins;
        }
    }
}
