using Client.Service;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Dto;
using System.Net.Http.Json;

namespace Client.Pages
{
    public partial class UsersTable
    {
        [Inject]
        public ApplicationManager ApplicationManager { get; set; }

        private User[]? UsersList;

        protected override async Task OnInitializedAsync()
        {
            UsersList = await Http.GetFromJsonAsync<User[]>("https://localhost:7179/api/dragon/register");
        }
    }
}
