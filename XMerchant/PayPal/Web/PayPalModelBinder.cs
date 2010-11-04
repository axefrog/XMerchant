using System.Web;
using System.Web.Mvc;

namespace XMerchant.PayPal.Web
{
	public class PayPalModelBinder : IModelBinder
	{
		public static void Register()
		{
			lock(typeof(PayPalTransaction))
			{
				if(ModelBinders.Binders[typeof(PayPalTransaction)] == null)
					ModelBinders.Binders[typeof(PayPalTransaction)] = new PayPalModelBinder();
			}
		}

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
