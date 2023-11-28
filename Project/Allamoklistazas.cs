using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Allamoklistazas
    {
        private HttpClient client = new HttpClient();
        private string url = "https://retoolapi.dev/qESCgr/data";
        public List<Allamok> GetAll()
        {
            string json = client.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<List<Allamok>>(json);
        }
        public Allamok Add(Allamok allam)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(allam), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
            string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Allamok>(responseContent);
        }
        public bool Delete(Allamok allam)
        {
            int id = allam.Id;
            HttpResponseMessage response = client.DeleteAsync($"{url}/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public Allamok Update(int id, Allamok allam)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(allam), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PatchAsync($"{url}/{id}", content).Result;

            string responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Allamok>(responseContent);
        }
    }
}
