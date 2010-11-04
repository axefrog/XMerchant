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

		public static string Concat<T>(this IEnumerable<T> values, string delimiter)
		{
			StringBuilder sb = new StringBuilder();
			int c = 0;
			if(values == null) values = new T[0];
			foreach(T k in values)
			{
				if(c++ > 0)
					sb.Append(delimiter);
				sb.Append(k);
			}
			return sb.ToString();
		}

		public static string ToQueryString(this NameValueCollection nvc)
		{
			if (nvc == null)
				return string.Empty;
			List<string> list = new List<string>();
			foreach (string key in nvc.Keys)
				list.Add(HttpUtility.UrlEncode(key.ToString()) + "=" + HttpUtility.UrlEncode(nvc[key]));
			return list.Concat("&");
		}
	}
}
