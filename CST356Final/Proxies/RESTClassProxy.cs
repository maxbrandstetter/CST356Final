using CST356Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CST356Final.Proxies
{
    public class RestClassProxy : IRestClassProxy
    {
        private HttpClient client;

        public RestClassProxy()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52555/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            List<Class> classes = null;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                classes = await response.Content.ReadAsAsync<List<Class>>();
            }

            return classes;
        }
    }

    public interface IRestClassProxy
    {
        Task<List<Class>> GetClassesAsync();
    }
}