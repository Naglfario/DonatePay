using Newtonsoft.Json;
using System.Collections.Generic;

namespace DonatePay.Base.Models.Response
{
    public class TransactionsResponse : ResponseBase
    {
        [JsonProperty("data")]
        public List<DonatePayTransaction> Transactions { get; set; }
    }
}