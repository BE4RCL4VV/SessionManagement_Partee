<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SessionManagement_Partee.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            //HttpContext.Current.Session["User"] = null;
            //HttpContext.Current.Session["Pass"] = null;
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            var array = new byte[64];
            using (random)
            {
                random.GetNonZeroBytes(array);
            }
            HttpContext.Current.Session["SecretSalt"] = Convert.ToBase64String(array);

        }
    </script>
<head runat="server">
    <title></title>
</head>
<body style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">
    <form id="form1" runat="server">
        <div style="height:90%;">
            <div style="float:right;width:300px;border:1px solid black;padding:10px;">
                Username: <asp:TextBox ID="txtUser" runat="server" /><br />
                Password:  <asp:TextBox ID="txtPassword" runat="server" /><br />
                <asp:Label ID ="lblMessage" runat="server" ForeColor="Red" />
                <div style="float:right;width:300px;padding:5px; text-align:right;">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
