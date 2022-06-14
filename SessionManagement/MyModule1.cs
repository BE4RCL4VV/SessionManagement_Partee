using System;
using System.Web;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace SessionManagement_Partee
{
    public class MyModule1 : IHttpModule
	{
		public void Dispose()
		{
			// nothing to dispose
		}
		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(OnBeginRequest);
			context.EndRequest += new EventHandler(OnEndRequest);
		}
        public void OnBeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string URL = context.Request.Path;
            NameValueCollection Q = context.Request.QueryString;
        }
        private void OnEndRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            //string URL = context.Request.Path;
            string user = context.Request.QueryString["u"];
            string pass = context.Request.QueryString["p"];
            NameValueCollection Q = context.Request.QueryString;

            if (user == null || pass == null || user.Length == 0 || pass.Length == 0)
            {
                context.Response.Write("There is currently no Encrypted data");
            }
            else
            {
                TextEncryption textEncryption = new TextEncryption();
                user = textEncryption.Decrypt(textEncryption.RemoveSpace(user));
                pass = textEncryption.Decrypt(textEncryption.RemoveSpace(pass));
                user = user.Remove(user.Length - 88);
                pass = pass.Remove(pass.Length - 88);
                context.Response.Write("This is the data being passed from module - " + "Your Decrypted UserName is ----> " + user + " and your Decrypted password is ----> " + pass);
            }
        }

    }
}
