using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Provider p = new Provider();
            List<Provider> list = GetAsync(p).Result;
            Console.WriteLine("Hello World!"); */

            User u = new User();
            u.email = "maria@hotmail.com";
            u.name = "maria socorro";
            u.password = "12345678";
            PostAsync(u);
        }

        static async Task<List<T>> GetAsync<T>(T obj)
        {
            string param =
            obj.GetType().ToString().Replace("HttpRequest.", "").ToLower() + "s";
            var cl = new HttpClient();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var res = await cl.GetAsync("http://localhost:3334/" + param, new HttpCompletionOption { });
            var resp = await res.Content.ReadAsStringAsync();
            List<T> p = JsonConvert.DeserializeObject<List<T>>(resp);
            return p;
        }

        static async Task PostAsync<T>(T obj)
        {
            try
            {
                string param =
                obj.GetType().ToString().Replace("HttpRequest.", "").ToLower() + "s";
                var cl = new HttpClient();
                var json = JsonConvert.SerializeObject(new { obj });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage g =  await cl.PostAsync("http://localhost:3334/users", content);
                string responseContent = await g.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                string n = e.Message;
            }
        }

    }
}
