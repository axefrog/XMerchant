using System;
using System.ComponentModel;
using System.Linq;

namespace XMerchant.PayPal
{
	public enum PayPalTransactionType
	{
		/// <summary>
		/// A dispute has been resolved and closed
		/// </summary>
		[Description("A dispute has been resolved and closed")]
		[PayPalValue("adjustment")]
		Adjustment,
		/// <summary>
		/// Transaction created by a customer either (a) via the PayPal Shopping Cart feature or
		/// (b) via Express Checkout when the cart contains multiple items.
		/// </summary>
		[Description("Payment received for multiple items; source is Express Checkout or the PayPal Shopping Cart.")]
		[PayPalValue("cart")]
		Cart,
		/// <summary>
		/// Transaction created by Express Checkout when the customer's cart contains a single item
		/// </summary>
		[Description("Payment received for a single item; source is Express Checkout")]
		[PayPalValue("express_checkout")]
		ExpressCheckout,
		/// <summary>
		/// Transaction created by customer from the Send Money tab on the PayPal website
		/// </summary>
		[Description("Payment received; source is the Send Money tab on the PayPal website")]
		[PayPalValue("send_money")]
		SendMoney,
		/// <summary>
		/// Transaction created with the Virtual Terminal
		/// </summary>
		[Description("Payment received; source is Virtual Terminal")]
		[PayPalValue("virtual_terminal")]
		VirtualTerminal,
		/// <summary>
		/// Transaction created by customer via Buy Now, Donation or Auction Smart Logos
		/// </summary>
		[Description("Payment received; source is a Buy Now, Donation, or Auction Smart Logos button")]
		[PayPalValue("web_accept")]
		WebAccept,
		/// <summary>
		/// This payment was sent via Mass Payment
		/// </summary>
		[Description("Payment sent using MassPay")]
		[PayPalValue("masspay")]
		MassPay,
		/// <summary>
		/// Subscription signup
		/// </summary>
		[Description("Subscription started")]
		[PayPalValue("subscr_signup")]
		SubscriptionSignup,
		/// <summary>
		/// Subscription payment failure
		/// </summary>
		[Description("Subscription signup failed")]
		[PayPalValue("subscr_failed")]
		SubscriptionFailed,
		/// <summary>
		/// Subscription cancellation
		/// </summary>
		[Description("Subscription canceled")]
		[PayPalValue("subscr_cancel")]
		SubscriptionCancelled,
		/// <summary>
		/// Subscription payment successful
		/// </summary>
		[Description("Subscription payment received")]
		[PayPalValue("subscr_payment")]
		SubscriptionPayment,
		/// <summary>
		/// Subscription's end of term has been reached
		/// </summary>
		[Description("Subscription expired")]
		[PayPalValue("subscr_eot")]
		SubscriptionEndOfTerm,
		/// <summary>
		/// The subscription has been modified
		/// </summary>
		[Description("Subscription modified")]
		[PayPalValue("subscr_modify")]
		SubscriptionModification,
		/// <summary>
		/// A new dispute case has been registered
		/// </summary>
		[Description("A new dispute was filed")]
		[PayPalValue("new_case")]
		NewCase,
		/// <summary>
		/// Website Payments Pro monthly billing fee
		/// </summary>
		[Description("Monthly subscription paid for Website Payments Pro")]
		[PayPalValue("merch_pmt")]
		WebsitePaymentsProFee,
		/// <summary>
		/// Some transaction type that did not exist when this code was written
		/// </summary>
		[PayPalUnknownValue]
		Unknown = 99
	}

	public enum PayPalAddressStatus
	{
		[Description("Customer provided a confirmed address")]
		[PayPalValue("confirmed")]
		Confirmed,
		[Description("Customer provided an unconfirmed address")]
		[PayPalValue("unconfirmed")]
		Unconfirmed
	}

	public enum PayPalPayerStatus
	{
		Verified,
		Unverified
	}

	public enum PayPalAuthorizationResponse
	{
		Success,
		Failed
	}

	public enum PayPalCommand
	{
		/// <summary>
		/// The button that the person clicked was a Buy Now button
		/// </summary>
		[Description("The button that the person clicked was a Buy Now button")]
		[PayPalValue("_xclick")]
		BuyNow,
		/// <summary>
		/// The button that the person clicked was a Donate button
		/// </summary>
		[Description("The button that the person clicked was a Donate button")]
		[PayPalValue("_donations")]
		Donation,
		/// <summary>
		/// The button that the person clicked was a Buy Gift Certificate button
		/// </summary>
		[Description("The button that the person clicked was a Buy Gift Certificate button")]
		[PayPalValue("_oe-gift-certificate")]
		GiftCertificate,
		/// <summary>
		/// For shopping cart purchases
		/// </summary>
		[Description("For shopping cart purchases")]
		[PayPalValue("_cart")]
		ShoppingCart,
		/// <summary>
		/// For prepopulating PayPal account signup. Requires use of the redirect_cmd hidden field.
		/// </summary>
		[Description("Prepopulate PayPal payment page with customer details")]
		[PayPalValue("_ext-enter")]
		PrePopulatePaypalAccountSignup,
		/// <summary>
		/// Used for creating or modifying PayPal subscriptions
		/// </summary>
		[Description("The button that the person clicked was a Subscribe button")]
		[PayPalValue("_xclick-subscriptions")]
		Subscription,
		/// <summary>
		/// Used for encrypted payment buttons, with the real cmd variable contained in the encrypted value
		/// </summary>
		[Description("Encrypted payment button, with the real cmd variable contained in the encrypted value")]
		[PayPalValue("_s-xclick")]
		EncryptedCommand,
		/// <summary>
		/// Used to validate that an IPN is authentic
		/// </summary>
		[Description("Validate that an Instant Payment Notification is authentic")]
		[PayPalValue("_notify-validate")]
		ValidateIPN,
		
		[PayPalUnknownValue]
		Unknown
	}

	public enum PayPalPaymentStatus
	{
		/// <summary>
		/// A reversal has been canceled. For example, you won a dispute with the customer, and the
		/// funds for the transaction that was reversed have been returned to you.
		/// </summary>
		CanceledReversal,
		/// <summary>
		/// The payment has been completed, and the funds have been added successfully to your
		/// account balance.
		/// </summary>
		Completed,
		/// <summary>
		/// You denied the payment. This happens only if the payment was previously pending because
		/// of possible reasons described for the PendingReason element.
		/// </summary>
		Denied,
		/// <summary>
		/// This authorization has expired and cannot be captured.
		/// </summary>
		Expired,
		/// <summary>
		/// The payment has failed. This happens only if the payment was made from your customer's
		/// bank account.
		/// </summary>
		Failed,
		/// <summary>
		/// The transaction is in process of authorization and capture.
		/// </summary>
		InProgress,
		/// <summary>
		/// The transaction has been partially refunded.
		/// </summary>
		PartiallyRefunded,
		/// <summary>
		/// The payment is pending. See pending_ re for more information.
		/// </summary>
		Pending,
		/// <summary>
		/// A payment has been accepted.
		/// </summary>
		Processed,
		/// <summary>
		/// You refunded the payment.
		/// </summary>
		Refunded,
		/// <summary>
		/// A payment was reversed due to a chargeback or other type of reversal. The funds have been
		/// removed from your account balance and returned to the buyer. The reason for the reversal
		/// is specified in the ReasonCode element.
		/// </summary>
		Reversed,
		/// <summary>
		/// This authorization has been voided.
		/// </summary>
		Voided
	}

	/// <summary>
	/// Used to determine how the post-payment redirect will work. If IPN is on, the return method will default to Post. More information at
	/// https://www.x.com/docs/DOC-1552
	/// https://cms.paypal.com/us/cgi-bin/?&cmd=_render-content&content_ID=developer/e_howto_html_Appx_websitestandard_htmlvariables#id08A6HF00TZS
	/// https://www.x.com/message/157476#157476
	/// </summary>
	public enum PayPalReturnURLMethod
	{
		[Description("All shopping cart transactions use the GET method")]
		[PayPalValue("0")]
		Default,
		[Description("The payer's browser is redirected to the return URL by the GET method and no transaction variables are sent")]
		[PayPalValue("1")]
		Get,
		[Description("the payer's browser is redirected to the return URL by the POST method and all transaction variables are also posted")]
		[PayPalValue("2")]
		Post
	}

	public enum PayPalShippingMode
	{
		[Description("Prompt for an address, but do not require one")]
		[PayPalValue("0")]
		AddressOptional,
		[Description("Prompt for an address, and require one")]
		[PayPalValue("2")]
		AddressRequired,
		[Description("Do not prompt for an address")]
		[PayPalValue("1")]
		Disabled
	}

	public enum PayPalSubscriptionPeriodUnit
	{
		[PayPalValue("D")]
		Day,
		[PayPalValue("W")]
		Week,
		[PayPalValue("M")]
		Month,
		[PayPalValue("Y")]
		Year
	}

	public enum PayPalSubscriptionEditMode
	{
		[PayPalValue("0")]
		CreateOnly,
		[PayPalValue("1")]
		CreateOrModify,
		[PayPalValue("2")]
		ModifyOnly
	}

	public enum PayPalCaseType
	{
		[PayPalValue("chargeback")]
		Chargeback,
		[PayPalValue("complaint")]
		Complaint,
		[PayPalValue("dispute")]
		Dispute
	}

	public enum PayPalSubscriptionRecurrance
	{
		[Description("Subscription payments recur")]
		[PayPalValue("1")]
		On,
		[Description("Subscription payments do not recur")]
		[PayPalValue("0")]
		Off
	}

	public enum PayPalFailedPaymentReattempt
	{
		[Description("Reattempt failed recurring payments before canceling")]
		[PayPalValue("1")]
		On,
		[Description("Do not reattempt failed recurring payments")]
		[PayPalValue("0")]
		Off
	}

	public enum PayPalUserPaymentNote
	{
		[Description("Show the text box and the prompt")]
		[PayPalValue("0")]
		Allowed,
		[Description("Hide the text box and the prompt")]
		[PayPalValue("1")]
		Disallowed
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PayPalValueAttribute : Attribute
	{
		public string Value { get; set; }

		public PayPalValueAttribute(string value)
		{
			Value = value;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class PayPalUnknownValueAttribute : Attribute
	{
	}

	public static class PayPalEnum
	{
	}
}