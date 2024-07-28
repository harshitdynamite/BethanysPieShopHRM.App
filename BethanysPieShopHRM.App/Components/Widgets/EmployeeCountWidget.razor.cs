using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components.Widgets
{
    public partial class EmployeeCountWidget : ComponentBase
    {
        public int EmployeeCounter { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            EmployeeCounter = (await EmployeeDataService.GetAllEmployees()).Count();
        }
        //protected async override void OnInitialized()
        //{
            
        //    EmployeeCounter = MockDataService.Employees.Count;
        //}
    }
}
