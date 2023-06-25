using DonatePay.Base;
using DonatePay.Base.Models.Request;
using DonatePay.Tests.Infrastructure;
using FluentAssertions;

namespace DonatePay.Tests
{
    /// <summary>
    /// ���� ����� ����� ����-������� ����� ������������� �������� �� �������,
    /// �� �� DonatePay ����� ��� 429 � ���� ����������.
    /// ������� ���������� TestProiority � ���� �������� � 15 ������.
    /// </summary>
    [TestCaseOrderer(
    ordererTypeName: "DonatePay.Tests.Infrastructure.PriorityOrderer",
    ordererAssemblyName: "DonatePay.Tests")]
    public class ClientIntegrationTests
    {
        private readonly IDonatePayClient _client;
        private readonly GetNotificationsFilter _getNotiFilter;
        private readonly TransactionsFilter _transFilter;
        public ClientIntegrationTests()
        {

            _client = new DonatePayClient("INSERT_YOUR_DONATEPAY_TOKEN_HERE");


            Random rnd = new Random();
            _getNotiFilter = new GetNotificationsFilter() { Limit = rnd.Next(25, 101) };
            _transFilter = new TransactionsFilter() { Limit = rnd.Next(25, 101) };
            Thread.Sleep(15000);
        }

        [Fact(DisplayName = "1. �������� ������� ������� �������� ����������"), TestPriority(0)]
        public async void CreateFakeTransaction()
        {
            var response = await _client.CreateNotification();

            response.Should().NotBeNull();
            response.Error.Should().BeNull();
            response.Message.Should().NotBeNull();
            response?.Message?.Length.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "2. �������� ������� ��������� �������"), TestPriority(1)]
        public async void GetUserTest()
        {
            var userResponse =  await _client.GetUserAsync();

            userResponse.Should().NotBeNull();
            userResponse.Error.Should().BeNull();
            userResponse.User.Should().NotBeNull();
            userResponse?.User?.Id.Should().BeGreaterThan(0);
            userResponse?.User?.Balance.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact(DisplayName = "3. �������� ������� ��������� ������ ����������"), TestPriority(2)]
        public async void GetTransactionsTest()
        {
            var transResponse = await _client.GetTransactions(_transFilter);

            transResponse.Should().NotBeNull();
            transResponse.Error.Should().BeNull();
            transResponse.Transactions.Should().NotBeNull();
            transResponse.Transactions.Should().HaveCountGreaterThan(0);
            transResponse.Transactions.Should().HaveCountLessThanOrEqualTo(_transFilter.Limit);
        }

        [Fact(DisplayName = "4. �������� ������� ��������� ������ ����������"), TestPriority(3)]
        public async void GetNotificationsTest()
        {
            var transResponse = await _client.GetNotifications(_getNotiFilter);

            transResponse.Should().NotBeNull();
            transResponse.Error.Should().BeNull();
            transResponse.Notifications.Should().NotBeNull();
            transResponse.Notifications.Should().HaveCountGreaterThan(0);
            transResponse.Notifications.Should().HaveCountLessThanOrEqualTo(_getNotiFilter.Limit);
        }


    }
}