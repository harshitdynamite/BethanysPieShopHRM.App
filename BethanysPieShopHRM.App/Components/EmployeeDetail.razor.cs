using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class EmployeeDetail: ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

        protected override Task OnInitializedAsync()
        {
            Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));
            return base.OnInitializedAsync();
        }
    }
}
