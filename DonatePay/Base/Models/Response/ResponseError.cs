using System;
using System.Net;

namespace DonatePay.Base.Models.Response
{
    public class ResponseError
    {
        /// <summary>
        /// Полный ответ от DonatePay в виде HTML
        /// </summary>
        public string HtmlContent { get; set; } = String.Empty;
        /// <summary>
        /// Код состояния HTTP
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}