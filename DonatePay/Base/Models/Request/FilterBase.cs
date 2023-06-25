using DonatePay.Base.Enums;

namespace DonatePay.Base.Models.Request
{
    public abstract class FilterBase
    {
        private int limit = 25;
        /// <summary>
        /// Лимит записей (По умолчанию: 25. Максимальное значение: 100)
        /// </summary>
        public int Limit
        {
            get { return limit; }
            set
            {
                if (value < 1) value = 1;
                else if (value > 100) value = 100;
                limit = value;
            }
        }
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
}