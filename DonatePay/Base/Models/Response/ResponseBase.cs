using Newtonsoft.Json;
using System;

namespace DonatePay.Base.Models.Response
{
    public class ResponseBase
    {
        public string Status { get; set; }
        public DateTime? Time { get; set; }
        [JsonProperty("jqXHR")]
        public ResponseError Error { get; set; }
    }
}