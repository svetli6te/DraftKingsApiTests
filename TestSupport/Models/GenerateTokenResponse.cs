using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftKings.APITests.TestSupport.Models
{
    public class GenerateTokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiresAt")]
        public string ExpiresAt { get; set; }
    }
}
