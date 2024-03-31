using Abp.Events.Bus;
using Bamanna.DouDian.Infrastructure.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Bamanna.DouDian.Infrastructure.Extentions;

namespace Bamanna.DouDian.Api
{
    public abstract class ApiManagerBase : UnifyDomainServiceBase, IApiManagerBase
    {
        protected Lazy<JsonSerializerSettings> _settings;

        protected string BaseUrl;

        public ContentType ContentType { get; set; }

        public ConvertType ConvertType { get; set; }

        public IEventBus EventBus { get; set; }

        public ApiManagerBase(
            )
        {
            EventBus = NullEventBus.Instance;
        }

        public virtual async Task<TOutput> HttpRequest<TOutput, TInput>(string path, Dictionary<string, string> header, TInput body, HttpMethod httpMethod)
            where TInput : class
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append(path);
            var _clientHandler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Automatic,
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            var client = new HttpClient(_clientHandler);
            try
            {
                using (var request = BuildHttpRequest(urlBuilder, header, body, httpMethod))
                {
                    HttpResponseMessage response = null;
                    try
                    {
                        try
                        {
                            response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"接口调用失败,失败信息{e.Message},请求接口{path},请求参数{JsonConvert.SerializeObject(header)},请求body{JsonConvert.SerializeObject(body)}");
                        }
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return JsonConvert.DeserializeObject<TOutput>(responseData);
                        }
                        else
                        {
                            throw new Exception($"接口调用失败,非200错误，错误信息{JsonConvert.SerializeObject(responseData)},请求接口{path},请求参数{JsonConvert.SerializeObject(header)},请求body{JsonConvert.SerializeObject(body)}");
                        }
                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }

        public virtual async Task<HttpResponseMessage> HttpRequestBase<TInput>(string path, Dictionary<string, string> header, TInput body, HttpMethod httpMethod)
            where TInput : class
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl).Append(path);
            var _clientHandler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Automatic,
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            var client = new HttpClient(_clientHandler);
            try
            {
                using (var request = BuildHttpRequest(urlBuilder, header, body, httpMethod))
                {
                    HttpResponseMessage response = null;
                    try
                    {
                        try
                        {
                            response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);
                            return response;
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"接口调用失败,失败信息{e.Message},请求接口{path},请求参数{JsonConvert.SerializeObject(header)},请求body{JsonConvert.SerializeObject(body)}");
                        }

                    }
                    finally
                    {
                        if (response != null)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }

        private HttpRequestMessage BuildHttpRequest<TInput>(StringBuilder urlBuilder, Dictionary<string, string> header, TInput body, HttpMethod httpMethod)
            where TInput : class
        {
            var request = new HttpRequestMessage();
            if (header != null && header.Count() > 0)
            {
                foreach (var headeritem in header)
                {
                    request.Headers.Add(headeritem.Key, headeritem.Value);
                }
            }
            if (httpMethod == HttpMethod.Post)
            {
                if (ContentType == ContentType.Json)
                {
                    //application/json
                    var item = JsonConvert.SerializeObject(body, _settings.Value);
                    var content = new StringContent(item);
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Content = content;
                }
                else if (ContentType == ContentType.Form)
                {
                    //x-www-form-urlencoded
                    var Params = ParseQueryString(body);
                    var content = new StringContent(Params);
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                    request.Content = content;
                }
                else
                {

                }
            }
            else if (httpMethod == HttpMethod.Get)
            {
                var param = ParseQueryString(body);
                if (!string.IsNullOrEmpty(param))
                {
                    urlBuilder.Append("?" + param);
                }
            }
            request.Method = httpMethod;
            var url = urlBuilder.ToString();
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            return request;
        }

        private string ParseQueryString<T>(T t) where T : class
        {
            if (t == null)
                return string.Empty;
            var type = t.GetType();
            var properties = type.GetProperties().Where(s => s.CanRead);
            var fields = type.GetFields().Where(s => s.IsPublic);
            StringBuilder text = new StringBuilder();
            foreach (var field in fields)
            {
                var value = field.GetValue(t);
                if (value != null)
                {
                    if (value is IEnumerable<IConvertible> collect)
                    {
                        string temp = "";
                        foreach (var item in collect)
                        {
                            temp += item.ToString();
                            if (item != collect.Last())
                            {
                                temp += ',';
                            }
                        }
                        text.Append($"&{field.Name}={temp}");
                    }
                    else if (value is IConvertible)
                    {
                        text.Append($"&{field.Name}={HttpUtility.UrlEncode(value.ToString())}");
                    }
                    else if (value is Enum)
                    {
                        text.Append($"&{field.Name}={value}");
                    }
                }
            }

            foreach (var property in properties)
            {
                var value = property.GetValue(t);
                if (value != null)
                {
                    string name;
                    if (ConvertType == ConvertType.Lower)
                    {
                        name = GetPropertyName(property).ToLower();
                    }
                    else if (ConvertType == ConvertType.Camel)
                    {
                        name = GetPropertyName(property);
                    }
                    else
                    {
                        name = GetPropertyName(property);
                    }
                    if (value is IEnumerable<IConvertible> collect)
                    {
                        string temp = "";
                        foreach (var item in collect)
                        {
                            temp += item.ToString();
                            if (item != collect.Last())
                            {
                                temp += ',';
                            }
                        }
                        text.Append($"&{name}={HttpUtility.UrlEncode(temp)}");
                    }
                    else if (value is IConvertible)
                    {
                        text.Append($"&{name}={HttpUtility.UrlEncode(value.ToString())}");
                    }
                    else if (value is Enum)
                    {
                        text.Append($"&{name}={HttpUtility.UrlEncode(value.ToString())}");
                    }
                }
            }
            if (text.Length > 0)
                text.Remove(0, 1);
            return text.ToString();
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetPropertyName(PropertyInfo p)
        {
            var attr = p.GetCustomAttribute<JsonPropertyAttribute>();
            if (attr != null && !string.IsNullOrEmpty(attr.PropertyName))
                return attr.PropertyName;
            if (ConvertType == ConvertType.Camel)
            {
                return p.Name.ToCamelCaseName();
            }
            else if (ConvertType == ConvertType.Lower)
            {
                return p.Name.ToLower();
            }
            else
            {
                return p.Name;
            }
        }

    }

    public enum ContentType
    {
        Json = 1,
        Form = 2
    }

    public enum ConvertType
    {
        Camel = 1,
        Lower = 2
    }
}
