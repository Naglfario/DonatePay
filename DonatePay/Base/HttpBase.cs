using DonatePay.Base.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DonatePay.Base
{
    public class HttpBase
    {
        public static async Task<T> Get<T>(string url) where T : ResponseBase, new()
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            using (var response = await client.SendAsync(request))
                return await ResponseProcessing<T>(response);
        }

        public static async Task<T> Post<T>(string url, Dictionary<string, string> dct) where T : ResponseBase, new()
        {
            using (var contentForm = new FormUrlEncodedContent(dct))
            using (var client = new HttpClient())
            using (var response = await client.PostAsync(url, contentForm))
                return await ResponseProcessing<T>(response);
        }

        private static async Task<T> ResponseProcessing<T>(HttpResponseMessage response) where T : ResponseBase, new()
        {
            var stringResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Deserialize<T>(stringResult);
            else return new T()
            {
                Time = DateTime.Now,
                Error = new ResponseError
                {
                    HtmlContent = stringResult,
                    StatusCode = response.StatusCode
                }
            };
        }

        private static T Deserialize<T>(string response)
        {
            var result = JsonConvert.DeserializeObject<T>(response);
            if (result != null) return result;
            else throw new Exception("Не удалось десериализовать ответ от DonatePay: " + response);
        }
    }
}