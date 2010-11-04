using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using AxeFrog;

namespace XMerchant.PayPal.Web
{
	public static class PayPalUrlWriter
	{
		public static Uri GetUrl(NameValueCollection payPalVariables, IPayPalSettings cfg)
		{
			var url = cfg.TestMode ? PayPalUrl.Sandbox : PayPalUrl.Production;
			var list = payPalVariables.AllKeys.Select(key => string.Concat(HttpUtility.UrlEncode(key), "=", HttpUtility.UrlEncode(payPalVariables[key]))).ToList();
			return new Uri(string.Concat(url, "?", list.Concat("&")));
		}
	}
}