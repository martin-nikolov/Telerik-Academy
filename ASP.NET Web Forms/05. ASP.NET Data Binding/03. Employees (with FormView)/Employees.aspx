<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees</title>
    </head>
    <body>
        <form id="MainForm" runat="server">
            <asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="False" 
                          AllowPaging="True" DataKeyNames="EmployeeID">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="HomePhone" HeaderText="Phone" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:HyperLinkField Text="Details" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="Employees.aspx?id={0}" />
                </Columns>
            </asp:GridView>

            <br />

            <div runat="server" ID="SelectedEmployeeContainer" visible="false">
                <h2>Selected employee: </h2>
                <asp:FormView ID="EmployeeFormView" runat="server" DataKeyName="EmployeeID" ItemType="EmployeesDataBinding.Models.Employee">
                    <ItemTemplate>
                        <h4><%#: Item.FirstName + " " + Item.LastName %></h4>
                        <table border="0">
                            <tr>
                                <td>Phone:</td>
                                <td><%#: Item.HomePhone %></td>
                            </tr>
                            <tr>
                                <td>City:</td>
                                <td><%#: Item.City %></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
            </div>
        </form>
    </body>
</html>