using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeEdit: ComponentBase
    {
        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public ICountryDataService countryDataService { get; set; }
        
        [Inject]
        public IJobCategoryDataService jobCategoryDataService { get; set; }

        [Parameter]
        public string? EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; }=new List<JobCategory>();

        protected async override Task OnInitializedAsync()
        {
            //Employee = await employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            Countries = (await countryDataService.GetAllCountries()).ToList();
            JobCategories = (await jobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId,out var empId );
            if (empId == 0) //new employee is being created
            {
                Employee = new Employee() { CountryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }

    }
}
