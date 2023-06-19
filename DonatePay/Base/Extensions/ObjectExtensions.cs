using DonatePay.Base.Models.Request;
using System.Text;
using System.Web;

namespace DonatePay.Base.Extensions;

public static class ObjectExtensions
{
    public static string AsUrlParams(this object obj)
    {
        var keyValueArr = GetKeyValueArray(obj);
        var sb = new StringBuilder();
        foreach (var item in keyValueArr)
        {
            if(item.Value != null)
            {
                sb.Append('&');
                sb.Append(item.Name.ToLower());
                sb.Append('=');
                sb.Append(item.Value);
            }
        }
        return sb.ToString();
    }

    private static (string Name, object? Value)[] GetKeyValueArray(object obj)
    {
        var keyValueArr = obj.GetType().GetProperties()
        .Where(x => x.GetValue(obj, null) != null)
        .Select(x => ( x.Name, x.GetValue(obj, null) ))
        .ToArray();
        return keyValueArr;
    }
    
    public static Dictionary<string, string> AsDct(this CreateNotificationFilter filter, string token)
    {
        var dct = new Dictionary<string, string>();
        dct.Add("access_token", token);

        if (filter.Sum < 0.01M) filter.Sum = 0.01M;
        else if (filter.Sum > 1000000) filter.Sum = 1000000; // ограничения DonatePay.

        var keyValueArr = GetKeyValueArray(filter);
        foreach (var item in keyValueArr)
        {
            var strValue = item.Value?.ToString();
            if (strValue != null)
            {
                if(item.Name == nameof(filter.Notification))
                {
                    strValue = "-1";
                    if (filter.Notification) strValue = "1";
                }
                dct.Add(item.Name.ToLower(), strValue);
            }
        }


        return dct;
    }

    public static void HtmlDecode<T>(this List<T> list)
    {
        foreach(var obj in list)
        {
            var stringProps = obj?.GetType().GetProperties()
                .Where(x => x.GetValue(obj, null) != null && x.PropertyType == typeof(String))
                .ToArray();
            if(stringProps != null)
            {
                foreach (var item in stringProps)
                {
                    var oldValue = item.GetValue(obj)?.ToString();
                    if (oldValue != null)
                    {
                        string newValue = HttpUtility.HtmlDecode(oldValue);
                        if (newValue != oldValue) item.SetValue(obj, newValue);
                    }
                }
            }
        }
    }
}
