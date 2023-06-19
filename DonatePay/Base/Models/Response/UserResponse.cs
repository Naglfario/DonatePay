using Newtonsoft.Json;

namespace DonatePay.Base.Models.Response;

public class UserResponse : ResponseBase
{
    [JsonProperty("data")]
    public DonatePayUser? User { get; set; }
}
