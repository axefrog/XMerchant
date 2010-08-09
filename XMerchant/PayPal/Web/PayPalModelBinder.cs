using System.Web;
using System.Web.Mvc;

namespace XMerchant.PayPal.Web
{
	public class PayPalModelBinder : IModelBinder
	{
		public static void Register()
		{
			lock(typeof(IPayPalTransaction))
			{
				if(ModelBinders.Binders[typeof(IPayPalTransaction)] == null)
					ModelBinders.Binders[typeof(IPayPalTransaction)] = new PayPalModelBinder();
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
