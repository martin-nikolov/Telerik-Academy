<%@ Page Title="Generator" 
         Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="Generator.aspx.cs" 
         Inherits="RandomNumber.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <input type="number" min="0"  max="10000000" name="minNumberInput" id="minNumberInput" value="10" runat="server" /> <br /> <br />
            <input type="number" min="0" max="10000000" name="maxNumberInput" id="maxNumberInput" value="100" runat="server" /> <br /> <br />
            <input type="submit" value="Generate random number" runat="server" onserverclick="OnGenerateRandomNumberButtonClicked" /> <br /> <br />
            <div id="randomNumberContainer" runat="server"></div>
        </form>
    </body>
</html>
