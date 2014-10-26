<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_02.Registration_Form_Groups.Registration" %>
<asp:Content ID="RegistrationFormContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registration</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmailTextBox" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmailTextBox" placeholder="example@mail.com" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator ValidationGroup="loginInfo"  runat="server" ControlToValidate="EmailTextBox"
                                            CssClass="text-danger" ErrorMessage="The email field is required." />
                <div>
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidatorEmail"
                        runat="server" 
                        ErrorMessage="Email address is incorrect!"
                        ControlToValidate="EmailTextBox" EnableClientScript="True"
                        CssClass="text-danger" ValidationGroup="loginInfo" 
                        ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                    </asp:RegularExpressionValidator>
                </div>
            </div>
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                            CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="loginInfo"  />
            </div>
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ValidationGroup="loginInfo" 
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator ValidationGroup="loginInfo"  runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                      CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>

            <div class="col-md-offset-2 col-md-10">
                <br />
                <asp:Button runat="server" Text="Validate User Info" CausesValidation="true" ValidationGroup="loginInfo" CssClass="btn btn-default" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator ValidationGroup="personalInfo" runat="server" ControlToValidate="FirstName"
                                            CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
            <asp:Label runat="server" AssociatedControlID="SecondName" CssClass="col-md-2 control-label">Second name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="SecondName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator ValidationGroup="personalInfo" runat="server" ControlToValidate="SecondName"
                                            CssClass="text-danger" ErrorMessage="The second name field is required." />
            </div>
            <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="Phone" placeholder="1-234-567-8901" />
                <asp:RequiredFieldValidator ValidationGroup="personalInfo" runat="server" ControlToValidate="PhoneNumber"
                                            CssClass="text-danger" ErrorMessage="The phone number field is required." />
                <div>
                    <asp:RegularExpressionValidator
                        ID="PhoneNumberRegExp"
                        runat="server"  ValidationGroup="personalInfo"
                        ErrorMessage="Phone number is incorrect!"
                        ControlToValidate="PhoneNumber" EnableClientScript="True"
                        CssClass="text-danger"
                        ValidationExpression="1?\W*([2-9][0-8][0-9])\W*([2-9][0-9]{2})\W*([0-9]{4})(\se?x?t?(\d*))?">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Age" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Age" ValidationGroup="personalInfo"
                                            CssClass="text-danger" ErrorMessage="The age field is required." />
                <div>
                    <asp:RangeValidator CssClass="text-danger" ID="RangeValidatorAge" runat="server" 
                                        ErrorMessage="Age must be between 18 and 81" ValidationGroup="personalInfo"
                                        ControlToValidate="Age" MaximumValue="81" MinimumValue="18" Text="Age must be between 18 and 81"></asp:RangeValidator>
                </div>
            </div>

            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Validate Personal Info" CausesValidation="true" ValidationGroup="personalInfo" CssClass="btn btn-default" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LocalAddress" CssClass="col-md-2 control-label">Local Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LocalAddress" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LocalAddress" ValidationGroup="contactInfo"
                                            CssClass="text-danger" ErrorMessage="The local address field is required." />
            </div>

            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Validate Personal Info" CausesValidation="true" ValidationGroup="contactInfo" CssClass="btn btn-default" />
            </div>
        </div>

        <asp:ValidationSummary ID="ValidationSummaryLoginInfo"  CssClass="text-danger" ValidationGroup="loginInfo" DisplayMode="BulletList" runat="server" />
        <asp:ValidationSummary ID="ValidationSummaryPersonalInfo"  CssClass="text-danger"  ValidationGroup="personalInfo" DisplayMode="BulletList" runat="server" />
        <asp:ValidationSummary ID="ValidationSummaryContactInfo"  CssClass="text-danger"  ValidationGroup="contactInfo" DisplayMode="BulletList" runat="server" />
    </div>
</asp:Content>
