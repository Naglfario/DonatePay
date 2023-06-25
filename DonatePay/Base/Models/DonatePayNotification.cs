using DonatePay.Base.Enums;
using Newtonsoft.Json;
using System;

namespace DonatePay.Base.Models
{
    public class DonatePayNotification
    {
        /// <summary>
        /// ID оповещения
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// ID пользователя, которому пришло оповещение
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Тип оповещения
        /// </summary>
        public NotificationType Type { get; set; }
        /// <summary>
        /// Статус просмотра оповещения
        /// </summary>
        [JsonProperty("view")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool IsViewed { get; set; }
        /// <summary>
        /// Дата создания оповещения
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Дополнительные значения
        /// </summary>
        public DonatePayNotificationVars Vars { get; set; }
    }
}