namespace EmployeesDataBinding
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using EmployeesDataBinding.Models;

    public partial class Employees : Page
    {
        private NorthwindContext northwindContext = new NorthwindContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.EmployeesGridView.DataSource = this.northwindContext.Employees.Select(x => new
                {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    HomePhone = x.HomePhone
                }).ToList();

                this.EmployeesGridView.DataBind();
            }
        }
    }
}