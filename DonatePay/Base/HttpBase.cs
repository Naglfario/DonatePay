using Newtonsoft.Json;

namespace DonatePay.Base;

public class HttpBase
{
    public HttpBase()
    {
    }

    public static async Task<T> Get<T>(string url) where T : class
    {
        using (var client = new HttpClient())
        using (var request = new HttpRequestMessage(HttpMethod.Get, url))
        using (var response = await client.SendAsync(request))
        return await ResponseProcessing<T>(response);
    }

    public static async Task<T> Post<T>(string url, Dictionary<string, string> dct) where T : class
    {
        using (var contentForm = new FormUrlEncodedContent(dct))
        using (var client = new HttpClient())
        using (var response = await client.PostAsync(url, contentForm))
        return await ResponseProcessing<T>(response);
    }

    private static async Task<T> ResponseProcessing<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();

        var stringResult = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(stringResult);
    }

    private static T Deserialize<T>(string response)
    {
        var result = JsonConvert.DeserializeObject<T>(response);
        if (result != null) return result;
        else throw new Exception("Не удалось десериализовать ответ от DonatePay: " + response);
    }
}
