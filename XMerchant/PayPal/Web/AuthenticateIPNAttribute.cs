using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace XMerchant.PayPal.Web
{
	/// <summary>
	/// Performs a callback to PayPal to verify the authenticity of the IPN request. If failed,
	/// an HttpUnauthorizedResult (401) is returned.
	/// </summary>
	public class AuthenticateIPNAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if(!PayPalManager.AuthenticateIPN(filterContext.HttpContext.Request.Form))
				filterContext.Result = new HttpUnauthorizedResult();
		}
	}
}
