using Newtonsoft.Json;
namespace DonatePay.Base.Models.Response;

public class TransactionsResponse : ResponseBase
{
    [JsonProperty("data")]
    public List<DonatePayTransaction>? Transactions { get; set; }
}
