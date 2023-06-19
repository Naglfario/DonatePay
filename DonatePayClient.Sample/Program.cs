using DonatePay;
using DonatePay.Base.Extensions;
using DonatePay.Base.Models;
using DonatePay.Base.Models.Request;
using Newtonsoft.Json;
using System.Web;

var client = new DonatePayClient("");

//var response = await client.GetUserAsync();
//Console.WriteLine(response.User.Name);

//var test = new TransactionsFilter
//{
//    After = 1000,
//    Limit = 10000,
//    Type = DonatePay.Base.Models.Enums.TransactionType.Donation,
//    Status = DonatePay.Base.Models.Enums.TransactionStatus.Cancel
//};

//Console.WriteLine(test.ToString());
//var response = await client.GetTransactions( new TransactionsFilter { Limit = 100});

//var test = await client.GetNotifications(new GetNotificationsFilter { Limit = 100 });

Console.ReadLine();