using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class Map
    {
        string elementId = $"map-{Guid.NewGuid():D}";

        [Parameter]
        public double Zoom { get; set; }

        [Parameter]
        public List<Marker> Markers { get;set; }
    }
}
