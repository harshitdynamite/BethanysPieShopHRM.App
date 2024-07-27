using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class ProfilePicture
    {
        /// <summary>
        /// the name for this property should be ChildContent
        /// and type should be RenderFragment
        /// and it will wired up automatically
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        //RenderFragment is a built in type tthat represents a segment of UI 
    }
}
