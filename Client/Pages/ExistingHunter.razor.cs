using Client.Service;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Dto;
using System.Net.Http.Json;
using System.Security.Principal;

namespace Client.Pages
{
    public partial class ExistingHunter
    {
        [Inject] private NavigationManager NavManager { get; set; }
        [Inject] private ApplicationManager ApplicationManager { get; set; }

        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();
        public User User { get; set; } = new();
       
        private string messageText = "";

        public async Task Login()
        {
            var httpClient = new HttpClient();
            try
            {

                User dbUser = await httpClient.GetFromJsonAsync<User>($"https://localhost:7179/api/dragon/get-user?username={User.Username}"); //query string ?username={User.Username}
                if (dbUser == null)
                {
                  messageText= "Account exist";
                }
                else
                {
                    if (User.Password.Equals(dbUser.Password))
                    {
                        ApplicationManager.Username = dbUser.Username;
                        NavManager.NavigateTo("/");
                    }
                    else
                    {
                        messageText = "Error Password";
                    }
                }
            }
            catch (Exception ex)
            {
                messageText = "Account Not exist";
            }


        }
    }
}
