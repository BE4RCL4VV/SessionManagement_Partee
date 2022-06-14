using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement_Partee
{
	public partial class Default : System.Web.UI.Page
	{
		//public static string Salted
  //      {
  //          get
  //          {
  //              if (HttpContext.Current.Session["SecretSalt"] != null)
		//			return HttpContext.Current.Session["SecretSalt"].ToString();
		//		else
		//			return TextEncryption.getSalt();
  //          }
  //          set
  //          {
  //              HttpContext.Current.Session["SecretSalt"] = TextEncryption.getSalt(); 
  //          }
  //      }
		//protected void Page_Load(object sender, EventArgs e)
		//{
			
		//	RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
		//	var array = new byte[64];
		//	using (random)
		//	{
		//		random.GetNonZeroBytes(array);
		//	}
		//	HttpContext.Current.Session["SecretSalt"] = Convert.ToBase64String(array);
		//}

        protected void btnLogIn_Click(object sender, EventArgs e)
		{
			if ((txtUser.Text=="bgates" && txtPassword.Text=="billions") || (txtUser.Text=="fred" && txtPassword.Text=="flinstone"))
			{
				TextEncryption newEncryption = new TextEncryption();
				Session["User"] = txtUser.Text.Length;
				Session["Pass"] = txtPassword.Text.Length;
				string user = newEncryption.Encrypt(txtUser.Text);
				string pass = newEncryption.Encrypt(txtPassword.Text);

				Response.Redirect("MembersMain.aspx?u=" + user + "&p=" + pass);
			}
			else
			{
				lblMessage.Text = "Account not recognized";
			}
			
		}
	}
}