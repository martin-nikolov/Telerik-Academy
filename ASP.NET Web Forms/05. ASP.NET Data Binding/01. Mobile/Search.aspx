<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Mobile.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Search</title>
    </head>
    <body>
        <form id="MainForm" runat="server">
            Producer:
            <asp:DropDownList ID="ProducersDropDownList" runat="server" AutoPostBack="True" DataTextField="Name" OnSelectedIndexChanged="OnProducerSelectedIndexChanged">
            </asp:DropDownList>

            <br /> <br />

            Model:
            <asp:DropDownList ID="ProducerModelsDropDownList" runat="server" ItemType="Mobile.Producer">
            </asp:DropDownList>

            <br /> <br />

            Extras:
            <asp:CheckBoxList ID="ExtrasCheckBoxList" runat="server" DataTextField="Name">
            </asp:CheckBoxList>

            <br />

            Engine:
            <asp:RadioButtonList ID="EnginesRadioButtonList" runat="server">
            </asp:RadioButtonList>

            <br />

            <asp:Button Text="Search" runat="server" OnClick="OnSearchButtonClicked" />

            <br />
            <div runat="server" id="SummaryContainer" visible="false">
                <h1>Summary</h1>
            </div>
        </form>
    </body>
</html>
