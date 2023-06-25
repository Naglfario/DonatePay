# DonatePayClient

Эта библиотека предназначена для лёгкого взаимодействия с [API DonatePay](https://donatepay.ru/page/api) через .NET 
(.Net Core & .Net Framework & .Net Standart ofc). С помощью этой либы вы сможете:

1. Получать информацию о профиле (ID, никнейм, текущий баланс, ссылка на аватар и сумма выведенных средств за всё время)
2. Создавать фейковые оповещения о донатах — например, чтобы что-то проверить.
3. Получать список транзакций и уведомлений, в том числе указывая фильтры(критерии для поиска)

P.S. I think 100% DonatePay audience understands Russian language, but if i'm wrong — let me know in issues and i'll translate this page to English.

## Examples

### User (Profile)
```c#
    using DonatePay;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var donatePayResponse = await client.GetUserAsync();
    
    if(donatePayResponse.Error != null)
    {
        Console.WriteLine($"Ooops! Status Code: {donatePayResponse.Error.StatusCode}");
    }
    else
    {
        Console.WriteLine("User " + donatePayResponse.User.Name);
        Console.WriteLine("Id = " + donatePayResponse.User.Id);
        Console.WriteLine("Balance = " + donatePayResponse.User);
        // and etc.
    }
```
### Transactions

Чтобы получить список транзакций указывать фильтр не обязательно, но в этом случае вам будут возвращены последние 25 транзакций:

```c#
    using DonatePay;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var donatePayResponse = await client.GetTransactions();
```

Или, например, вы можете запросить 33 записи (вместо 25), и указать, чтобы их ID был в промежутке от 12345 до 999999, при этом вам нужны только завершенные транзакции (без тех, что в статусе «Отменено» или «В ожидании»), с типом «Вывод средств», и как вишенка на торте — отфильтровать вы всё это хотите по возрастанию (не суммы, а ID транзакции). Выглядеть этот запрос будет так:

```c#
    using DonatePay;
    using DonatePay.Base.Enums;
    using DonatePay.Base.Models.Request;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var filter = new TransactionsFilter
    {
        Limit = 33,
        After = 12345,
        Before = 999999,
        Order = OrderType.ASC,
        Status = TransactionStatus.Success,
        Type = TransactionType.Cashout
    };
    
    var donatePayResponse = await client.GetTransactions(filter);
```

### Create Fake Notification

Создать тестовое оповещение можно без параметров. В этом случае комментарий, имя донатера и сумма будут сгенерированы случайным образом, а дата будет подставлена текущая (`DateTime.Now`):

```c#
    using DonatePay;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var donatePayResponse = await client.CreateNotification();
```

Но вы можете настроить все необходимые параметры, которые даёт настраивать DonatePay:

```c#
    using DonatePay;
    using DonatePay.Base.Models.Request;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var filter = new CreateNotificationFilter
    {
        Comment = "Топор весит 1 кг + пол топора. Сколько весит топор?",
        Name = "Naglfario",
        Date = DateTime.Now.AddYears(-1).AddDays(-10),
        Notification = false,
        Sum = 100
    };
    
    var donatePayResponse = await client.CreateNotification(filter);
    
    if(donatePayResponse.Error != null)
    {
        Console.WriteLine($"Ooops! Status Code: {donatePayResponse.Error.StatusCode}");
    }
    else
    {
        Console.WriteLine(donatePayResponse.Message);
    }
```

### Get Notifications

Тут тоже не обязательно указывать параметры, но в этом случае автоматически вам будут возвращены последние 25 записей:

```c#
    using DonatePay;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var donatePayResponse = await client.GetNotifications();
```

Однако, при желании можно указать, что вам нужны только не просмотренные (`View = false`) оповещения, у которых ID > 12345, при этом первые 5 найденных оповещения нужно скипнуть, и если что-то осталось — вернуть последние 10 штук:

```c#
    using DonatePay;
    using DonatePay.Base.Models.Request;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var filter = new GetNotificationsFilter
    {
        Limit = 10,
        After = 12345,
        Skip = 5,
        View = false
    };
    
    var donatePayResponse = await client.GetNotifications(filter);
```

### Exceptions, Errors

Исключения никак не ловятся, поэтому обрабатывайте их сами. По идее, в случае ошибки, DonatePay декларирует, что вернет JSON ответ с некоторыми параметрами. Однако, на деле это не так, и если попытаться выполнить два запроса подряд, сайт вернет статус-код 429, но вместо джейсонины там будет raw html. Поэтому в подобных случаях эта либа в Response-объекте вернет HTML и статус-код:

```c#
    using DonatePay;
    using System.IO;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE");
    
    var firstResponse = await client.GetUserAsync(); // firstResponse.Error will be null
    var secondResponse = await client.GetUserAsync(); // secondResponse.Error will not be null
    
    Console.WriteLine(secondResponse.Error.StatusCode);
    File.WriteAllText("SecondResponseError.html", secondResponse.Error.HtmlContent);
```

P.S. Свойство `response.Error` есть у всех запросов — на создание оповещения, на получение профиля, списка транзакций, списка оповещений, но в случае если ошибки во время выполнения запроса не произошло, это свойство будет `null`

### URL params

Вы можете проверить, что объект фильтра рендерится как нужно в URL-параметры. Правда, есть нюанс — фильтр запроса на создание оповещения посылается POST-запросом, поэтому в URL-параметры не рендерится. Но в случае с получением транзакций или оповещений это можно сделать довольно легко:

```c#
    using DonatePay.Base.Enums;
    using DonatePay.Base.Models.Request;
    
    var getNotiFilter = new GetNotificationsFilter
    {
        After = 12345,
        Limit = 44,
        Order = OrderType.ASC,
        Type = NotificationType.Follower,
        Skip = 100,
        View = true
    };
    var transFilter = new TransactionsFilter
    {
        Before = 999000,
        Limit = 5,
        Order = OrderType.DESC,
        Skip = 99,
        Status = TransactionStatus.User,
        Type = TransactionType.Donation
    };
    
    Console.WriteLine(getNotiFilter.ToString());
    Console.WriteLine(transFilter.ToString());

```
### Base URL override

В случае необходимости, если DonatePay сменит домен, или ссылку на API, базовую часть ссылки можно будет легко подменить. Сейчас это https://donatepay.ru/api/v1/

```c#
    using DonatePay;
    
    var client = new DonatePayClient("INSERT_YOUR_TOKEN_HERE", "NEW BASE URL");
```