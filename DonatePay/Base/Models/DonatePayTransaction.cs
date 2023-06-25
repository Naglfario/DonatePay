using DonatePay.Base.Enums;
using Newtonsoft.Json;
using System;

namespace DonatePay.Base.Models
{
    public class DonatePayTransaction
    {
        /// <summary>
        /// ID транзакции
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Имя пользователя от которого пришла транзакция
        /// </summary>
        [JsonProperty("what")]
        public string Nickname { get; set; }
        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public decimal Sum { get; set; }
        /// <summary>
        /// Валюта (ISO 4217)
        /// </summary>
        [JsonIgnore]
        public CurrencyCode Currency { 
            get {
                var code = CurrencyCode.NotRecognized;
                Enum.TryParse<CurrencyCode>(this.CurrencyString, out code);
                return code; }
        }
        /// <summary>
        /// Строковый код валюты (ISO 4217)
        /// </summary>
        [JsonProperty("currency")]
        public string CurrencyString { get; set; }
        /// <summary>
        /// Прибыль с транзакции
        /// </summary>
        [JsonProperty("to_cash")]
        public decimal? ToCash { get; set; }
        /// <summary>
        /// Сумма к оплате
        /// </summary>
        [JsonProperty("to_pay")]
        public decimal? ToPay { get; set; }
        /// <summary>
        /// Комиссия с оплаты
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary>
        /// Статус транзакции
        /// </summary>
        public TransactionStatus Status { get; set; }
        /// <summary>
        /// Тип транзакции
        /// </summary>
        public TransactionType Type { get; set; }
        /// <summary>
        /// Комментарий к транзакции
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Дата создания транзакции
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Дополнительные значения
        /// </summary>
        public DonatePayTransactionVars Vars { get; set; }

    }
}
