using Microsoft.AspNetCore.Components.Forms;
using SharedLibrary.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace Client.Pages
{
    public partial class NewHunter
    {

        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();
        public User User { get; set; } = new();

        private string messageText = "";

        private async Task Registred()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7179/api/dragon/register", User);
            messageText = "Sucess";
        }

    }
}
