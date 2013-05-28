using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace SQ.Helper
{
    public static class HttpHelper
    {
        /// <summary>
        /// GET抓取页面
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parms">请求参数的字典</param>
        /// <returns>整个页面</returns>
        public static string Get(string url,IDictionary<string,string> parms=null)
        {
            HttpClient client = new HttpClient();
            if (parms!=null && parms.Count>0)
            {
                StringBuilder sb = new StringBuilder();
                if (url.Contains("?"))
                {
                    sb.Append("&");
                }
                else
                {
                    sb.Append("?");
                }
                foreach (var item in parms)
                {
                    sb.Append(string.Concat(item.Key, "=", item.Value));
                    sb.Append("&");
                }
                sb.Remove(sb.Length - 1, 1);
                url += sb.ToString();
            }
            var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        /// <summary>
        /// POST请求（参数以json形式）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="parms">object对象，将转化成json</param>
        public static string Post(string url, object parms)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(parms);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = client.PostAsync(url,content).Result.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
