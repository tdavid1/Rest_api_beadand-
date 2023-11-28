using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project
{
    public class Allamok
    {
        [JsonProperty("Rating")]
        public int Rating { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Allamok")]
        public string Allam { get; set; }

        [JsonProperty("Voltame")]
        public bool Voltame { get; set; }
    }
}
