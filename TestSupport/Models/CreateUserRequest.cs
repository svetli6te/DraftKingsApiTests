using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Models
{
    public class CreateUserRequest
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
