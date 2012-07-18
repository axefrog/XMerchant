using System;
using System.Collections.Specialized;

namespace XMerchant.PayPal
{
	public class PaypalBuyNowRequest
	{
		// Information about the variables can be found at https://cms.paypal.com/us/cgi-bin/?cmd=_render-content&content_ID=developer/e_howto_html_Appx_websitestandard_htmlvariables#id08A6HF080O3

		private readonly IPayPalSettings _settings;

		protected PaypalBuyNowRequest()
		{
			ShippingInputMode = PayPalShippingMode.Disabled;
		}

		public PaypalBuyNowRequest(IPayPalSettings settings) : this()
		{
			_settings = settings;
		}

		/// <summary>
		/// The price or amount of the product, service, or contribution, not including shipping, handling, or tax. If omitted from Buy Now or Donate buttons, payers enter their own amount at the time of payment.
		/// </summary>
		public decimal? Amount { get; set; }

		/// <summary>
		/// Discount amount associated with an item. It must be less than the selling price of the item. If you specify discount_amount and discount_amount2 is not defined, then this flat amount is applied regardless of the quantity of items purchased. Valid only for Buy Now and Add to Cart buttons.
		/// </summary>
		public decimal? DiscountAmount { get; set; }

		/// <summary>
		/// Discount rate (percentage) associated with an item. It must be set to a value less than 100. If you do not set discount_rate2, the value in discount_rate applies only to the first item regardless of the quantity of items purchased. Valid only for Buy Now and Add to Cart buttons.
		/// </summary>
		public decimal? DiscountRate { get; set; }

		/// <summary>
		/// Weight of items. If profile-based shipping rates are configured with a basis of weight, the sum of weight values is used to calculate the shipping charges for the transaction.
		/// </summary>
		public double? Weight { get; set; }

		/// <summary>
		/// The unit of measure if weight is specified
		/// </summary>
		public PayPalWeightUnit? WeightUnit { get; set; }

		/// <summary>
		/// Description of item. If omitted, payers enter their own name at the time of payment.
		/// </summary>
		public string ItemName { get; set; }

		/// <summary>
		/// Pass-through variable for you to track product or service purchased or the contribution made. The value you specify passed back to you upon payment completion.
		/// </summary>
		public string ItemNumber { get; set; }

		/// <summary>
		/// The cost of shipping this item. If you specify shipping and shipping2 is not defined, this flat amount is charged regardless of the quantity of items purchased. This use of the shipping variable is valid only for Buy Now and Add to Cart buttons. Default – If profile-based shipping rates are configured, buyers are charged an amount according to the shipping methods they choose.
		/// </summary>
		public decimal? ShippingAmount { get; set; }

		/// <summary>
		/// Transaction-based tax override variable. Set this to a flat tax amount to apply to the transaction regardless of the buyer’s location. This value overrides any tax settings set in your account profile. Valid only for Buy Now and Add to Cart buttons. Default – Profile tax settings, if any, apply.
		/// </summary>
		public decimal? TaxAmount { get; set; }

		/// <summary>
		/// Transaction-based tax override variable. Set this to a percentage that will be applied to amount multiplied the quantity selected during checkout. This value overrides any tax settings set in your account profile. Allowable values are numbers 0.001 through 100. Valid only for Buy Now and Add to Cart buttons. Default – Profile tax settings, if any, apply.
		/// </summary>
		public decimal? TaxRate { get; set; }

		/// <summary>
		/// Passed back when the payment is made. Max 255 characters.
		/// </summary>
		public string CustomValue { get; set; }

		/// <summary>
		/// An optional override value for the NotifyUrl property in your PayPal settings object
		/// </summary>
		public string NotifyUrl { get; set; }

		/// <summary>
		/// An optional override value for the ReturnUrl property in your PayPal settings object
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		/// An optional override value for the CancelUrl property in your PayPal settings object
		/// </summary>
		public string CancelUrl { get; set; }

		/// <summary>
		/// Specifies whether or not that customer should provide shipping information during the checkout process
		/// </summary>
		public PayPalShippingMode ShippingInputMode { get; set; }

		public NameValueCollection GetValues()
		{
			var nvc = new NameValueCollection
			{
				{ PayPalRequestVariables.Command, PayPalManager.ValueOf(PayPalCommand.BuyNow) },
				{ PayPalRequestVariables.SellerPayPalAccount, _settings.Account },
				{ PayPalRequestVariables.ItemName, ItemName },
				{ PayPalRequestVariables.ItemNumber, ItemNumber },
				{ PayPalRequestVariables.ReturnUrlMethod, PayPalManager.ValueOf(PayPalReturnUrlMethod.Post) },
				{ PayPalRequestVariables.ShippingMode, PayPalManager.ValueOf(ShippingInputMode) },
				{ PayPalRequestVariables.ReattemptPaymentOnFailure, PayPalManager.ValueOf(PayPalFailedPaymentReattempt.On) },
				{ PayPalRequestVariables.AllowPaymentNoteFromCustomer, PayPalManager.ValueOf(PayPalUserPaymentNote.Disallowed) },
				{ PayPalRequestVariables.CustomValue, CustomValue },
			};

			if(Amount.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.Amount, Amount.Value.ToString());
			if(DiscountAmount.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.DiscountAmount, DiscountAmount.Value.ToString());
			if(DiscountRate.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.DiscountRate, DiscountRate.Value.ToString());
			if(Weight.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.Weight, Weight.Value.ToString());
			if(WeightUnit.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.WeightUnit, PayPalManager.ValueOf(WeightUnit.Value));
			if(ShippingAmount.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.ShippingAmount, ShippingAmount.ToString());
			if(TaxAmount.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.TaxAmount, TaxAmount.ToString());
			if(TaxRate.HasValue) nvc.Add(PayPalRequestVariables.IndividualItems.TaxRate, TaxRate.ToString());

			var notifyUrl = string.IsNullOrWhiteSpace(NotifyUrl) ? string.IsNullOrWhiteSpace(_settings.NotifyUrl) ? null : _settings.NotifyUrl : NotifyUrl;
			if(notifyUrl != null)
				nvc.Add(PayPalRequestVariables.InstantPaymentNotificationUrl, notifyUrl.ResolveUrl());

			var returnUrl = string.IsNullOrWhiteSpace(ReturnUrl) ? string.IsNullOrWhiteSpace(_settings.ReturnUrl) ? null : _settings.ReturnUrl : ReturnUrl;
			if(returnUrl != null)
				nvc.Add(PayPalRequestVariables.ReturnUrl, returnUrl.ResolveUrl());

			var cancelUrl = string.IsNullOrWhiteSpace(CancelUrl) ? string.IsNullOrWhiteSpace(_settings.CancelUrl) ? null : _settings.CancelUrl : CancelUrl;
			if(cancelUrl != null)
				nvc.Add(PayPalRequestVariables.PaymentCancellationUrl, cancelUrl.ResolveUrl());

			if(!string.IsNullOrWhiteSpace(_settings.LogoUrl))
				nvc.Add(PayPalRequestVariables.CustomLogoUrl, _settings.LogoUrl.ResolveUrl());

			return _settings.Encrypt ? PayPalEncryptedWebsitePayments.Encrypt(nvc, _settings) : nvc;
		}
	}
}