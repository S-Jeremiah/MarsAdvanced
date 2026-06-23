MarsAdvanced — Selenium C# NUnit Automation Framework
(Profile, Language, Skill & ShareSkill Modules)

A scalable end-to-end UI automation framework for the Mars Advanced web application, built using Selenium WebDriver with C# and NUnit.

The framework follows a modular and maintainable architecture, covering core user workflows such as Profile management, Language, Skills, and ShareSkill functionality.

It is designed using industry best practices including:

Page Object Model (POM)
Step Definition layer (BDD-style structure)
Data-driven testing using JSON
Strongly-typed model classes
Centralized driver management
ExtentReports HTML reporting
Screenshot capture on failure
****Tech Stack
Tool	Purpose
C#	Programming language
Selenium WebDriver	UI automation
NUnit	Test framework
ExtentReports	HTML reporting
JSON	Test data management
Excel	Additional test data source
Visual Studio	IDE
Page Object Model	Design pattern
**Project Structure
MarsAdvanced/
│
├── Driver/
│   └── CommonDriver.cs              → Central WebDriver setup & teardown
│
├── Model/                           → Strongly-typed test data models
│   ├── AddShareSkillTestData.cs
│   ├── DeleteLanguageTestData.cs
│   ├── DeleteShareSkillTestData.cs
│   ├── DeleteSkillTestData.cs
│   ├── EditLanguageTestData.cs
│   ├── EditProfileTestData.cs
│   ├── EditShareSkillTestData.cs
│   ├── EditSkillTestData.cs
│   ├── LanguageTestData.cs
│   ├── LoginTestData.cs
│   ├── ProfileTestData.cs
│   ├── SearchSkillBySubcategoryTestData.cs
│   ├── SearchSkillCategoryTestData.cs
│   └── SkillTestData.cs
│
├── Pages/                           → Page Object Model classes
│   ├── HomePage.cs
│   ├── LanguagePage.cs
│   ├── LoginPage.cs
│   ├── ShareSkillPage.cs
│   └── SkillPage.cs
│
├── Steps/                           → Step Definition layer (BDD structure)
│   ├── HomeSteps.cs
│   ├── LanguageSteps.cs
│   ├── LoginSteps.cs
│   ├── ShareSkillSteps.cs
│   └── SkillSteps.cs
│
├── TestData/                        → External JSON test data
│   ├── AddShareSkill.json
│   ├── DeleteLanguageData.json
│   ├── DeleteShareSkill.json
│   ├── DeleteSkillData.json
│   ├── EditLanguageData.json
│   ├── EditProfileData.json
│   ├── EditShareSkill.json
│   ├── EditSkillData.json
│   ├── LanguageData.json
│   ├── LoginData.json
│   ├── ProfileData.json
│   ├── SearchSkillByCategory.json
│   ├── SearchSkillBySubCategory.json
│   └── SkillData.json
│
├── Tests/                           → NUnit test classes
│   ├── BaseTest.cs
│   ├── HomeTest.cs
│   ├── LanguageTest.cs
│   ├── LoginTest.cs
│   ├── ShareSkillTest.cs
│   └── SkillTest.cs
│
├── Utilities/                       → Helper utilities
│
├── Report/
│   ├── Screenshots/                 → Failure screenshots
│   └── Steps/                      → Step logs / execution trace
│
├── ProjectEvaluation/               → Assessment or evaluation scripts
│
├── bin/
├── obj/
│
├── MarsAdvanced.csproj
├── MarsAdvanced.sln
└── MarsAdvanced.xlsx
** Test Coverage
Module	Test Scenarios
Login	Valid login, invalid login, empty fields
Profile	Edit profile, validation checks
Language	Add, edit, delete language
Skills	Add, edit, delete skills
ShareSkill	Add, edit, delete share skill listings
Search Skill	Search by category and subcategory
⚙️ Key Framework Features
***Data-Driven Testing (JSON)

All test data is externalised into the TestData/ folder.

Each module uses dedicated JSON files mapped to strongly-typed model classes, enabling:

Easy test data updates without code changes
Reusable test scenarios
Clean separation between logic and data
**Strongly-Typed Model Layer

Each operation (Add/Edit/Delete/Search) has a dedicated model class:

Ensures type safety
Prevents invalid data usage
Improves maintainability and readability
** Page Object Model (POM)

Each page has a dedicated class:

LoginPage.cs
HomePage.cs
LanguagePage.cs
SkillPage.cs
ShareSkillPage.cs

This ensures:

Clean separation of UI logic and test logic
Easy maintenance when UI changes
Reusable UI methods across tests


This improves:

Readability of test flow
Reusability of business actions
Easier mapping to test scenarios
***Reporting (ExtentReports)

The framework generates rich HTML reports including:

Pass / Fail / Skip status
Step-by-step execution logs
Screenshots on failure
Execution summary
** Screenshot Capture

Failure screenshots are automatically stored in:

Report/Screenshots/

Helps with:

Debugging failures quickly
Visual evidence of UI issues
⚙️ Central Driver Management

CommonDriver.cs handles:

Browser initialization
Driver lifecycle management
Cleanup after execution

Ensures consistency across all test executions.


** How to Run
Prerequisites
Visual Studio 2019+
.NET Framework / .NET Core
Chrome browser
NuGet packages restored
Steps
git clone <your-repo-url>
Open MarsAdvanced.sln in Visual Studio
Restore NuGet packages
Build solution (Ctrl + Shift + B)
Run tests via Test Explorer
View report:
Report/
** Skills Demonstrated
Selenium WebDriver automation (C#)
NUnit test automation framework
Page Object Model (POM)
BDD-style step abstraction
Data-driven testing using JSON
Strongly-typed test design
ExtentReports HTML reporting
Screenshot capture on failure
Scalable automation architecture design
Modular test framework development
** Optional Improvements (to make it even stronger)

If you want to upgrade this to senior-level portfolio standard, consider adding:

CI/CD pipeline (Azure DevOps / GitHub Actions)
Parallel execution (NUnit Parallel / Selenium Grid)
Logging framework (Serilog)
API automation layer (REST Sharp)
SpecFlow full BDD feature files
Dockerized test execution
