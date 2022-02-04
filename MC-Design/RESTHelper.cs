using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MC_Design
{
    public static class RESTHelper
    {
        private static readonly string baseURL = "http://45.76.152.7:8080/api/";
        public static async Task<string> GetAll(string param)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + param))
                {
                    using(HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data!=null) { return data; }
                    }
                }
            }
            return string.Empty;
        }


        public static async Task<string> Get(string param,string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + param+"/"+id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null) { return data; }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Post(string param, string code, string subject, string description)
        {
            object mydata = new
            {
                code = code,
                subject = subject,
                description = description
            };
            var myContent = JsonConvert.SerializeObject(mydata);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
              using (HttpResponseMessage res = await client.PostAsync(baseURL + param, byteContent))
                {
                    Console.WriteLine("Nico", res);
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null) { return data; }
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<string> Put(string param, string id, string code, string subject, string description)
        {
            object mydata = new
            {
                code = code,
                subject = subject,
                description = description
            };
            var myContent = JsonConvert.SerializeObject(mydata);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync(baseURL + param + "/" + id, byteContent))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null) { return data; }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Delete(string param, string id)
        {
          using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(baseURL + param + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null) { return data; }
                    }
                }
            }
            return string.Empty;
        }


       



    }
}
