using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BethanysPieShopHRM.ComponentsLibrary
{
    public partial class Map : ComponentBase
    {
        string elementId = $"map-{Guid.NewGuid():D}";

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public double Zoom { get; set; }

        [Parameter]
        public List<Marker> Markers { get; set; }


        /// <summary>
        /// Javascript interops should alaways be done after the component has renderd.
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync(
                "deliveryMap.showOrUpdate",  //function in the deliveryMap.js 
                elementId,
                Markers
                );
        }
    }
}
