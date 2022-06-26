using DraftKings.APITests.Requests;
using DraftKings.APITests.TestSupport.Models;
using Faker;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace DraftKings.APITests.Steps
{
    [Binding]
    public sealed class BooksLibraryStepDefinitions
    {
        private readonly BookLibraryRequests requests = new BookLibraryRequests();
        private IRestResponse response;
        private string token;

        [Given(@"Valid Authorization token is generated")]
        public void GivenValidAuthorizationTokenIsGenerated()
        {
            requests.CreateUser();
            token = requests.GenerateToken();
        }


        [When(@"GET request to /Books with valid Authorisation header is sent")]
        public void WhenGetBooksRequestWithValidAuthorisationSent()
        {
            response = requests.GetBooks(token);
        }

        [When(@"GET request to /Books with no Authorisation header is sent")]
        public void WhenGetBooksRequestWithNoAuthorisationSent()
        {
            response = requests.GetBooks();
        }

        [When(@"POST request to /Books is sent")]
        public void WhenCreateBookRequestIsSent()
        {
            var book = new CreateBookRequest()
            {
                Title = "Title",
                Publisher = "Publisher",
                ReleaseDate = "2021-06-24T19:05:12.762Z",
                Author = new Author()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    DateOfBirth = "2021-06-24T19:05:12.762Z"
                }
            };
            response = requests.CreateBook(book, token);
            requests.GetBookIdFromResponse(response);
        }

        [When(@"POST request to /Books with missing title is sent")]
        public void WhenCreateBookWithMissingTitleRequestIsSent()
        {
            var book = new CreateBookRequest()
            {
                Title = null,
                Publisher = "Publisher",
                ReleaseDate = "2021-06-24T19:05:12.762Z",
                Author = new Author()
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    DateOfBirth = "2021-06-24T19:05:12.762Z"
                }
            };
            response = requests.CreateBook(book, token);
        }

        [When(@"GET request to /Books/BookId is sent")]
        public void WhenGetBookRequestIsSent()
        {
            long bookId = requests.GetBooksArray(response).First().Id;
            response = requests.GetBook(bookId);
        }

        [When(@"GET request to /Books/BookId with invalid id is sent")]
        public void WhenGetBookWithInvalidIdRequestIsSent()
        {
            long bookId = -1;
            response = requests.GetBook(bookId);
        }

        [When(@"PUT request to /Books for the first book is sent")]
        public void WhenPutRequestForFirstBookIsSent()
        {
            long bookId = requests.GetBooksArray(response).First().Id;
            string releaseDate = requests.GetBooksArray(response).First().ReleaseDate;
            var book = new PutBookRequest()
            {
                BookToUpdate = new BookToUpdate()
                {
                    Id = bookId,
                    Title = Lorem.Sentence(),
                    Publisher = Company.Name(),
                    ReleaseDate = releaseDate
                }
            };

            response = requests.UpdateBook(book, token);
        }

        [When(@"invalid PUT request to /Books for the first book is sent")]
        public void WhenInvalidPutRequestForFirstBookIsSent()
        {
            long bookId = requests.GetBooksArray(response).First().Id;
            string releaseDate = requests.GetBooksArray(response).First().ReleaseDate;
            var book = new PutBookRequest()
            {
                BookToUpdate = new BookToUpdate()
                {
                    Id = bookId,
                    Publisher = Company.Name(),
                    ReleaseDate = releaseDate
                }
            };

            response = requests.UpdateBook(book, token);
        }

        [When(@"Delete request to /Books for the first book is sent")]
        public void WhenDeleteRequestForFirstBookIsSent()
        {
            long bookId = requests.GetBooksArray(response).First().Id;

            response = requests.DeleteBook(bookId, token);
        }

        [When(@"Invalid Delete request to /Books for the first book is sent")]
        public void WhenInvalidDeleteRequestForFirstBookIsSent()
        {          
            string bookId = "abc";

            response = requests.DeleteBook(bookId, token);
        }

        [Then(@"The response code should be 200")]
        public void ResponseCodeIs200()
        {            
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"The response code should be 401")]
        public void ResponseCodeIs401()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Then(@"The response code should be 400")]
        public void ResponseCodeIs400()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Then(@"The response code should be 500")]
        public void ResponseCodeIs500()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
