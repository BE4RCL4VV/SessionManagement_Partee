using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement_Partee
{
    public partial class ThirdPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Request.QueryString["u"];
            string pass = Request.QueryString["p"];

            TextEncryption textEncryption = new TextEncryption();
            user = textEncryption.Decrypt(textEncryption.RemoveSpace(user));
            pass = textEncryption.Decrypt(textEncryption.RemoveSpace(pass));

            user = user.Substring(0, (int)Session["User"]);
            pass = pass.Substring(0, (int)Session["Pass"]);

            lblUser.Text = "<h4>Hello, " + user + " Your password is " + pass + "</h4>";
        }
        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}