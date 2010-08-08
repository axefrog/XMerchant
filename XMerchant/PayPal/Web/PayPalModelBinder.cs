using System.Web;
using System.Web.Mvc;

namespace XMerchant.PayPal.Web
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
