using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace XMerchant.PayPal
{
	public class PayPalModelBinder : IModelBinder
	{
		HttpRequest Request
		{
			get { return HttpContext.Current.Request; }
		}
		
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			return PayPalManager.CreateTransactionFrom(Request.Form);
		}
	}
}
