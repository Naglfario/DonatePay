using DonatePay.Base.Extensions;
using DonatePay.Base.Models.Enums;

namespace DonatePay.Base.Models.Request;

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
        if (this.Limit < 1) this.Limit = 1;
        else if (this.Limit > 100) this.Limit = 100;

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
