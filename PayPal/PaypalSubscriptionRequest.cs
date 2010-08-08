using System;
using System.Collections.Specialized;

namespace XMerchant.PayPal
{
	public class PaypalSubscriptionRequest
	{
		private string _sellerPayPalAccount;
		//private string ipnURL;

		private bool _testMode;
		public PaypalSubscriptionRequest(bool testMode, string sellerPayPalAccount, string notifyURL, string returnURL, string cancelURL)
		{
			EditMode = PayPalSubscriptionEditMode.CreateOrModify;
			ItemName = "";
			TrialPeriodPrice = 0;
			TrialPeriodSize = 1;
			TrialPeriodUnit = PayPalSubscriptionPeriodUnit.Month;
			SubscriptionPrice = 1;
			SubscriptionPeriodSize = 1;
			CustomValue = "";
			ItemNumber = "";
			LogoURL = "";
			ReturnURL = returnURL;
			CancelURL = cancelURL;
			NotifyURL = notifyURL;

			_testMode = testMode;
			_sellerPayPalAccount = sellerPayPalAccount;
		}

		public PayPalSubscriptionEditMode EditMode { get; set; }

		/// <summary>
		/// The URL which will receive instant payment notifications automatically when aspects of the subscription change
		/// </summary>
		public string NotifyURL { get; set; }

		/// <summary>
		/// The URL of the company logo to use
		/// </summary>
		public string LogoURL { get; set; }

		/// <summary>
		/// The item reference number
		/// </summary>
		public string ItemNumber { get; set; }

		/// <summary>
		/// Passed back when the payment is made. Max 255 characters.
		/// </summary>
		public string CustomValue { get; set; }

		/// <summary>
		/// The subscription billing period time unit
		/// </summary>
		public PayPalSubscriptionPeriodUnit SubscriptionPeriodUnit { get; set; }

		/// <summary>
		/// The number of time units that make up the billing period
		/// </summary>
		public int SubscriptionPeriodSize { get; set; }

		/// <summary>
		/// The price of the subscription per time unit
		/// </summary>
		public double SubscriptionPrice { get; set; }

		/// <summary>
		/// Size of the trial period time unit (see TrialPeriodSize)
		/// </summary>
		public PayPalSubscriptionPeriodUnit TrialPeriodUnit { get; set; }

		/// <summary>
		/// Number of time units that the trial period should last for
		/// </summary>
		public int TrialPeriodSize { get; set; }

		/// <summary>
		/// Cost of the trial period. Set to 0 to make it free.
		/// </summary>
		public double TrialPeriodPrice { get; set; }

		/// <summary>
		/// A URL where the user is to be sent if the transaction is cancelled.
		/// </summary>
		public string CancelURL { get; set; }

		/// <summary>
		/// The URL where the user is returned to after completing the transaction.
		/// Variables detailing the transaction are posted here.
		/// </summary>
		public string ReturnURL { get; set; }

		/// <summary>
		/// A descriptive name for the type of subscription
		/// </summary>
		public string ItemName { get; set; }

		public NameValueCollection GetNameValueCollection()
		{
			var nvc = new NameValueCollection
			{
				{ PayPalRequestVariables.Command, PayPalManager.ValueOf(PayPalCommand.Subscription) },
				{ PayPalRequestVariables.SellerPayPalAccount, _sellerPayPalAccount },
				{ PayPalRequestVariables.ItemName, ItemName },
				{ PayPalRequestVariables.ItemNumber, ItemNumber },
				{ PayPalRequestVariables.ReturnURL, ReturnURL },
				{ PayPalRequestVariables.InstantPaymentNotificationURL, NotifyURL },
				{ PayPalRequestVariables.SubscriptionCancellationURL, CancelURL },
				{ PayPalRequestVariables.CustomLogoURL, LogoURL },
				{ PayPalRequestVariables.ReturnURLMethod, PayPalManager.ValueOf(PayPalReturnURLMethod.Post) },
				{ PayPalRequestVariables.ShippingMode, PayPalManager.ValueOf(PayPalShippingMode.Disabled) },
				{ PayPalRequestVariables.SubscriptionPrice, SubscriptionPrice.ToString() },
				{ PayPalRequestVariables.SubscriptionPeriodDuration, SubscriptionPeriodSize.ToString() },
				{ PayPalRequestVariables.SubscriptionPeriodDurationUnit, PayPalManager.ValueOf(SubscriptionPeriodUnit) },
				{ PayPalRequestVariables.SubscriptionPaymentsRecur, PayPalManager.ValueOf(PayPalSubscriptionRecurrance.On) },
				{ PayPalRequestVariables.ReattemptPaymentOnFailure, PayPalManager.ValueOf(PayPalFailedPaymentReattempt.On) },
				{ PayPalRequestVariables.AllowPaymentNoteFromCustomer, PayPalManager.ValueOf(PayPalUserPaymentNote.Disallowed) },
				{ PayPalRequestVariables.CustomValue, CustomValue },
				{ PayPalRequestVariables.SubscriptionModification, PayPalManager.ValueOf(EditMode) },
			};
			if (TrialPeriodSize > 0)
			{
				nvc.Add(PayPalRequestVariables.TrialPeriod1Price, TrialPeriodPrice.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod1Duration, TrialPeriodSize.ToString());
				nvc.Add(PayPalRequestVariables.TrialPeriod1DurationUnit, PayPalManager.ValueOf(TrialPeriodUnit));
			}
			return nvc;
		}

		public Uri GetUriEncrypted(IPayPalSettings settings)
		{
			return PayPalEncryptedWebsitePayments.GetUri(GetNameValueCollection(), settings, _testMode);
		}

		public string GetEncrypted(IPayPalSettings settings)
		{
			return PayPalEncryptedWebsitePayments.Encrypt(GetNameValueCollection(), settings);
		}

		public Uri GetUri()
		{
			return new Uri((_testMode ? PayPalURL.Sandbox : PayPalURL.Production) + "?" + GetNameValueCollection().ToQueryString());
		}

		public static string GetCancelLink(bool testMode, string paypalMerchantEmail)
		{
			return (testMode ? PayPalURL.Sandbox : PayPalURL.Production) + "?cmd=_subscr-find&alias=" + paypalMerchantEmail;
		}
	}
}