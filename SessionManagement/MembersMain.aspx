<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembersMain.aspx.cs" Inherits="SessionManagement_Partee.MembersMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member's Main Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Member's Main Page</h2>
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
            </div>
    <br />
        <br />
    <div>
        <asp:Button ID="btnThirdPage" runat="server" Text="Click to Decrypt URL" OnClick="btnThirdPage_Click" />
    </div>
        <br />
    </form>
</body>
</html>
