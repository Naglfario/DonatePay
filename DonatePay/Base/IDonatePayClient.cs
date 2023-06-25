using DonatePay.Base.Models.Request;
using DonatePay.Base.Models.Response;
using System.Threading.Tasks;

namespace DonatePay.Base
{
    public interface IDonatePayClient
    {
        Task<UserResponse> GetUserAsync();

        Task<TransactionsResponse> GetTransactions(TransactionsFilter filter = null);

        Task<CreateNotificationResponse> CreateNotification(CreateNotificationFilter filter = null);

        Task<GetNotificationsResponse> GetNotifications(GetNotificationsFilter filter = null);
    }
}