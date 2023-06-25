using Newtonsoft.Json;
using System.Collections.Generic;

namespace DonatePay.Base.Models.Response
{
    public class GetNotificationsResponse : ResponseBase
    {
        [JsonProperty("data")]
        public List<DonatePayNotification> Notifications { get; set; }
        public int? Count { get; set; }
    }
}