using DonatePay.Base.Enums;

namespace DonatePay.Base.Models.Request
{
    public class TransactionsFilter : FilterBase
    {
        /// <summary>
        /// Тип транзакции (Donation - пожертвование, Сashout - вывод средств)
        /// </summary>
        public TransactionType? Type { get; set; }
        /// <summary>
        /// Статус транзакции
        /// Success - Успешно, 
        /// Cancel - Ошибка, 
        /// Wait - Ожидание, 
        /// User - Пользовательская [Тестовые пожертвования]
        /// </summary>
        public TransactionStatus? Status { get; set; }

        public override string ToString()
        {
            return this.AsUrlParams();
        }
    }
}