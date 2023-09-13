using Newtonsoft.Json;
using System;

namespace Practica7.MVC.Models
{
    public partial class CharacterView
    {
        [JsonProperty("name")]
        public string CharacterName { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

    }
}