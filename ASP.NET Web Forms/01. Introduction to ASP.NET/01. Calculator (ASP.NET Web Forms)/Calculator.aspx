<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CalculatorWebForms.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Calculator</title>
    </head>
    <body>
        <form id="calculatorForm" runat="server">
            <div>
                <input type="text" name="firstNumber" runat="server" ID="firstNumberInput" value="0" /> <br />
                <input type="text" name="secondNumber" runat="server" ID="secondNumberInput" value="0" /> <br />
                <input type="submit" runat="server" onserverclick="OnCalculateButtonClicked" name="submitButton" value="Calculate" />

                <div>
                    <br />
                    Result:
                    <asp:Label runat="server" ID="resultTextBlock"></asp:Label>
                </div>
            </div>
        </form>
    </body>
</html>
