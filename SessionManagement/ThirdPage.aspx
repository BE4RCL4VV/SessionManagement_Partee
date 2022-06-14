<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdPage.aspx.cs" Inherits="SessionManagement_Partee.ThirdPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recieved Encrypted Data</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Recieved Encrypted Data</h2>
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
        </div>
        <br />
        <div>
            <asp:Button ID="btnReturnHome" runat="server" Text="Click to Abandon Session" OnClick="btnReturnHome_Click" />
        </div>
        <br />
    </form>
</body>
</html>
