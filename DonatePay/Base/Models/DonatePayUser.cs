using Newtonsoft.Json;

namespace DonatePay.Base.Models;

public class DonatePayUser
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
    public decimal Balance { get; set; }
    [JsonProperty("cashout_sum")]
    public decimal CashoutSum { get; set; } 

}
