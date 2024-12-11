using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TAF_GenericUtility.Scripted.ROI
{
  public  class ROIAPIrequest
    {
        public static bool IsROI = false;
        public ROIAPIrequest()
        {

        }

        public static void CallROIApi(String setComplexity, String totalHours)
        {
            string propertyFile = GlobalVariables.GetscriptmateconfigPath();
            IsROI = bool.Parse(ConfigDriver.getPropertyValue(propertyFile, "ROIUpdate"));
            if (IsROI)
            try
            {
                string roiURI = ConfigDriver.getPropertyValue(GlobalVariables.GetROIConfig(), "roiURI");
                string projectName = ConfigDriver.getPropertyValue(GlobalVariables.GetROIConfig(), "project");
                string strUserName = ConfigDriver.getPropertyValue(GlobalVariables.GetROIConfig(), "username");
                string strDebugFlag = ConfigDriver.getPropertyValue(GlobalVariables.GetROIConfig(), "debug");
                string strRequestBody = "{\"Project\":\"" + projectName + "\",\"Complexity\":\"" + setComplexity
                    + "\",\"ExecutionTime\" : \"" + totalHours + "\",\"User\" : \"" + strUserName + "\",\"debug\":\""
                    + strDebugFlag + "\"} ";

                var client = new RestClient(roiURI);
                var request = new RestRequest();

                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.Parameters.Clear();
                request.AddParameter("application/json", strRequestBody, ParameterType.RequestBody);

                var response = client.Execute(request);
                var content = response.Content;
            }
            catch
            {
             Debug.WriteLine("Response status is not found");
            }
        }
    }
}
