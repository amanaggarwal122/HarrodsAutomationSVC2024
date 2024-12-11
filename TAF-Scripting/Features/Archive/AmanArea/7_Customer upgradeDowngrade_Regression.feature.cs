// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TAF_Scripting.Features.Archive.AmanArea
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Customer upgradeDowngrade_Regression")]
    public partial class CustomerUpgradeDowngrade_RegressionFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "7_Customer upgradeDowngrade_Regression.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customer upgradeDowngrade_Regression", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade")]
        [NUnit.Framework.CategoryAttribute("SVCRegression")]
        [NUnit.Framework.CategoryAttribute("G07")]
        [NUnit.Framework.CategoryAttribute("221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade")]
        [NUnit.Framework.TestCaseAttribute("TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade", "TestDataSSCRegressionUpgrade", "G07", null)]
        public virtual void TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade(string userCategory, string excelFile, string sheetName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SVCRegression",
                    "G07",
                    "221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade", null, @__tags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("I launch the \"SSC\" website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When("I Navigate to SSC > Service > Tickets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And(string.Format("I enter all the mandatory details and create ticket for {0} {1} {2}", userCategory, excelFile, sheetName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.Then(string.Format("I change the Target Tier and Validate whether the status points are automatically" +
                            " calculated and save the upgrade {0} {1} {2}", userCategory, excelFile, sheetName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 12
 testRunner.And("I change the ticket status to Solved and closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And("I close the browser window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TC_230_GreenZeroToGreenTwoTierUpgradeValidation")]
        [NUnit.Framework.CategoryAttribute("SVCRegression")]
        [NUnit.Framework.CategoryAttribute("G07")]
        [NUnit.Framework.CategoryAttribute("230_GreenZeroToGreenTwoTierUpgradeValidation")]
        [NUnit.Framework.CategoryAttribute("E2ERun")]
        [NUnit.Framework.TestCaseAttribute("TC_230_GreenZeroToGreenTwoTierUpgradeValidation", "TestDataSSCRegressionUpgrade", "G07", null)]
        public virtual void TC_230_GreenZeroToGreenTwoTierUpgradeValidation(string userCategory, string excelFile, string sheetName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SVCRegression",
                    "G07",
                    "230_GreenZeroToGreenTwoTierUpgradeValidation",
                    "E2ERun"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TC_230_GreenZeroToGreenTwoTierUpgradeValidation", null, @__tags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 23
 testRunner.Given("I launch the \"SSC\" website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
 testRunner.When("I Navigate to SSC > Tickets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.And(string.Format("I create ticket for \"Green0-Bronze\" tier upgrade from file \"{0}\" \"{1}\" \"{2}\"", userCategory, excelFile, sheetName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And("I close the browser window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade")]
        [NUnit.Framework.CategoryAttribute("SVCRegression")]
        [NUnit.Framework.CategoryAttribute("G07")]
        [NUnit.Framework.CategoryAttribute("232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade")]
        [NUnit.Framework.TestCaseAttribute("TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade", "TestDataSSCRegressionUpgrade", "G07", null)]
        public virtual void TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade(string userCategory, string excelFile, string sheetName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SVCRegression",
                    "G07",
                    "232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade", null, @__tags);
#line 37
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 38
 testRunner.Given("I launch the \"SSC\" website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 39
 testRunner.When("I Navigate to SSC > Service > Tickets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.And(string.Format("I enter all the mandatory details and create ticket for {0} {1} {2}", userCategory, excelFile, sheetName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.Then(string.Format("I change the Target Tier and Validate whether the status points are automatically" +
                            " calculated and save the upgrade {0} {1} {2}", userCategory, excelFile, sheetName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.And("I change the ticket status to Solved and closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
 testRunner.And("I close the browser window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
