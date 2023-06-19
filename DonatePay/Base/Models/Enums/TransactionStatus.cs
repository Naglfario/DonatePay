namespace DonatePay.Base.Models.Enums;

public enum TransactionStatus
{
    /// <summary>
    /// Завершенная транзакция
    /// </summary>
    Success,
    /// <summary>
    /// Отменённая транзакция
    /// </summary>
    Cancel,
    /// <summary>
    /// В ожидании
    /// </summary>
    Wait,
    /// <summary>
    /// Фейковая транзакция
    /// </summary>
    User
}
