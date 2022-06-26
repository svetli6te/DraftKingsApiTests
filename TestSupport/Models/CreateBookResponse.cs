using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Models
{
    public class CreateBookResponse
    {
        [JsonProperty("bookId")]
        public long BookId { get; set; }

        [JsonProperty("operationMessage")]
        public string OperationMessage { get; set; }
    }
}
