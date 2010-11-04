using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace XMerchant.PayPal.Web
{
	public class PayPalFormWriter : IDisposable
	{
		private readonly TextWriter _writer;
		private bool _ended = false;

		public PayPalFormWriter(TextWriter writer)
		{
			_writer = writer;
		}

		public PayPalFormWriter()
		{
			_writer = HttpContext.Current.Response.Output;
		}

		public static PayPalFormWriter BeginMvcForm(NameValueCollection payPalVariables)
		{
			return new PayPalFormWriter().BeginForm(payPalVariables, PayPalConfigSettings.Default);
		}

		public PayPalFormWriter BeginForm(NameValueCollection payPalVariables, IPayPalSettings cfg)
		{
			lock(_writer)
			{
				_writer.Write(@"<form method=""post"" action=""{0}"">", cfg.TestMode ? PayPalUrl.Sandbox : PayPalUrl.Production);
				foreach(var key in payPalVariables.AllKeys)
					_writer.Write(@"<input type=""hidden"" name=""{0}"" value=""{1}"" />", HttpUtility.HtmlEncode(key), HttpUtility.HtmlEncode(payPalVariables[key]));
			}
			return this;
		}

		public void Write(string s)
		{
			lock(_writer)
				_writer.Write(s);
		}

		public void EndForm()
		{
			lock(_writer)
			{
				if(!_ended && _writer != null)
				{
					try
					{
						_writer.Write("</form>");
					}
					catch
					{
						// if the writer is already closed, don't throw an exception
					}
					_ended = true;
				}
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			EndForm();
		}
	}
}
