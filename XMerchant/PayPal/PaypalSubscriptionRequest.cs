using System;
using System.Collections.Specialized;

namespace XMerchant.PayPal
{
	public class PaypalSubscriptionRequest
	{
		private readonly IPayPalSettings _settings;

		protected PaypalSubscriptionRequest()
		{
			EditMode = PayPalSubscriptionEditMode.CreateOnly;
			SubscriptionPeriod = new Period { Price = 1, Length = 1, Unit = PayPalSubscriptionPeriodUnit.Month };
			Recurs = PayPalSubscriptionRecurrance.On;
			Shipping = PayPalShippingMode.Disabled;
			ReturnUrlMethod = PayPalReturnUrlMethod.Post;
		}

		public PaypalSubscriptionRequest(IPayPalSettings settings) : this()
		{
			_settings = settings;
		}

		public PayPalSubscriptionEditMode EditMode { get; set; }

		/// <summary>
		/// The item reference number
		/// </summary>
		public string ItemNumber { get; set; }

		/// <summary>
		/// Passed back when the payment is made. Max 255 characters.
		/// </summary>
		public string CustomValue { get; set; }

		/// <summary>
		/// A descriptive name for the type of subscription
		/// </summary>
		public string ItemName { get; set; }

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

		public class Period
		{
			/// <summary>
			/// Size of the period time unit (see <see cref="Length" />)
			/// </summary>
			public PayPalSubscriptionPeriodUnit Unit { get; set; }

			/// <summary>
			/// Number of time units that the period should last for
			/// </summary>
			public int Length { get; set; }

			/// <summary>
			/// Cost of the period. Set to 0 to make it free.
			/// </summary>
			public double Price { get; set; }
		}

		/// <summary>
		/// The details for the first trial period (null if no trial period)
		/// </summary>
		public Period TrialPeriod1 { get; set; }

		/// <summary>
		/// The details for the second trial period (requires a value for <see cref="TrialPeriod1" />, or null if no second trial period)
		/// </summary>
		public Period TrialPeriod2 { get; set; }

		/// <summary>
		/// The details for the regular subscription period
		/// </summary>
		public Period SubscriptionPeriod { get; set; }

		/// <summary>
		/// Indicates whether or not subscription payments recur after the first regular subscription period has ended
		/// </summary>
		public PayPalSubscriptionRecurrance Recurs { get; set; }

		/// <summary>
		/// Specifies whether or not that customer should provide shipping information during the checkout process
		/// </summary>
		public PayPalShippingMode Shipping { get; set; }

		public PayPalReturnUrlMethod ReturnUrlMethod { get; set; }

		public NameValueCollection GetValues()
		{
			var nvc = new NameValueCollection
			{
				{ PayPalRequestVariables.Command, PayPalManager.ValueOf(PayPalCommand.Subscription) },
				{ PayPalRequestVariables.SellerPayPalAccount, _settings.Account },
				{ PayPalRequestVariables.ItemName, ItemName },
				{ PayPalRequestVariables.ItemNumber, ItemNumber },
				{ PayPalRequestVariables.ReturnUrlMethod, PayPalManager.ValueOf(ReturnUrlMethod) },
				{ PayPalRequestVariables.ShippingMode, PayPalManager.ValueOf(Shipping) },
				{ PayPalRequestVariables.SubscriptionPrice, SubscriptionPeriod.Price.ToString() },
				{ PayPalRequestVariables.SubscriptionPeriodDuration, SubscriptionPeriod.Length.ToString() },
				{ PayPalRequestVariables.SubscriptionPeriodDurationUnit, PayPalManager.ValueOf(SubscriptionPeriod.Unit) },
				{ PayPalRequestVariables.SubscriptionPaymentsRecur, PayPalManager.ValueOf(Recurs) },
				{ PayPalRequestVariables.ReattemptPaymentOnFailure, PayPalManager.ValueOf(PayPalFailedPaymentReattempt.On) },
				{ PayPalRequestVariables.AllowPaymentNoteFromCustomer, PayPalManager.ValueOf(PayPalUserPaymentNote.Disallowed) },
				{ PayPalRequestVariables.CustomValue, CustomValue },
				{ PayPalRequestVariables.SubscriptionModification, PayPalManager.ValueOf(EditMode) },
			};
			if (TrialPeriod1 != null)
			{
				nvc.Add(PayPalRequestVariables.TrialPeriod1Price, TrialPeriod1.Price.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod1Duration, TrialPeriod1.Length.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod1DurationUnit, PayPalManager.ValueOf(TrialPeriod1.Unit));
			}
			if (TrialPeriod2 != null)
			{
				nvc.Add(PayPalRequestVariables.TrialPeriod2Price, TrialPeriod2.Price.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod2Duration, TrialPeriod2.Length.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod2DurationUnit, PayPalManager.ValueOf(TrialPeriod2.Unit));
			}
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