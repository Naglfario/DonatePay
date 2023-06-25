using DonatePay.Base.Enums;
using System;

namespace DonatePay.Base.Models.Request
{
    public class GetNotificationsFilter : FilterBase
    {
        /// <summary>
        /// Тип оповещения
        /// Follower - Подписка,
        /// Donation - Пожертвование,
        /// Player - Видео
        /// </summary>
        public NotificationType? Type { get; set; }
        /// <summary>
        /// Статус просмотра оповещения
        /// </summary>
        public bool? View { get; set; }

        public override string ToString()
        {
            string result = this.AsUrlParams();

            if (this.View.HasValue)
            {
                string subStr = String.Concat(
                    nameof(this.View).ToLower(),
                    '=',
                    this.View.Value.ToString());

                string newParam = String.Concat(
                    nameof(this.View).ToLower(),
                    '=',
                    this.View.Value ? '1' : '0');

                result = result.Replace(subStr, newParam);
            }

            return result;
        }
    }
}