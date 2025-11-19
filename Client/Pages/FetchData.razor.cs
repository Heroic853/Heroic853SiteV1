using Client.Service;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Dto;
using System.Net.Http;
using System.Net.Http.Json;

namespace Client.Pages
{
    public partial class FetchData
    {
        private HttpClient httpClient;
        private Dragon[]? dragonList;

        protected override async Task OnInitializedAsync() //una get
        {

            dragonList = await Http.GetFromJsonAsync<Dragon[]>("https://localhost:7179/api/dragon");
        }
        [Inject] private ApplicationManager ApplicationManager { get; set; }
    }
}
