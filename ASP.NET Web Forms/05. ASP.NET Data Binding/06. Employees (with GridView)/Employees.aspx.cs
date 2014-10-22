namespace EmployeesGridView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using EmployeesDataBinding.Models;

    public partial class Employees : Page
    {
        private NorthwindContext northwindContext = new NorthwindContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.EmployeesGridView.DataSource = this.GetEmployees();
                this.EmployeesGridView.DataBind();
            }
        }
 
        protected void OnGridViewPageChanged(object sender, GridViewPageEventArgs e)
        {
            this.EmployeesGridView.PageIndex = e.NewPageIndex;
            this.EmployeesGridView.DataSource = this.GetEmployees();
            this.EmployeesGridView.DataBind();
        }

        private List<Employee> GetEmployees()
        {
            return this.northwindContext.Employees.ToList();
        }
    }
}