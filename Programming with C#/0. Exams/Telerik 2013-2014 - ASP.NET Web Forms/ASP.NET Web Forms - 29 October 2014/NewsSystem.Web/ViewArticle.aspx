<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystem.Web.ViewArticle" %>
<%@ Register Src="~/Controls/LikeControl.ascx" TagPrefix="uc" TagName="LikeControl" %>

<asp:Content ID="ViewArticleContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelResults" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelResults" runat="server" Visible="true" class="panel">
                <asp:FormView runat="server" ID="FormViewArticleDetails" ItemType="NewsSystem.Web.Models.ArticleProjection" 
                              SelectMethod="FormViewArticleDetails_GetItem">
                    <ItemTemplate>
                        <table cellspacing="0" style="border-collapse:collapse;">
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        <asp:PlaceHolder runat="server" ID="LikeControlContainer">
                                            <uc:LikeControl runat="server" ID="LikeControl"
                                                            LikesValue="<%# GetLikesValue(Item) %>"
                                                            OnLike="LikeControl_Like"
                                                            DataID="<%# Item.ArticleId %>"
                                                            UserVote="<%# GetUserVote(Item) %>" />

                                        </asp:PlaceHolder>
                                        <div class="article-container">
                                            <h2>
                                                <%#: Item.Title %> <small>Category: <%#: Item.CategoryName %></small>
                                            </h2>
                                            <p><%#: Item.Content %></p>
                                            <p>
                                                <span>Author: <%#: Item.AuthorName %></span>
                                                <span class="pull-right"><%#: Item.DateCreated %></span>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
