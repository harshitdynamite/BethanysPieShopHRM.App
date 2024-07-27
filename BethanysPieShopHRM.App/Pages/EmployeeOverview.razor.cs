using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    /// <summary>
    /// Component class for EmployeeOverview component
    /// </summary>
    public partial class EmployeeOverview: ComponentBase
    {
        public List<Employee>? Employees { get; set; } = default!;

        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees;
        }

    }
}
