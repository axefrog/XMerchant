using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace XMerchant
{
	internal static class Extensions
	{
		internal static string ResolveUrl(this string str)
		{
			if(HttpContext.Current == null || str.Contains("://"))
				return str;
			if(str.StartsWith("~/"))
			{
				var appPath = HttpContext.Current.Request.ApplicationPath;
				if(appPath == "/")
					appPath = "";
				str = appPath + str.Substring(1);
			}
			return new Uri(HttpContext.Current.Request.Url, str).ToString();
		}
	}
}
