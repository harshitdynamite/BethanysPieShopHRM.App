using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Components
{
    public partial class EmployeeDetail: ComponentBase
    {
        [Inject]
        private IEmployeeDataService? EmployeeDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        protected async override Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>() 
                {
                new Marker{ Description = $"{Employee.FirstName} {Employee.LastName}",
                ShowPopUp= false, X = Employee.Longitude.Value, Y = Employee.Longitude.Value}
                };
            }
            
        }
    }
}
