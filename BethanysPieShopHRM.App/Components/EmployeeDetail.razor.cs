using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class EmployeeDetail: ComponentBase
    {
        [Inject]
        private IEmployeeDataService? EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            
        }
    }
}
