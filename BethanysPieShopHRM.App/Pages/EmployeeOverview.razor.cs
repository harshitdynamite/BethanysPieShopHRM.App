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

        private Employee _selectedEmployee;

        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees;
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        { 
            _selectedEmployee = selectedEmployee;
        }

    }
}
