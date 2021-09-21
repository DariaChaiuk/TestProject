using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProject.Models.ViewModels
{
    public class UserDevicesViewModel
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }
        [JsonPropertyName("registeredUsers")]
        public int RegisteredUsers { get; set; }
        [JsonPropertyName("registeredDevices")]
        public List<UserDevice> RegisteredDevices {get;set;}
    }

    public class UserDevice
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
