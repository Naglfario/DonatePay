using AutoFixture;
using DonatePay.Base;
using DonatePay.Base.Models.Request;
using DonatePay.Base.Models.Response;
using System;
using System.Threading.Tasks;

namespace DonatePay
{
    public class DonatePayClient : HttpBase, IDonatePayClient
    {
        private readonly string _token;
        private readonly string _userUrl;
        private readonly string _transUrl;
        private readonly string _createFakeUrl;
        private readonly string _notifUrl;
        private readonly Fixture _fixture;
        /// <summary>
        /// Инициализация DonatePay клиента
        /// </summary>
        /// <param name="Token">Токен можно получить в личном кабинете: https://donatepay.ru/page/api</param>
        /// <param name="BaseUrl">В случае, если URL для API резко изменится, или старый домен заблокируют,
        /// можно будет быстро поменять базовый API URL.</param>
        public DonatePayClient(string Token, string BaseUrl = "https://donatepay.ru/api/v1/")
        {
            string tokenUrlParam = "?access_token=" + Token;

            _token = Token;

            _userUrl = BaseUrl + "user" + tokenUrlParam;
            _transUrl = BaseUrl + "transactions" + tokenUrlParam;
            _createFakeUrl = BaseUrl + "notification";
            _notifUrl = BaseUrl + "notifications" + tokenUrlParam;

            _fixture = new Fixture();
        }

        /// <summary>
        /// Создать фейковую запись о донате
        /// /notification
        /// </summary>
        public async Task<CreateNotificationResponse> CreateNotification(CreateNotificationFilter filter = null)
        {
            if (filter == null)
            {
                filter = new CreateNotificationFilter
                {
                    Comment = _fixture.Create<string>(),
                    Name = _fixture.Create<string>().Substring(0, 16),
                    Date = DateTime.Now,
                    Notification = _fixture.Create<bool>(),
                    Sum = _fixture.Create<decimal>(),
                };
            }
            return await Post<CreateNotificationResponse>(_createFakeUrl, filter.AsDct(_token));
        }

        /// <summary>
        /// Получить список оповещений
        /// /notifications
        /// </summary>
        public async Task<GetNotificationsResponse> GetNotifications(GetNotificationsFilter filter = null)
        {
            if(filter == null) filter = new GetNotificationsFilter();
            var urlParams = filter.ToString();
            return await Get<GetNotificationsResponse>(_notifUrl + urlParams);
        }

        /// <summary>
        /// Получить список транзакций
        /// /transactions
        /// </summary>
        public async Task<TransactionsResponse> GetTransactions(TransactionsFilter filter = null)
        {
            if(filter == null) filter = new TransactionsFilter();
            string urlParams = filter.AsUrlParams();
            var response = await Get<TransactionsResponse>(_transUrl + urlParams);
            response.Transactions?.HtmlDecode();
            return response;
        }

        /// <summary>
        /// Получить информацию о пользователе, с токеном которого был проиициализирован клиент.
        /// /user
        /// </summary>
        public async Task<UserResponse> GetUserAsync()
        {
            return await Get<UserResponse>(_userUrl);
        }
    }
}