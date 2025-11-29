using MarsAdvanced.Model;
using MARSCOMPETITION.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanced.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        private readonly By titleTab = By.XPath("//input[@name='title']");
        private readonly By descriptionTab = By.XPath("//textarea[@name='description']");
        private readonly By categoryTab = By.XPath("//select[@name='categoryId']");
        private readonly By subCategoryTab = By.XPath("//select[@name='subcategoryId']");
        private readonly By tagsTab = By.XPath("(//input[@class='ReactTags__tagInputField'])[1]");
        private readonly By serviceRadioBtn = By.XPath("//input[@name='serviceType' and @value='1']");
        private readonly By locationRadioBtn = By.XPath("//label[normalize-space()='On-site']");
        private readonly By creditTab = By.XPath("//input[@name='charge']");
        private readonly By saveBtn = By.XPath("//input[@value='Save']");
        private By messagebox = By.XPath("//div[@class='ns-box-inner']");
        //private readonly By dateIcon = By.XPath("//a[@role='button']//span[@class='k-sm-date-format']");
        private readonly By dateIcon = By.CssSelector("span.k-icon.k-i-calendar");
        private readonly By searchBarIcon = By.XPath("//i[@class='search link icon']");
        private readonly By SkillExchangeTab = By.XPath("(//input[@class='ReactTags__tagInputField'])[2]");
        private readonly By addedskillRows = By.XPath("//table//tbody//tr");




        public ShareSkillPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(10));
        }
        public void AddTitle(string title)
        {
            var wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(30));
            var addtitle = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(titleTab));
            addtitle.SendKeys(title);
        }
        public void AddDescription(string description)
        {
            var addDescription = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(descriptionTab));
            addDescription.SendKeys(description);
        }
        public void SelectCategory(string category)
        {
            var categoryElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(categoryTab));
            var selectCategory = new SelectElement(categoryElement);
            selectCategory.SelectByText(category);
        }
        public void SelectSubCategory(string subcategory)
        {
            var subCategoryElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(subCategoryTab));
            var selectSubCategory = new SelectElement(subCategoryElement);
            selectSubCategory.SelectByText(subcategory);
        }
        public void AddTags(List<string> tags)
        {
            foreach (var tag in tags)
            {
                var addTags = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tagsTab));
                addTags.SendKeys(tag);
                addTags.SendKeys(Keys.Enter);
            }

        }

        



        /* public void SelectServiceType(string ServiceTypeValue)
         {
             IList<IWebElement>rdos=driver!.FindElements(By.CssSelector("input[name='serviceType']"));
             foreach(var rdo in rdos)
             {
                 if(rdo.GetAttribute("value").Equals(ServiceTypeValue))
                 {
                     rdo.Click();
                 }
             }
         }*/
        public void SelectRadioBtn(string radioGroupName, string valueToSelect)
        {
            // Find all radio buttons in the group
            IList<IWebElement> radioButtons = driver!.FindElements(By.CssSelector($"input[name='{radioGroupName}']"));

            foreach (var radio in radioButtons)
            {
                if (radio.GetAttribute("value").Equals(valueToSelect))
                {
                    // Scroll into view if needed
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", radio);

                    // Click the radio button
                    radio.Click();
                    break; // Stop after clicking the correct one
                }
            }
        }
        /*public void SelectDate(string date)
        {
            var calendar = wait!.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dateIcon));
            calendar.Click();

            string currentMonth = wait.Until(
                d => d.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text);

            while (!currentMonth.Equals("December 2025"))
            {
                var nextBtn = wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                        By.XPath("//a[@class='k-link k-nav-next']")));

                nextBtn.Click();

                // wait until month changes (prevents clicking during animation)
                wait.Until(d =>
                    d.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text != currentMonth);

                currentMonth = driver.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text;
            }

            var day = wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    By.XPath("//td[@role='gridcell']//a[@class='k-link' and text()='22']")));

            day.Click();
        }*/
        public void SelectDate(string date)
        {
            var calendar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dateIcon));
            calendar.Click();

            string adate = driver!.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text;
            Thread.Sleep(500);

            while (!adate.Equals("December 2025"))
            {

                var nextbtn = driver.FindElement(By.XPath("//a[@class='k-link k-nav-next']"));
                nextbtn.Click();

                wait.Until(d =>
                d.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text != adate);

                adate = driver.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text;

            }

            var day = wait.Until(ExpectedConditions.ElementToBeClickable(
            By.XPath("//td[@role='gridcell']//a[@class='k-link' and text()='22']")));
            day.Click();

        }
        /*  public void SelectDate(string date)
         {
             // Convert "2025-12-21" → DateTime
             DateTime target = DateTime.Parse(date);

             // Extract calendar parts
             string targetMonth = target.ToString("MMMM yyyy"); // "December 2025"
             string targetFullTitle = target.ToString("dddd, MMMM dd, yyyy"); // "Sunday, December 21, 2025"
             string dayNumber = target.Day.ToString(); // "21"

             var calendar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(dateIcon));
             calendar.Click();

             string currentMonth = driver.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text;

             // Navigate until the required month appears
             while (!currentMonth.Equals(targetMonth))
             {
                 var nextbtn = driver.FindElement(By.XPath("//a[@class='k-link k-nav-next']"));
                 nextbtn.Click();
                 currentMonth = driver.FindElement(By.XPath("//a[@class='k-link k-nav-fast']")).Text;
             }

             // Click the date by 'title' attribute (this is correct)
             var day = driver.FindElement(By.XPath($"//td[@role='gridcell']//a[@title='{targetFullTitle}']"));
             day.Click();
         }*/
        public void ScrollToElement(By locator)
        {
            var element = driver!.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }




        public void EnterCredit(string credit)
        {
            var creditvalue = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(creditTab));
            creditvalue.SendKeys(credit);

        }

        public void SaveSkill()
        {
            var saveskillbtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(saveBtn));
            saveskillbtn.Click();
        }
        public string GetMessage()
        {
            try
            {
                var errorElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(messagebox));
                return errorElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
        public void ClickManageListings()
        {
            var manageListingBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Manage Listings")));
            manageListingBtn.Click();
        }
        public void GetLastListedSkill(string expectedTitle)
        {
            // Get the first row title cell
            IWebElement titleCell = driver.FindElement(By.XPath("//tbody/tr[1]/td[3]"));

            string actualTitle = titleCell.Text.Trim();   // <-- get the text

            if (actualTitle.Equals(expectedTitle))
            {
                Console.WriteLine("Title matches the added skill!");
            }
            else
            {
                Console.WriteLine($"Title mismatch. Expected: {expectedTitle}, Found: {actualTitle}");
            }

        }

        public void ClickSearchSkill()
        {
            var searchSkillBtn = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchBarIcon));
            searchSkillBtn.Click();
        }


        public void ClickCategory(string category)
        {
            var categories = driver.FindElements(By.CssSelector("a.item.category"));

            foreach (var cat in categories)
            {
                if (cat.Text.Trim().StartsWith(category))
                {
                    cat.Click();
                    break;
                }
            }
        }
        public void Getskillname(string expectedTitle)
        {
            var titleCell = driver!.FindElements(By.XPath("//p[@class='row-padded']"));


            foreach (var titleElement in titleCell)
            {
                string actualTitle = titleElement.Text.Trim();
                if (actualTitle.Equals(expectedTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Title matches the added skill: " + actualTitle);

                    break;
                }
                else
                {
                    Console.WriteLine($"Title mismatch. Expected: {expectedTitle}, Found: {actualTitle}");
                }
            }
        }
        public void ClickSubCategory(string category, string subCategory)
        {
            var categories = driver.FindElements(By.CssSelector("a.item.category"));

            foreach (var cat in categories)
            {
                if (cat.Text.Trim().StartsWith(category))
                {
                    cat.Click();
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    wait.Until(d => d.FindElements(By.CssSelector("a.item.subcategory")).Count > 0);
                    var subCategories = driver.FindElements(By.CssSelector("a.item.subcategory"));
                    foreach (var subcat in subCategories)
                    {
                        if (subcat.Text.Trim().StartsWith(subCategory))
                        {
                            subcat.Click();
                            break;
                        }
                    }
                }
            }
        }
        public void ClickEditIcon(EditShareSkillTestData shareSkills)
        {
            ClickManageListings();
            var rows = driver.FindElements(addedskillRows);
            
            foreach(var row in rows)
            {
                var title = row.FindElement(By.XPath(".//td[3]")).Text.Trim();
                if (title.Equals(shareSkills.ExistingTitle, StringComparison.OrdinalIgnoreCase))
                {
                    // click the edit icon INSIDE this row
                    var editBtn = row.FindElement(By.XPath(".//i[contains(@class,'outline write icon')]"));
                    editBtn.Click();
                    return;
                }
            }
            

        }

        public void EditShareSkill(EditShareSkillTestData shareSkills )
        {
            
            var editTitle = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(titleTab));
            editTitle.Clear();
            editTitle.SendKeys(shareSkills.NewTitle);
            var editDescription = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(descriptionTab));
            editDescription.Clear();
            editDescription.SendKeys(shareSkills.NewDescription);
            var editCategoryElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(categoryTab));
            var editSelectCategory = new SelectElement(editCategoryElement);
            editSelectCategory.SelectByText(shareSkills.NewCategory);
            var editSubCategoryElement = wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(subCategoryTab));
            var editSelectSubCategory = new SelectElement(editSubCategoryElement);
            editSelectSubCategory.SelectByText(shareSkills.NewSubCategory);
            SaveSkill();




        }

        public void DeleteShareSkill(DeleteShareSkillTestData deleteshareskills)
        {
            ClickManageListings();
            var rows = driver.FindElements(addedskillRows);

            foreach (var row in rows)
            {
                var title = row.FindElement(By.XPath(".//td[3]")).Text.Trim();
                if (title.Equals(deleteshareskills.Title, StringComparison.OrdinalIgnoreCase))
                {
                    var deletebtn= row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]"));
                    deletebtn.Click();
                    Thread.Sleep(100);
                    var ConfirmBtn = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
                    ConfirmBtn.Click();
                    return;
                }
            }

        }
    }
}

