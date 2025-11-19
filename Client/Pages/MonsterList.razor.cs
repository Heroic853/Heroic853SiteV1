using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SharedLibrary.Dto;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Client.Service;

namespace Client.Pages
{
    public partial class MonsterList
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();

        [Inject]
        public ApplicationManager ApplicationManager { get; set; }
        public Dragon Dragon { get; set; } = new(); // una property che serve per il bind
        public Clasification Clasification { get; set; } = new();

        private string messageTextMonsterChoise = "";

        private string messageTextFeedbacks = "";

        private async Task Saves()
        {
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.PostAsJsonAsync("https://localhost:7179/api/dragon", Dragon);
                messageTextMonsterChoise = "Sucess";
                if (response.IsSuccessStatusCode)
                {
                    messageTextMonsterChoise = "Suces the dragon was created";
                }
                else
                {
                    messageTextMonsterChoise = "Nothing was created";
                }
            }
            catch (Exception ex)
            {
                messageTextMonsterChoise = $"Error: {ex.Message}";
            }
        }


        private async Task Saved()
        {
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.PostAsJsonAsync("https://localhost:7179/api/dragon/Clasification", Clasification);
                if (response.IsSuccessStatusCode)
                {
                    messageTextFeedbacks = "Sucess the choise was sended";
                }
                else
                {
                    messageTextFeedbacks = "Error was not sent nothing";
                }
            }
            catch (Exception ex)
            {
                messageTextFeedbacks = $"Error: {ex.Message}";
            }
        }
    }
}
