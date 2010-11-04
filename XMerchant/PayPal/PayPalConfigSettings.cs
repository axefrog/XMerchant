using System;
using System.Configuration;
using System.Web;

namespace XMerchant.PayPal
{
	/// <summary>
	/// An implementation of <see cref="IPayPalSettings" /> where all values are retrieved from the application
	/// configuration file. Values relating to Encrypted Website Payments (EWP) can be ignored if EWP is not used.
	/// Properties specifying Urls can also be ignored if desired, but if used, can either be an absolute (http[s]://)
	/// path, a relative path (/path/to/here) or an application-relative path (~/path/to/here). For full details on
	/// each property, see <see cref="IPayPalSettings" /> documentation.
	/// </summary>
	public class PayPalConfigSettings : IPayPalSettings
	{
		private static PayPalConfigSettings _default = new PayPalConfigSettings();
		public static PayPalConfigSettings Default
		{
			get { return _default; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.Account".
		/// </summary>
		public string Account
		{
			get { return ConfigurationManager.AppSettings["PayPal.Account"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.TestMode". A value of "true" is required to
		/// indicate that test mode is active.
		/// </summary>
		public bool TestMode
		{
			get { return (ConfigurationManager.AppSettings["PayPal.TestMode"] ?? "").ToLower() == "true"; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.Encrypt". A value of "true" is required to
		/// indicate that payment variables should be encrypted befoe being written to a form.
		/// </summary>
		public bool Encrypt
		{
			get
			{
				var val = (ConfigurationManager.AppSettings["PayPal.Encrypt"] ?? "").ToLower();
				return val == "true" || (!HttpContext.Current.Request.IsLocal && val == "remoteonly");
			}
		}

		private string GetPath(string path)
		{
			if(HttpContext.Current == null || path.Contains(":\\") || path.StartsWith("\\\\"))
				return path;
			return HttpContext.Current.Server.MapPath(path);
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.EWP.RecipientPublicCertPath".
		/// </summary>
		public string RecipientPublicCertPath
		{
			get { return GetPath(ConfigurationManager.AppSettings["PayPal.EWP.RecipientPublicCertPath"]); }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.EWP.SignerPfxPath".
		/// </summary>
		public string SignerPfxPath
		{
			get { return GetPath(ConfigurationManager.AppSettings["PayPal.EWP.SignerPfxPath"]); }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.EWP.SignerPfxPassword".
		/// </summary>
		public string SignerPfxPassword
		{
			get { return ConfigurationManager.AppSettings["PayPal.EWP.SignerPfxPassword"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.EWP.CertID".
		/// </summary>
		public string CertID
		{
			get { return ConfigurationManager.AppSettings["PayPal.EWP.CertID"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.ReturnUrl".
		/// </summary>
		public string ReturnUrl
		{
			get { return ConfigurationManager.AppSettings["PayPal.ReturnUrl"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.NotifyUrl".
		/// </summary>
		public string NotifyUrl
		{
			get { return ConfigurationManager.AppSettings["PayPal.NotifyUrl"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.CancelUrl".
		/// </summary>
		public string CancelUrl
		{
			get { return ConfigurationManager.AppSettings["PayPal.CancelUrl"]; }
		}

		/// <summary>
		/// See appSettings in your application configuration file under "PayPal.LogoUrl".
		/// </summary>
		public string LogoUrl
		{
			get { return ConfigurationManager.AppSettings["PayPal.LogoUrl"]; }
		}
	}
}