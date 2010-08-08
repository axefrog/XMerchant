using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace XMerchant
{
	internal static class Extensions
	{
		public static string ToQueryString(this NameValueCollection values)
		{
			if (values == null)
				return string.Empty;
			var list = (from string key in values.Keys select HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(values[key])).ToList();
			return list.Concat("&");
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

		public delegate string StringEncodeHandler<T>(T input);
		public static string Concat<T>(this IEnumerable<T> values, StringEncodeHandler<T> encodeValue)
		{
			return values.Concat("", encodeValue);
		}

		public static string Concat<T>(this IEnumerable<T> values, string delimiter, StringEncodeHandler<T> encodeValue)
		{
			StringBuilder sb = new StringBuilder();
			int c = 0;
			if(values == null) values = new T[0];
			foreach(T k in values)
			{
				if(c++ > 0)
					sb.Append(delimiter);
				sb.Append(encodeValue(k));
			}
			return sb.ToString();
		}
	}
}
