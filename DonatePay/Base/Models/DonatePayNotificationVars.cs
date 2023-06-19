using Newtonsoft.Json;

namespace DonatePay.Base.Models;

public class DonatePayNotificationVars
{
    /// <summary>
    /// Имя донатера
    /// </summary>
    public string? Name { get; set; }    
    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; }
    /// <summary>
    /// Сумма пожертвования
    /// </summary>
    public decimal? Sum { get; set; }
    /// <summary>
    /// Валюта (ISO 4217)
    /// </summary>
    [JsonIgnore]
    public CurrencyCode Currency
    {
        get
        {
            var code = CurrencyCode.NotRecognized;
            Enum.TryParse<CurrencyCode>(this.CurrencyString, out code);
            return code;
        }
    }
    /// <summary>
    /// Строковый код валюты (ISO 4217)
    /// </summary>
    [JsonProperty("currency")]
    public string? CurrencyString { get; set; }
    public string? Target { get; set; }
    /// <summary>
    /// Информация о заказанном видео
    /// </summary>
    public DonatePayVideo? Video { get; set; }
    public string? Boss { get; set; }
    /// <summary>
    /// Стилизация оповещений
    /// </summary>
    public DonatePayPremiumSettings? PremiumSettings { get; set; }
    [JsonProperty("like")]
    public bool? IsLike { get; set; }
    [JsonProperty("social_provider")]
    public string? SocialProvider { get; set; }
    [JsonProperty("social_name")]
    public string? SocialName { get; set; }
}

public class DonatePayVideo
{
    public string? Link { get; set; }
    public string? Id { get; set; }
    public int? Start { get; set; }
    public int? Finish { get; set; }
    public string? Title { get; set; }
    public DonatePayVideoChannel? Channel { get; set; }
    [JsonProperty("image")]
    public string? ImageUrl { get; set; }
    [JsonProperty("live")]
    public bool? IsLive { get; set; }
    public int? Duration { get; set; }
    public int? Views { get; set; }
    public int? Likes { get; set; }
    public int? Dislikes { get; set; }
    [JsonProperty("embeddable")]
    public bool? IsEmbeddable { get; set; }
}
public class  DonatePayVideoChannel
{
    public string? Id { get; set; }
    public string? Title { get; set; }

}

public class DonatePayPremiumSettings
{
    public string? Image { get; set; }
    public string? Effect { get; set; }
    public string? Voice { get; set; }
    public string? Emotion { get; set; }
    public string? Speed { get; set; }
}
