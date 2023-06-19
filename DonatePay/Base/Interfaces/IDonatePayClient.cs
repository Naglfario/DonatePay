using DonatePay.Base.Models.Request;
using DonatePay.Base.Models.Response;

namespace DonatePay.Base.Interfaces;
public interface IDonatePayClient
{
    public Task<UserResponse> GetUserAsync();

    public Task<TransactionsResponse> GetTransactions(TransactionsFilter? filter = null);

    public Task<CreateNotificationResponse> CreateNotification(CreateNotificationFilter? filter = null);

    public Task<GetNotificationsResponse> GetNotifications(GetNotificationsFilter? filter = null);
}
