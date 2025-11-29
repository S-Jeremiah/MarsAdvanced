using MarsAdvanced.Model;
using MarsAdvanced.Steps;
using MARSCOMPETITION.Tests;
using MARSCOMPETITION.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Tests
{
    public class HomeTest : BaseTest
    {

        private HomeSteps homeSteps;

        [SetUp]
        public void Setup()
        {
            homeSteps = new HomeSteps(driver);
        }

        [Test]
        [TestCaseSource(nameof(GetProfileData))]
        public void ProfileTests(ProfileTestData profile)
        {
            homeSteps.SetProfile(profile);
        }
        [Test]
        [TestCaseSource(nameof(GetEditprofileData))]
        public void EditProfileTests(EditProfileTestData profile)
        {
            homeSteps.EditingProfile(profile);
        }
        [Test]
        public void NoticationTestShowLess()
        {
            homeSteps.ManageNotificationShowLess();
            
        }
        [Test]
        public void NoticationTestLoadMore()
        {
           
            homeSteps.ManageNotificationLoadMore();
        }
        [Test]
        public void DeletingNotification()
        {
            homeSteps.ManageNotificationByDelete();
        }
        [Test]
        public void SelectanDeselect()
        {
            homeSteps.SelectandDeselectAllNotifications();
        }
        [Test]
        public void MarkAllAsRead()
        {
            homeSteps.MarkasReadNotification();
        }
        public static IEnumerable<ProfileTestData> GetProfileData()
        {
            var data = JsonReader.LoadJson<ProfileDataSet>("TestData/ProfileData.json");
            return data.Profiles;
        }
       public static IEnumerable<EditProfileTestData> GetEditprofileData()
        {
            var data = JsonReader.LoadJson<EditProfileDataSet>("TestData/EditProfileData.json");
            return data.Profiles;
        }
    }
}

