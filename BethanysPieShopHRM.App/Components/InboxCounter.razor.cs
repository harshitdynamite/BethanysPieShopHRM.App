using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class InboxCounter: ComponentBase
    {
        [Inject]
        public ApplicationState? ApplicationState { get; set; }
        public int MessageCounter { get; set; } = 0;

        protected override void OnInitialized()
        {
            MessageCounter = new Random().Next(10);
            ApplicationState.NoOfMessages = MessageCounter;
        }

    }
}
