<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees</title>
        <link href="Styles/Site.css" rel="stylesheet" />
    </head>
    <body>
        <form id="MainForm" runat="server">
            <asp:ListView ID="EmployeesListView" runat="server" ItemType="EmployeesDataBinding.Models.Employee">
                <LayoutTemplate>
                    <h3>Employees</h3>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>

                <ItemTemplate>
                    <div class="employee-description">
                        <h4><%#: Item.FirstName + " " + Item.LastName %></h4>
                        <p>City: <%#: Item.City %></p>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPagerEmployee" runat="server"
                           PagedControlID="EmployeesListView" PageSize="3"
                           QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                                                ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                                                ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </form>
    </body>
</html>
