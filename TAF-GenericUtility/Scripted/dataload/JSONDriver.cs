using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TAF_GenericUtility.Scripted.dataload
{
   public static class JSONDriver
    {
        public static dynamic TestArgument { get; set; }
        //static string jsonFile = @"E:\work\TAF-Scripting\Resources\Chatbot Properties\ChatBotInputData.json";
        public static void JsonParser(string jsonFile)
        {
            var x = jsonFile;
            JObject j = JObject.Parse(new StreamReader(x).ReadToEnd());

            var chatbot = j.SelectToken("Chatbot");

            var testcases = chatbot.SelectToken("Testcase1");

            var steps = (JArray)testcases["Steps"];

            var question1 = steps[0].SelectToken("question1");
            var Ans1 = steps[0].SelectToken("answer1");
            
        }
      
    }
}
