using Client.Service;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Dto;
using System.Net.Http.Json;

namespace Client.Pages
{
    public partial class AniversaryTable
    {
        [Inject] private ApplicationManager ApplicationManager { get; set; }

        private Clasification[]? ClasificationList;

        private Dragon[]? dragonList;

        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();

        protected override async Task OnInitializedAsync() //una get
        {
            dragonList = await Http.GetFromJsonAsync<Dragon[]>("https://localhost:7179/api/dragon");
            ClasificationList = await Http.GetFromJsonAsync<Clasification[]>("https://localhost:7179/api/dragon/Clasification");
        }
    }
}
