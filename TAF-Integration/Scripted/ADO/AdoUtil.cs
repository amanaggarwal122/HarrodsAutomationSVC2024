using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.Generic;
using TAF_GenericUtility.Scripted.Models;
using TAF_Integration.Scripted.Ado;
using TAF_Integration.Scripted.Ado.Implementations;
using TAF_Integration.Scripted.Ado.Interfaces;
using TAF_Integration.Scripted.Ado.Models;


namespace TAF_Integration.Scripted.ADO
{
    public class ADOUtil
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static List<JsonScenario> _scenarios = new List<JsonScenario>();
        private static TestPlan _testPlan = null;
        private static List<TestPoint> _testPoints = null;
        private static ITestService _testService = null;
        private static TestSuite _testSuite = null;
        private static bool _updateToActive = false;

        public ADOUtil(ITestService testService = null)
        {
            _testService = testService;

            if (_testService == null)
            {
                _testService = new TestService();
            }
        }

        public static void UpdateTestResult(List<JsonScenario> scenarios, bool enableADO, bool updateToActive = false)
        {
            _scenarios = scenarios;
            _updateToActive = updateToActive;
            UpdateTestResultStatus(enableADO);
        }

        public static void UpdateTestResultStatus(bool enableADO)
        {


            if (enableADO)
            {
                try
                {
                    log.Info("Started with ADO status update");

                    ADOConfiguration config = new ADOConfiguration().Init();

                    string testSuiteName = config.TestSuiteName;
                    string testPlanName = config.TestPlanName;
                    string projectKey = config.ProjectKey;

                    _testService = new TestService();

                    _testPlan = _testService.GetTestPlanByName(testPlanName);


                    if (_testPlan == null)
                    {
                        throw new ObjectNotFoundException($"Test Plan {testPlanName} not found ");
                    }

                    _testSuite = _testService.GetTestSuiteByName(testSuiteName, _testPlan.Id);

                    if (_testSuite == null)
                    {
                        throw new ObjectNotFoundException($"Test Suite {testSuiteName} not found ");
                    }

                    if (!_scenarios.Any())
                    {
                        ReadJson();
                    }

                    if (!_scenarios.Any())
                    {
                        throw new ObjectNotFoundException($"No scenarious found to update");
                    }

                    //Step 1.0 : get Test points

                    List<string> tgs = _scenarios.SelectMany(s => s.Tags)
                        .Distinct().Select(ts => ts).ToList()
                        .Where(t => t.StartsWith($"{projectKey}") && !t.Equals(projectKey)).ToList();

                    List<int> tstIds = new List<int>();
                    tgs.ForEach(c => tstIds.Add(int.Parse(c.Remove(0, projectKey.Length + 1))));


                  //  var tps = _testService.GetTestPoints(tstIds.ToArray());

                    List<TestPoint> testPoints = _testService.GetTestPoints(tstIds.ToArray());

                    var tps = testPoints.GroupBy(x => new { x.TestId })
                     .Select(x => new
                     {
                         TestId = x.Key.TestId,
                         Id = x.Max(z => z.Id)
                     });

                    //


                    if (!tps.Any())
                    {
                        throw new IndexOutOfRangeException($"Test points cannot be found. Please add test points");
                    }

                    //Step 1.1 : Create Test run
                    TestRun testRun = _testService.CreateTestRun(new TestRun
                    {
                        Name = $"Automation- Test Run: {DateTime.Now.ToString("ddMMyyyyHHmmss")}",
                        PlanId = _testPlan.Id,
                        Automated = false,
                        PointIds = tps.Select(p => p.Id).ToArray()
                    });

                    log.Info("Test run created");

                    //step 2 : get Test results
                    List<TestResult> testresults = _testService.GetTestResults(testRun.Id);

                    log.Info("Test results received");

                    //2. loop through each scenarios and update
                    foreach (JsonScenario scenario in _scenarios)
                    {
                        //string testCaseID = string.Empty;
                        //testCaseID = scenario.Tags.Where(t => t.StartsWith($"{projectKey}") && !t.Equals(projectKey)).FirstOrDefault();


                        //if (string.IsNullOrEmpty(testCaseID))
                        //{
                        //    continue;
                        //}
                        //testCaseID = testCaseID.Remove(0, projectKey.Length + 1);
                        //_testPoints = _testService.GetTestPoints(_testPlan.Id, _testSuite.Id, testCaseID);

                        //if (!_testPoints.Any())
                        //{
                        //    throw new IndexOutOfRangeException($"Test points for test Case {testCaseID} cannot be found. Please add test points");
                        //}                       


                        string testCaseID = string.Empty;
                        testCaseID = scenario.Tags.Where(t => t.StartsWith($"{projectKey}") && !t.Equals(projectKey)).FirstOrDefault();


                        if (string.IsNullOrEmpty(testCaseID))
                        {
                            continue;
                        }
                        testCaseID = testCaseID.Remove(0, projectKey.Length + 1);
                        string tResultId = string.Empty;
                        try {  tResultId = testresults.Where(r => r.TestCaseId.Equals(testCaseID)).FirstOrDefault().Id; }
                        catch { continue; }
                        if (string.IsNullOrEmpty(tResultId))
                        {
                            throw new NullReferenceException($"Test result cannot be found");
                        }


                        //step 3 : Update Test results

                        _testService.UpdateResult(new TestResult
                        {
                            Id = tResultId,
                            OutCome = scenario.Result.Status,
                            StackTrace = scenario.Result.Status.Equals(StatusEnum.Pass) ? string.Empty : Convert.ToString(scenario.Result.ExeptionMessage),
                            ErrorMessage = scenario.Result.Status.Equals(StatusEnum.Pass) ? string.Empty : Convert.ToString(scenario.Result.ExeptionMessage),
                            RunId = testRun.Id
                        });

                        log.Info("Test result updated");

                        //step 5 : Add Attachment (create attachment on the test.feature -> capturescreenshot with test tag as name of the file)
                        if (config.Screenshot)
                        {
                            if (!scenario.Result.Status.Equals(StatusEnum.Pass))
                            {
                                if (!string.IsNullOrEmpty(scenario.ScreenshotPath))
                                {
                                    _testService.AddRunAttachment(new Attachment
                                    {
                                        Path = scenario.ScreenshotPath,
                                        Name = Path.GetFileName(scenario.ScreenshotPath),
                                        Comment = $"Screen Captured For test case {scenario.Name}",
                                        AttachmentType = "GeneralAttachment",
                                        RunId = testRun.Id
                                    });
                                }

                                log.Info("Test run updated with attachment");
                            }

                            //step 5 : create a bug
                            if (config.Defect && !scenario.Result.Status.Equals(StatusEnum.Pass))
                            {
                                List<WorkItem> workItems = new List<WorkItem>();
                                workItems.Add(new WorkItem
                                {
                                    Type = "Bug",
                                    Op = "add",
                                    Path = "/fields/System.Title",
                                    From = null,
                                    Value = scenario.Name
                                });

                                workItems.Add(new WorkItem
                                {
                                    Type = "Bug",
                                    Op = "add",
                                    Path = "/fields/Microsoft.VSTS.TCM.ReproSteps",
                                    From = null,
                                    Value = scenario.Result.ExeptionMessage.ToString().Substring(0, 700)
                                });

                                //workItems.Add(new WorkItem
                                //{
                                //    Type = "Issue",
                                //    Op = "add",
                                //    Path = "/fields/System.Title",
                                //    From = null,
                                //    Value = scenario.Name
                                //});

                                //workItems.Add(new WorkItem
                                //{
                                //    Type = "Issue",
                                //    Op = "add",
                                //    Path = "/fields/Microsoft.VSTS.TCM.Description",
                                //    From = null,
                                //    Value = scenario.Result.ExeptionMessage.ToString().Substring(0, 700)
                                //});

                                var defect = _testService.CreateWorkItem(workItems);

                                if (defect == null)
                                {
                                    throw new ObjectNotFoundException($"Defect not created ");
                                }

                                log.Info("defect created");


                                //step 6 : upload attachment 
                                if (config.Screenshot)
                                {
                                    if (!string.IsNullOrEmpty(scenario.ScreenshotPath))
                                    {
                                        var attachment = _testService.AddWorkItemAttachment(new Attachment
                                        {
                                            Path = scenario.ScreenshotPath,
                                            Name = Path.GetFileName(scenario.ScreenshotPath),
                                            Comment = $"Screen Captured For test case {scenario.Name}",
                                            AttachmentType = "GeneralAttachment"
                                        });

                                        if (attachment == null)
                                        {
                                            throw new ObjectNotFoundException($"Attachment not created ");
                                        }

                                        log.Info("Workitem attachment added");

                                        //step 6 : map attachment to bug

                                        _testService.MapAttachmentToWorkItem(new WorkItem
                                        {
                                            Rel = "AttachedFile",
                                            Url = attachment.Url,
                                            Op = "add",
                                            Path = "/relations/-",
                                            Comment = $"Failed Test case {scenario.Name.Replace(" ", "")}",
                                            Id = defect.Id
                                        });

                                        log.Info("Attachment linked with defect");
                                    }
                                }
                            }
                        }
                    }


                    //step 4 : Update Test run

                    string testRunComment = string.Empty;

                    testRunComment = _scenarios.Where(s => s.Result.Status.Equals(StatusEnum.Fail)).Any() ? "Test Run Failed" : "Completed Successfully";

                    _testService.UpdateRun(new TestRun
                    {
                        Id = testRun.Id,
                        State = "Completed",
                        Comment = testRunComment,
                        ErrorMessage = testRunComment
                    });

                    log.Info("Test run updated");
                }
                catch (Exception e)
                {

                    log.Error($"Error while {MethodBase.GetCurrentMethod().ReflectedType.Name} : { e.Message } :\\n {e.StackTrace}");
                }
            }
        }
        private static void ReadJson()
        {
            //2. Read Json file to object

            string filePath = PathUtil.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cucumber.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                StringBuilder json = new StringBuilder();
                json.Append(r.ReadToEnd());
                _scenarios = JsonConvert.DeserializeObject<List<JsonScenario>>(json.ToString());
            }
        }
    }
}