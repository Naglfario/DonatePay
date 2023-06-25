using System;
using System.Collections.Generic;

namespace DonatePay.Base.Models.Request
{
    public class CreateNotificationFilter
    {
        /// <summary>
        /// Имя отправителя пожертвования
        /// </summary>
        public string Name { get; set; }
        private decimal sum = 0.01M;
        /// <summary>
        /// Сумма пожертвования
        /// </summary>
        public decimal Sum
        {
            get { return sum; }
            set
            {
                if (value < 0.01M) value = 0.01M;
                else if (value > 1000000) value = 1000000;
                sum = value;
            }
        }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Дата создания транзакции
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// Создавать ли оповещение о пожертвовании [По умолчанию создавать]
        /// </summary>
        public bool Notification { get; set; } = true;
    }
}