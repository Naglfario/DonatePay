namespace DonatePay.Base.Models.Request;

public class CreateNotificationFilter
{
    /// <summary>
    /// Имя отправителя пожертвования
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Сумма пожертвования
    /// </summary>
    public decimal Sum { get; set; } = 0.01M;
    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; }
    /// <summary>
    /// Дата создания транзакции
    /// </summary>
    public DateTime? Date { get; set; }
    /// <summary>
    /// Создавать ли оповещение о пожертвовании [По умолчанию создавать]
    /// </summary>
    public bool Notification { get; set; } = true;
}
