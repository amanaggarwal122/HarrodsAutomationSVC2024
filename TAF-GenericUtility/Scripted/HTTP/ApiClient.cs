using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TAF_GenericUtility.Scripted.HTTP
{
    public class ApiClient<T> where T : class
    {
        private string _baseUri = string.Empty;
        private readonly RestClient _restClient;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApiClient(string baseUri = null)
        {
            _baseUri = baseUri;
            _restClient = new RestClient(_baseUri);
            _log.Info("Created rest api client for " + _baseUri);
        }

        public T Get(string path)
        {
            _log.Info("Calling GET " + path);
            var source = $"{path}";
            return SendHttpRequest(source, Method.GET);
        }

        public T Post(string path, T item)
        {
            _log.Info("Calling POST " + path);
            var source = $"{_baseUri}{path}";
            return SendHttpRequest(source, Method.POST, item);
        }

        public T Put(string path, T item)
        {
            _log.Info("Calling PUT " + path);
            var source = $"{_baseUri}{path}";
            return SendHttpRequest(source, Method.PUT, item);
        }

        public T Delete(string path, T item)
        {
            _log.Info("Calling DELETE " + path);
            var source = $"{_baseUri}{path}";
            return SendHttpRequest(source, Method.DELETE, item);
        }

        private T SendHttpRequest(string source, Method method, T requestPayload = null)
        {
            IRestResponse response = null;
            try
            {
                var request = new RestRequest(source, method);
                request.AddHeader("Accept", "application/json");
                if (method == Method.POST || method == Method.PUT || method == Method.PATCH || method == Method.DELETE)
                {
                    var json = JsonConvert.SerializeObject(requestPayload, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    request.AddParameter("application/json", json, ParameterType.RequestBody);
                }

                response = _restClient.Execute(request);

                if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                    return default(T);

                T data;
                try
                {

                    data = !String.IsNullOrEmpty(response.Content) ? JsonConvert.DeserializeObject<T>(response.Content)
                            : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    data = (T)Convert.ChangeType(response.Content, typeof(T));
                }
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
    }
}
