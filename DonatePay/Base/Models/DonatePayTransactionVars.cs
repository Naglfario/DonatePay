using Newtonsoft.Json;

namespace DonatePay.Base.Models
{
    public class DonatePayTransactionVars
    {
        /// <summary>
        /// Ник донатера
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Комментарий (без преобразования html-characters)
        /// </summary>
        [JsonProperty("comment")]
        public string RawComment { get; set; }
        /// <summary>
        /// Код платёжной системы
        /// </summary>
        [JsonProperty("payment_system")]
        public string PaymentSystem { get; set; }
        /// <summary>
        /// IP донатера
        /// </summary>
        [JsonProperty("user_ip")]
        public string UserIp { get; set; }
    }
}