using DraftKings.APITests.TestSupport.Managers;
using DraftKings.APITests.TestSupport.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Helpers
{
    public class ApiHelper
    {
        private readonly IRestClient client;
        private IRestRequest request;

        public ApiHelper()
        {
            client = new RestClient()
            {
                BaseUrl = new Uri(ApiManager.GetBaseUrl())
            };
        }

        public IRestRequest CreateGetRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
            request.AddHeader("Accept", "application/json");

            return request;
        }

        public IRestResponse SendRequest(IRestRequest request)
        {
            return client.Execute(request);
        }

        public IRestRequest CreatePostRequest(string endpoint, object bodyObject)
        {
            request = new RestRequest(endpoint, Method.POST);
            string body = JsonConvert.SerializeObject(bodyObject);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            return request;
        }

        public IRestRequest CreatePutRequest(string endpoint, object bodyObject)
        {
            request = new RestRequest(endpoint, Method.PUT);
            string body = JsonConvert.SerializeObject(bodyObject);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            return request;
        }

        public IRestRequest CreateDeleteRequest(string endpoint)
        {
            request = new RestRequest(endpoint, Method.DELETE);

            return request;
        }

        public static ResponseModel GetResponseContent<ResponseModel>(IRestResponse response)
        {
            string content = response.Content;
            ResponseModel jsonData = JsonConvert.DeserializeObject<ResponseModel>(content);

            return jsonData;
        }

        public Book[] GetBooksArray(IRestResponse response)
        {
            var json = GetResponseContent<GetBooksResponse>(response);
            var books = json.Books;

            return books;
        }
    }
}
