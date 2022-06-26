using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Models
{
    public partial class GetBooksResponse
    {
        [JsonProperty("books")]
        public Book[] Books { get; set; }

        [JsonProperty("pageInfo")]
        public string PageInfo { get; set; }
    }

    public partial class Book
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
    } 
}

