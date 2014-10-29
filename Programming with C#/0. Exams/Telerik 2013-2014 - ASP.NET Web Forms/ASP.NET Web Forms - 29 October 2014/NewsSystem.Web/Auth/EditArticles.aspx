<%@ Page Title="Edit Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsSystem.Web.Auth.EditArticles" %>

<asp:Content ID="EditArticlesContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Articles</h1>

    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Web.Models.ArticleProjection" 
                  SelectMethod="ListViewArticles_GetData" 
                  DeleteMethod="ListViewArticles_DeleteItem" 
                  UpdateMethod="ListViewArticles_UpdateItem" 
                  DataKeyNames="ArticleId" 
                  InsertMethod="ListViewArticles_InsertItem" 
                  InsertItemPosition="LastItem">
        <LayoutTemplate>
            <div class="row">
                <table class="gridview" cellspacing="0" rules="all" border="1" id="MainContent_GridViewArticles" style="border-collapse: collapse;">
                    <tbody>
                        <tr>
                            <th scope="col">
                                Title
                                <asp:LinkButton  Text="Sort" CssClass="btn btn-info btn-xs" runat="server" CommandName="Sort" CommandArgument="Title" />
                            </th>
                            <th scope="col">
                                Category
                                <asp:LinkButton Text="Sort" CssClass="btn btn-info btn-xs" runat="server" CommandName="Sort" CommandArgument="CategoryName" />
                            </th>
                            <th scope="col">
                                <asp:Literal Text="Content" runat="server" />
                            </th>
                            <th scope="col">
                                Date created
                                <asp:LinkButton Text="Sort" CssClass="btn btn-info btn-xs" runat="server" CommandName="Sort" CommandArgument="DateCreated" />
                            </th>
                            <th scope="col">
                                Author
                                <asp:LinkButton Text="Sort" CssClass="btn btn-info btn-xs" runat="server" CommandName="Sort" CommandArgument="AuthorName" />
                            </th>
                            <th scope="col">
                                Likes
                                <asp:LinkButton Text="Sort" CssClass="btn btn-info btn-xs" runat="server" CommandName="Sort" CommandArgument="LikesCount" />
                            </th>
                            <th scope="col">Action</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="4">
                                Page:
                                <asp:DataPager QueryStringField="page" runat="server" ID="DataPagerArticles" 
                                               PagedControlID="ListViewArticles" PageSize="5">
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
                <td>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?articleId={0}", Item.ArticleId) %>' 
                        runat="server" >
                    <%#: NewsSystem.Web.Utility.StringExtensions.NormalizeText(Item.Title, 50) %>
                    </asp:HyperLink>
                </td>
                <td><%#: Item.CategoryName %></td>
                <td><%#: NewsSystem.Web.Utility.StringExtensions.NormalizeText(Item.Content, 50) %></td>
                <td><%#: Item.DateCreated %></td>
                <td><%#: Item.AuthorName %></td>
                <td><%#: Item.LikesCount %></td>
                <td>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CssClass="btn btn-primary btn-xs" CommandName="Edit" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CssClass="btn btn-primary btn-xs" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%# BindItem.Title %>" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListCategory" runat="server"
                                      DataSource="<%# GetCategoryNames() %>"
                                      DataValueField="CategoryId"
                                      DataTextField="Name"
                                      AppendDataBoundItems="true">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxContent" TextMode="MultiLine" Text="<%# BindItem.Content %>" />
                </td>
                <td class="text-center">
                    <asp:Literal runat="server" ID="LiteralDateCreated" Text="<%# BindItem.DateCreated %>" />
                </td>
                <td class="text-center">
                    <asp:Literal runat="server" ID="Literal1" Text="<%# BindItem.AuthorName %>" />
                </td>
                <td class="text-center">
                    <asp:Literal runat="server" ID="LiteralLikesCount" Text="<%# BindItem.LikesCount %>" />
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
                    <div>
                        <asp:TextBox runat="server" ValidationGroup="asd" ID="TextBoxName" placeholder="Enter a article title" Text="<%#: BindItem.Title %>" />
                    </div>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListCategory" runat="server" 
                                      DataSource="<%# GetCategoryNames() %>"
                                      DataValueField="CategoryId"
                                      DataTextField="Name"
                                      SelectedValue="<%# BindItem.CategoryName %>" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxContent" placeholder="Enter a article content" TextMode="MultiLine" Text="<%#: BindItem.Content %>" />
                </td>
                <td colspan="1" class="text-center">
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CssClass="btn btn-primary btn-xs" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CssClass="btn btn-primary btn-xs" CommandName="Cancel" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <div class="row">
        <div class="back-link">
            <a href="/" class="btn btn-primary">Back to Home Page</a>
        </div>
    </div>
</asp:Content>
