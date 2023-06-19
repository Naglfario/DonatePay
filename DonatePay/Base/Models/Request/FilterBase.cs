using DonatePay.Base.Models.Enums;

namespace DonatePay.Base.Models.Request;

public abstract class FilterBase
{
    /// <summary>
    /// Лимит записей (По умолчанию: 25. Максимальное значение: 100)
    /// </summary>
    public int Limit { get; set; } = 25;
    /// <summary>
    /// Вывод будет осуществляться до указанного ID
    /// </summary>
    public long? Before { get; set; }
    /// <summary>
    /// Вывод будет осуществляться после указанного ID
    /// </summary>
    public long? After { get; set; }
    /// <summary>
    /// Смещение от начала
    /// </summary>
    public long? Skip { get; set; }
    /// <summary>
    /// Сортировка (ASC - По возрастанию; DESC - по убыванию) [По умолчанию: DESC]
    /// </summary>
    public OrderType Order { get; set; } = OrderType.DESC;
}
