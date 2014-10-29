<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsSystem.Web.Auth.EditCategories" %>

<asp:Content ID="EditCategoriesContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <div class="row">
        <div class="col-md-12">
            <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Web.Models.Category" 
                          SelectMethod="ListViewCategories_GetData" 
                          DeleteMethod="ListViewCategories_DeleteItem" 
                          UpdateMethod="ListViewCategories_UpdateItem" 
                          DataKeyNames="CategoryId" 
                          InsertMethod="ListViewCategories_InsertItem" 
                          InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <div class="row">
                        <table class="gridview" cellspacing="0" rules="all" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                            <tbody>
                                <tr>
                                    <th scope="col">
                                        Category Name
                                        <asp:LinkButton Text="Sort" CssClass="btn btn-info btn-xs" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Name" />
                                    </th>
                                    <th scope="col">Action</th>
                                </tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                                <tr>
                                    <td colspan="2">
                                        Page:
                                        <asp:DataPager QueryStringField="page" runat="server" ID="DataPagerCategories" PagedControlID="ListViewCategories" PageSize="5">
                                            <Fields>
                                                <asp:NumericPagerField />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CssClass="btn btn-primary btn-xs" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CssClass="btn btn-primary btn-xs" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%# BindItem.Name %>" />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CssClass="btn btn-primary btn-xs" CommandName="Update" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CssClass="btn btn-primary btn-xs" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" placeholder="Enter a category name" Text="<%#: BindItem.Name %>" />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CssClass="btn btn-primary btn-xs" CommandName="Insert" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CssClass="btn btn-primary btn-xs" CommandName="Cancel" />
                        </td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div class="row">
        <div class="back-link">
            <a href="/" class="btn btn-primary">Back to Home Page</a>
        </div>
    </div>
</asp:Content>
