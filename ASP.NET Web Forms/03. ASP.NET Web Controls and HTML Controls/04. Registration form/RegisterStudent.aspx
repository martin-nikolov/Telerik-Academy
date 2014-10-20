<%@ Page Title="Registration" Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="RegistrationFormControls.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <div runat="server" id="registerForm">
                First name: <asp:TextBox runat="server" ID="firstNameInput" /> <br /> <br />
                Second name: <asp:TextBox runat="server" ID="lastNameInput" /> <br /> <br />
                Faculty number: <asp:TextBox runat="server" ID="facultyNumber" /> <br /> <br />

                University: 
                <asp:DropDownList runat="server" ID="universityDropDown">
                    <asp:ListItem Text="Edinburgh Napier" />
                    <asp:ListItem Text="Essex" />
                    <asp:ListItem Text="St George's, University of London" />
                    <asp:ListItem Text="Worcester" />
                </asp:DropDownList>
                <br /> <br />

                Specialty: 
                <asp:DropDownList runat="server" ID="specialtyDropDown">
                    <asp:ListItem Text="Bariatric Surgery" />
                    <asp:ListItem Text="Concussions" />
                    <asp:ListItem Text="Counseling" />
                    <asp:ListItem Text="Diagnostic Lab" />
                </asp:DropDownList>
                <br /> <br />

                Course: 
                <asp:DropDownList runat="server" ID="courseDropDown">
                    <asp:ListItem Text="Chemistry" />
                    <asp:ListItem Text="Computer Science" />
                    <asp:ListItem Text="Oriental Studies" />
                    <asp:ListItem Text="Mathematics" />
                </asp:DropDownList>
                <br /> <br />

                <asp:Button Text="Register" runat="server" OnClick="OnRegisterStudentButtonClicked" />
            </div>

            <div runat="server" id="registrationInfo"></div>
        </form>
    </body>
</html>
