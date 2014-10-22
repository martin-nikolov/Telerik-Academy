namespace EmployeesDataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using EmployeesDataBinding.Models;

    public partial class EmployeeDetails : Page
    {
        private NorthwindContext northwindContext = new NorthwindContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeId;
            if (!int.TryParse(this.Request.Params["id"], out employeeId))
            {
                this.RedirectToHomePage();
            }

            var employee = this.northwindContext.Employees.Find(employeeId);
            if (employee == null)
            {
                this.RedirectToHomePage();
            }

            this.EmployeeDetailsView.DataSource = new List<Employee>() { employee };
            this.EmployeeDetailsView.DataBind();
        }
 
        protected void OnBackButtonClicked(object sender, EventArgs e)
        {
            this.RedirectToHomePage();
        }

        private void RedirectToHomePage()
        {
            this.Response.Redirect("Employees.aspx");
        }
    }
}