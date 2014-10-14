## ASP.NET Data Binding

1. Create a Web form for searching for cars by producer + model + type of engine + set of extras (see www.mobile.bg). Use two DropDownLists for the producer (e.g. VW, BMW, …) and for the model (A6, Corsa,…). Create a class Producer hodling Name + collection of models. Bind the list of producers to the first DropDownList. The second should be bound to the models of this producer. You should have a check box for each “extra” (use class Extra and bind the list of extras at the server side). Implement the type of engine as a horizontal radio button selection (options bound to a fixed array). On submit display all collected information in <asp:Literal>.
* Create a page Employees.aspx to display the names of all employees from Northwind database in a GridView as hyperlinks. All links should redirect to another page (e.g. EmpDetails.aspx?id=3) where details about the employee are displayed in a DetailsView. Add a back button to return back to the previous page.
* Implement the previous task in a single ASPX page by using a FormView instead of DetailsView.
* Display the information about all employees a table in an ASPX page using a Repeater.
* Re-implement the previous using ListView.
* *Create a Web Form that reads arbitrary XML document and displays it as tree. Use the TreeView Web control on the left side to display the inner XML of the selected node on the right side.
* *Create a Web Form that shows in a table the names, country and city of all employees from the Northwind database. Implement paging (10 employees on each page) and sorting by each column. Using AJAX, JavaScript and jQuery on mouse over display a popup DIV with additional info about the employee: photo, phone, email, address, notes. On mouse out hide the additional info.
