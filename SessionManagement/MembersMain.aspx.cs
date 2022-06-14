using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement_Partee
{
	public partial class MembersMain : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			string user = Request.QueryString["u"];
			string pass = Request.QueryString["p"];

			lblUser.Text = "<h4>Hello, you are encrypted user</h4> " + user + " <h4>Your encrypted password is </h4>" + pass;
		}
		protected void btnThirdPage_Click(object sender, EventArgs e)
        {
			string _encryptedUser = Request.QueryString["u"];
			string _encryptedPass = Request.QueryString["p"];
			TextEncryption textEncryption = new TextEncryption();

			Response.Redirect("ThirdPage.aspx?u=" + textEncryption.RemoveSpace(_encryptedUser) + "&p=" + textEncryption.RemoveSpace(_encryptedPass));
		}
	}
}
