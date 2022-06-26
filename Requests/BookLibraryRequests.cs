using DraftKings.APITests.TestSupport.Helpers;
using DraftKings.APITests.TestSupport.Managers;
using DraftKings.APITests.TestSupport.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.Requests
{
    public class BookLibraryRequests : ApiHelper
    {
        public IRestResponse GetBooks(string token = null)
        {
            var request = CreateGetRequest(ApiManager.GetBooksEndPoint());
            if(!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }
            
            return SendRequest(request);
        }

        public string GenerateToken()
        {
            var tokenObject = new GenerateTokenRequest()
            {
                EmailAddress = ApiManager.GetEmail(),
                Password = ApiManager.GetPassword()
            };          
            var request = CreatePostRequest(ApiManager.GetTokenEndPoint(), tokenObject);
            var response = SendRequest(request);
            var jsonData = GetResponseContent<GenerateTokenResponse>(response);
            string token = jsonData.Token;

            return token;
        }

        public void CreateUser()
        {
            var user = new CreateUserRequest()
            {
                UserName = ApiManager.GetUserName(),
                EmailAddress = ApiManager.GetEmail(),
                Password = ApiManager.GetPassword()
            };
            var request = CreatePostRequest(ApiManager.GetTokenEndPoint(), user);

            SendRequest(request);
        }

        public IRestResponse CreateBook(CreateBookRequest book, string token = null)
        {
            var request = CreatePostRequest(ApiManager.GetBooksEndPoint(), book);
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }

            return SendRequest(request);
        }

        public IRestResponse GetBook(long bookId, string token = null)
        {
            var request = CreateGetRequest(ApiManager.GetBookEndPoint().Replace("bookId", bookId.ToString()));
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }

            return SendRequest(request);
        }

        public long GetBookIdFromResponse(IRestResponse response)
        {
            var jsonData = GetResponseContent<CreateBookResponse>(response);

            return jsonData.BookId;
        }

        public IRestResponse UpdateBook(PutBookRequest book, string token = null)
        {
            var request = CreatePutRequest(ApiManager.GetBooksEndPoint(), book);
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }

            return SendRequest(request);
        }

        public IRestResponse DeleteBook(long bookId, string token = null)
        {
            var request = CreateDeleteRequest(ApiManager.GetBooksEndPoint());
            request.AddParameter("BookId", bookId);        
            
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }

            return SendRequest(request);
        }

        public IRestResponse DeleteBook(string bookId, string token = null)
        {
            var request = CreateDeleteRequest(ApiManager.GetBooksEndPoint());
            request.AddParameter("BookId", bookId);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }

            return SendRequest(request);
        }
    }
}
