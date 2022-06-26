using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Models
{
    public partial class PutBookRequest
    {
        [JsonProperty("bookToUpdate")]
        public BookToUpdate BookToUpdate { get; set; }
    }

    public partial class BookToUpdate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
    }
}

