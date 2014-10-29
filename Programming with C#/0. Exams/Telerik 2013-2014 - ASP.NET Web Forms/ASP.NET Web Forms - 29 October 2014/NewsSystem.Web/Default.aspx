<%@ Page Title="News System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsSystem.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>News</h1>
    <h2>Most popular articles</h2>

    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Web.Models.ArticleProjection" SelectMethod="ListViewArticles_GetData">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-10">
                    <h3>
                        <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?articleId={0}", Item.ArticleId) %>' runat="server" 
                                       Text='<%#: Item.Title %>' />
                        <small><%#: Item.CategoryName %></small>
                    </h3>
                    <p>
                    <%#: Item.Content %>
                    </p>
                    <p>Likes: <%#: Item.LikesCount %></p>
                    <div>
                        <i>by <%#: Item.AuthorName %></i>
                        <i>created on: <%#: Item.DateCreated %></i>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <h2>All categories</h2>
    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Web.Models.CategoryProjection"
         SelectMethod="ListViewCategories_GetData"
                  GroupItemCount="2">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView runat="server" ID="RepeaterAricles" ItemType="NewsSystem.Web.Models.ArticleProjection"
                     DataSource="<%# Item.Articles %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?articleId={0}", Item.ArticleId) %>' runat="server"
                                 Text='<%# string.Format(@"<strong>""{0}""</strong> <i>by {1}</i>", Item.Title, Item.AuthorName) %>' />
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

