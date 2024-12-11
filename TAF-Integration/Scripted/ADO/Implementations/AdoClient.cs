using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using TAF_GenericUtility;
using TAF_Integration.Scripted.Ado.Models;
using TAF_Integration.Scripted.Ado.Interfaces;
using System.IO;
using System.Text;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class ADOClient : IAdoClient
    {

        string _authorizationKey = string.Empty;
        private readonly RestClient _restClient;
        private readonly string Id = "id";
        private readonly string Name = "name";
        private string _ADOUrl = string.Empty;
        private string _baseUrl = string.Empty;
        private string _project = string.Empty;
        private string _collection = string.Empty;

        public ADOClient()
        {


            ADOConfiguration config = new ADOConfiguration().Init();
            string _baseUrl = config.BaseUrl;
            string _project = config.Project;
            string _collection = config.Collection;
            string _authorizationKey = config.AuthorizationKey;
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format($":{_authorizationKey}")));

            _ADOUrl = $"{_baseUrl}/{_collection}/{_project}";
            _restClient = new RestClient(_ADOUrl);
            _restClient.AddDefaultHeader("Authorization", $"Basic {credentials}");
        }

        public List<TestPlan> GetTestPlans()
        {
            var source = $"{_ADOUrl}/_apis/test/plans?api-version=5.0";
            var response = SendHttpRequest(source, Method.GET);
            if (response == null) return null;

            var testPlans = (JArray)response["value"];
            return (from v in testPlans
                    select new TestPlan
                    {
                        Id = (string)v[Id],
                        Name = (string)v[Name],

                    }).ToList();
        }

        public List<TestSuite> GetTestSuites(string testPlanId)
        {
            var source = $"{_ADOUrl}/_apis/test/Plans/{testPlanId}/suites?api-version=5.0";
            var response = SendHttpRequest(source, Method.GET);
            if (response == null) return null;

            var testSuites = (JArray)response["value"];
            return (from v in testSuites
                    select new TestSuite
                    {
                        Id = (string)v[Id],
                        Name = (string)v[Name],
                        SuiteType = (string)v["suiteType"],
                    }).ToList();
        }

        public List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId)
        {
            var source = $"{_ADOUrl}/_apis/testplan/Plans/{testPlanId}/Suites/{testSuiteId}/TestPoint?testCaseId={testCaseId}";


            var response = SendHttpRequest(source, Method.GET);
            if (response == null) return null;

            var testPoint = (JArray)response["value"];
            return (from v in testPoint
                    select new TestPoint
                    {
                        Id = (string)v[Id],
                        Name = (string)v[Name],
                        TestId = (string)v["testCase"][Id],

                    }).ToList();
        }

        public List<TestPoint> GetTestPoints(int[] testCaseIds)
        {
            var source = $"{_ADOUrl}/_apis/test/points?api-version=6.0-preview.2";


            var response = SendHttpRequest(source, Method.POST, new
            {
                PointsFilter = new { TestcaseIds = testCaseIds }
            });

            if (response == null) return null;

            var testPoint = (JArray)response["points"];
            return (from v in testPoint
                    select new TestPoint
                    {
                        Id = (string)v[Id],
                        Name = string.Empty,

                    }).ToList();
        }

        public TestRun CreateTestRun(TestRun testRun)
        {
            var source = $"{_ADOUrl}/_apis/test/runs?api-version=5.1";

            var response = SendHttpRequest(source, Method.POST, new
            {
                name = testRun.Name,
                plan = new { id = testRun.PlanId },
                automated = testRun.Automated,
                pointIds = testRun.PointIds
            });

            if (response == null) return null;

            return new TestRun
            {
                Id = (string)response[Id],
                Name = (string)response[Name],
            };
        }

        public List<TestResult> GetTestResults(string runID)
        {
            var source = $"{_ADOUrl}/_apis/test/runs/{runID}/results?api-version=5.1";
            var response = SendHttpRequest(source, Method.GET);
            var testResults = (JArray)response["value"];
            return (from v in testResults
                    select new TestResult
                    {
                        Id = (string)v[Id],
                        Name = (string)v[Name],
                        TestCaseId= (string)v["testCase"][Id],

                    }).ToList();
        }

        public TestResult UpdateResult(TestResult testResult)
        {
            var source = $"{_ADOUrl}/_apis/test/runs/{testResult.RunId}/results?api-version=5.1";

            var response = SendHttpRequest(source, Method.PATCH, new[] {
                new
            {
                id = testResult.Id,
                outcome = testResult.OutCome,
                stackTrace =testResult.StackTrace,
                errorMessage =testResult.ErrorMessage,
                state= "Completed"
            } });

            var testResults = (JArray)response["value"];
            var results = (from v in testResults
                           select new TestResult
                           {
                               Id = (string)v[Id],
                               Name = (string)v[Name],

                           }).ToList();
            return results.FirstOrDefault();
        }

        public TestRun UpdateRun(TestRun testRun)
        {
            var source = $"{_ADOUrl}/_apis/test/runs/{testRun.Id}?api-version=5.1";
            var response = SendHttpRequest(source, Method.PATCH, new
            {
                comment = testRun.Comment,
                state = testRun.State,
                errorMessage = testRun.ErrorMessage
            });



            if (response == null) return null;

            return new TestRun
            {
                Id = (string)response[Id],
                Name = (string)response[Name],
            };
        }

        public bool AddRunAttachment(Attachment attachment)
        {
            var source = $"{_ADOUrl}/_apis/test/Runs/{attachment.RunId}/attachments?api-version=5.1-preview.1";

            Byte[] bytes = File.ReadAllBytes(attachment.Path);
            string file = Convert.ToBase64String(bytes);

            var response = SendHttpRequest(source, Method.POST, new
            {
                stream = file,
                fileName = attachment.Name,
                comment = attachment.Comment,
                attachmentType = attachment.AttachmentType
            });

            if (response == null) return false;

            return true;

        }

        public bool UpdateTest(UpdateTestCase testCase)
        {
            var source = $"{_ADOUrl}/_api/_testManagement/BulkMarkTestPoints?api-version=5.1-preview.2";
            var response = SendHttpRequest(source, Method.POST, testCase);

            if (response == null) return false;

            return true;
        }

        public Attachment AddWorkItemAttachment(Attachment attachment)
        {
            var source = $"{_ADOUrl}/_apis/wit/attachments?fileName=imageAsFileAttachment.png&api-version=5.1";
            Byte[] bytes = File.ReadAllBytes(attachment.Path);

            var response = SendHttpRequest(source, Method.POST, bytes, ParemeterType.octate);

            return new Attachment
            {
                Id = (string)response[Id],
                Url = (string)response["url"]
            };
        }

        public WorkItem CreateWorkItem(List<WorkItem> workItem)
        {
            var source = $"{_ADOUrl}/_apis/wit/workitems/${workItem.FirstOrDefault().Type}?api-version=3.0-preview";

            var list = new List<WorkItemModel>();
            workItem.ForEach(item => list.Add(new WorkItemModel { from = item.From, op = item.Op, path = item.Path, value = item.Value }));

            var response = SendHttpRequest(source, Method.PATCH, list, ParemeterType.jsonpatch);

            return new WorkItem
            {
                Id = (string)response[Id],
                Type = workItem.FirstOrDefault().Type
            };
        }

        public WorkItem MapAttachmentToWorkItem(WorkItem workItem)
        {
            var source = $"{_ADOUrl}/_apis/wit/workitems/{workItem.Id}?api-version=5.0";

            var model = new AttachmentModel
            {
                op = workItem.Op,
                path = workItem.Path,
                value = new Value
                {
                    rel = workItem.Rel,
                    url = workItem.Url,
                    attributes = new Attributes
                    {
                        comment = workItem.Comment
                    }
                }
            };

            var list = new[] { model };

            var response = SendHttpRequest(source, Method.PATCH, list, ParemeterType.jsonpatch);

            return new WorkItem
            {
                Id = (string)response[Id],

            };
        }

        public TestPlan CreateTestPlan(TestPlan testPlan)
        {
            return new TestPlan();
        }

        public TestSuite CreateTestSuite(TestSuite testSuite)
        {
            return new TestSuite();
        }

        private JContainer SendHttpRequest(string source, Method method, object requestPayload = null, ParemeterType paremeterType = ParemeterType.Json)
        {
            IRestResponse response = null;
            try
            {
                var request = new RestRequest(source, method);


                if (method != Method.GET)
                {
                    var json = JsonConvert.SerializeObject(requestPayload, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });


                    switch (paremeterType)
                    {
                        case ParemeterType.Json:
                            request.AddParameter("application/json", json, ParameterType.RequestBody);
                            break;
                        case ParemeterType.jsonpatch:
                            request.AddParameter("application/json-patch+json", json, ParameterType.RequestBody);
                            break;
                        case ParemeterType.octate:
                            _restClient.Timeout = -1;
                            request.AddHeader("Content-Type", "application/octet-stream");
                            request.AddParameter("application/octet-stream", requestPayload, ParameterType.RequestBody);
                            break;
                        default:
                            request.AddParameter("application/json", json, ParameterType.RequestBody);
                            break;
                    }
                }





                //if (method == Method.POST || method == Method.PUT)
                //{
                //    if (binaryAttachment)
                //    {                        
                //        request.AddHeader("Content-Type", "application/octet-stream");
                //        request.AddParameter("application/octet-stream", requestPayload, ParameterType.RequestBody);
                //    }
                //    else
                //    {
                //        var json = JsonConvert.SerializeObject(requestPayload, new JsonSerializerSettings
                //        {
                //            NullValueHandling = NullValueHandling.Ignore
                //        });

                //        request.AddParameter("application/json", json, ParameterType.RequestBody);
                //    }
                //}
                //else if (method == Method.PATCH)
                //{
                //    if (binaryAttachment)
                //    {
                //        _restClient.Timeout = -1;
                //        request.AddHeader("Content-Type", "application/octet-stream");
                //        request.AddParameter("application/octet-stream", requestPayload, ParameterType.RequestBody);
                //    }
                //    else
                //    {
                //        var json = JsonConvert.SerializeObject(requestPayload, new JsonSerializerSettings
                //        {
                //            NullValueHandling = NullValueHandling.Ignore
                //        });

                //        if (usePatchJson)
                //        {
                //            request.AddParameter("application/json-patch+json", json, ParameterType.RequestBody);
                //        }
                //        else
                //        {
                //            request.AddParameter("application/json", json, ParameterType.RequestBody);
                //        }
                //    }
                //}

                response = _restClient.Execute(request);
                if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                    return null;

                var data = (JContainer)JToken.Parse(response.Content);
                return data;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"ADO - The http status is:{response?.StatusCode}\nThe http content is:{response?.Content}\\nThe exception is:{e.Message}");
                return null;
            }
        }

    }

    enum ParemeterType
    {
        Json,
        jsonpatch,
        octate
    }
}
