using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BethanysPieShopHRM.App.Pages
{
    /// <summary>
    /// Component class for EmployeeOverview component
    /// </summary>
    public partial class EmployeeOverview: ComponentBase
    {
        /// <summary>
        /// Injecting the IEmployeeDataService into the component.
        /// Componenets do not support Dependency injection via the constructor.
        /// It can only be done using the Inject attribute
        /// </summary>
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        public List<Employee>? Employees { get; set; } = default!;

        private Employee _selectedEmployee;

        public string Title { get; set; } = "Employee Overview";

        //protected override void OnInitialized()
        //{
        //    Employees = MockDataService.Employees;
        //}

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        { 
            _selectedEmployee = selectedEmployee;
        }

    }
}
