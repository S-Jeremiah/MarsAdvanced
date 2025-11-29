using MARSCOMPETITION.Model;
using MARSCOMPETITION.Pages;
using MARSCOMPETITION.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Steps
{
    public class LoginSteps
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
        }

        public void LoginAction(LoginTestData login)
        {
            loginPage.NavigateToLoginPage();
            loginPage.Login(login.EmailID, login.Password);

            switch (login.ExpectedResult)
            {
                case "Success":
                    var homePage = new HomePage(driver!);
                    string actualUsername = homePage.GetLoggedInUserName();
                    string expectedUsername = "Hi Shirley"; 
                    Assert.That(actualUsername, Is.EqualTo(expectedUsername),
                        $"Login failed for scenario: {login.Scenario}. Expected: '{expectedUsername}', Actual: '{actualUsername}'");
                    break;

                case "InvalidEmail":
                    string actualEmailError = loginPage.GetInvalidEmailMessage();
                    string expectedEmailError = "Please enter a valid email address";
                    Assert.That(actualEmailError, Is.EqualTo(expectedEmailError),
                        $"Scenario: {login.Scenario}. Expected: '{expectedEmailError}', Actual: '{actualEmailError}'");
                    break;

                case "WrongPassword":
                    string actualPwdError = loginPage.GetWrongPwdMessage();
                    string expectedPwdError = "Confirm your email";
                    Assert.That(actualPwdError, Is.EqualTo(expectedPwdError),
                        $"Scenario: {login.Scenario}. Expected: '{expectedPwdError}', Actual: '{actualPwdError}'");
                    break;

                case "BlankPassword":
                    string actualBlankError = loginPage.GetBlankPwdMsg();
                    string expectedBlankError = "Password must be at least 6 characters";
                    Assert.That(actualBlankError, Is.EqualTo(expectedBlankError),
                        $"Scenario: {login.Scenario}. Expected: '{expectedBlankError}', Actual: '{actualBlankError}'");
                    break;

                default:
                    Assert.Fail($"Unknown ExpectedResult: {login.ExpectedResult} in scenario: {login.Scenario}");
                    break;
            }
        }

        
    }

}
