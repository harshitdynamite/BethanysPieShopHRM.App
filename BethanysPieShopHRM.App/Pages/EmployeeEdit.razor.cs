using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
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

        public async Task HandleValidSubmit()
        {
            Saved = false;
            if (Employee.EmployeeId == 0) 
            {
                var addedEmployee = await employeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await employeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully";
                Saved = true;
            }
        }

        private IBrowserFile selectedFile;
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }
        public async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation error. Please try again.";
        }

        public async Task DeleteEmployee()
        {
            await employeeDataService.DeleteEmployee(Employee.EmployeeId);
            StatusClass = "alert-success";
            Message = "Delete Succesfully";
            Saved=true;
        }

        
        public void NavigateToOverview()
        {
            NavigationManager.NavigateTo($"/EmployeeOverview");
        }
    }
}
