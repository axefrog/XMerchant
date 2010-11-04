using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMerchant.PayPal
{
	public class PayPalTransaction
	{
		#region Transaction and Notification-Related Variables
		/// <summary>
		/// The PayPal account login or email address that the payment has been sent to. Note that this can be a subaccount of another PayPal account.
		/// See <see cref="RecipientAccount" /> for the primary account holder email.
		/// </summary>
		public string RecipientAccount { get; set; }

		/// <summary>
		/// The primary PayPal account holder receiving the payment/transaction notification. The primary account holder email address is specified
		/// even if the payment was targeted at a subaccount of the primary PayPal account.
		/// </summary>
		public string RecipientAccountEmail { get; set; }
		public string CharacterSet { get; set; }

		/// <summary>
		/// A custom value passed to PayPal by this application when the transaction was initiated.
		/// </summary>
		public string CustomReference { get; set; }

		/// <summary>
		/// Represents the version of the notification message sent by PayPal. Expected to change only when PayPal implements new features that
		/// affect their IPN system.
		/// </summary>
		public string NotificationVersion { get; set; }

		/// <summary>
		/// In the case of a refund, reversal or canceled reversal, this contains the <see cref="TransactionID" /> of the original
		/// transaction, while <see cref="TransactionID" /> contains a new ID for the new transaction.
		/// </summary>
		public string ParentTransactionID { get; set; }

		/// <summary>
		/// A unique ID generated during guest checkout (payment by credit card without logging in)
		/// </summary>
		public string GuestReceiptID { get; set; }

		/// <summary>
		/// Specifies whether or not this transaction was a resend of an earlier failed IPN notification
		/// </summary>
		public bool Resent { get; set; }

		/// <summary>
		/// Unique account ID of the payment recipient (i.e. the merchant)
		/// </summary>
		public string RecipientAccountID { get; set; }

		/// <summary>
		/// The ISO 3166 country code associated with the country of residence of the person who initiated this transaction
		/// </summary>
		public string PurchaseCountryCode { get; set; }

		/// <summary>
		/// Specifies whether this transaction came from the PayPal Developer Sandbox
		/// </summary>
		public bool IsTest { get; set; }

		/// <summary>
		/// The unique ID for this transaction
		/// </summary>
		public string TransactionID { get; set; }

		/// <summary>
		/// The type of the transaction
		/// </summary>
		public PayPalTransactionType TransactionType { get; set; }

		/// <summary>
		/// An encrypted string used to validate the authenticity of the transaction during IPN authentication
		/// </summary>
		public string Signature { get; set; }
		#endregion
		
		#region Buyer Information Variables
		/// <summary>
		/// Country of customer's address (Length: 64 characters)
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// City of customer's address (Length: 40 characters)
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// ISO 3166 country code associated with customer's address (Length: 2 characters)
		/// </summary>
		public string CountryCode { get; set; }

		/// <summary>
		/// Name used with address - included when the customer provides a Gift Address (Length: 128 characters)
		/// </summary>
		public string RecipientName { get; set; }

		/// <summary>
		/// State of customer’s address (Length: 40 characters)
		/// </summary>
		public string State { get; set; }

		/// <summary>
		/// Whether the customer provided a confirmed address
		/// </summary>
		public PayPalAddressStatus? Status { get; set; }

		/// <summary>
		/// Customer's street address. (Length: 200 characters)
		/// </summary>
		public string Street { get; set; }

		/// <summary>
		/// Zip or postal code code of customer’s address. (Length: 20 characters)
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// Customer’s telephone number. (Length: 20 characters)
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Customer’s first name (Length: 64 characters)
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Customer’s last name (Length: 64 characters)
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Customer’s company name, if customer is a business (Length: 127 characters)
		/// </summary>
		public string BusinessName { get; set; }

		/// <summary>
		/// Customer’s primary email address. Use this email to provide any credits. (Length: 127 characters)
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Unique customer ID. (Length: 13 characters)
		/// </summary>
		public string PayerID { get; set; }
		#endregion

		#region Subscription Information Variables
		public class Period
		{
			/// <summary>
			/// Size of the period time unit (see <see cref="Length" />)
			/// </summary>
			public PayPalSubscriptionPeriodUnit Unit { get; set; }

			/// <summary>
			/// Number of time units that period lasts for
			/// </summary>
			public int Length { get; set; }

			/// <summary>
			/// Charged amount for the period. 0 = free
			/// </summary>
			public double Amount { get; set; }
		}

		/// <summary>
		/// The details of the first trial period (null if none)
		/// </summary>
		public Period TrialPeriod1 { get; set; }
		/// <summary>
		/// The details of the second trial period (null if no second trial period - there is never a second trial period when TrialPeriod1 is null)
		/// </summary>
		public Period TrialPeriod2 { get; set; }
		/// <summary>
		/// The details of the regular subscription period
		/// </summary>
		public Period SubscriptionPeriod { get; set; }
		/// <summary>
		/// The username generated by PayPal for use in your system (if any)
		/// </summary>
		public string GeneratedUsername { get; set; }
		/// <summary>
		/// The password generated by PayPal for use in your system (if any)
		/// </summary>
		public string GeneratedPassword { get; set; }
		/// <summary>
		/// Indicates whether failed subscription payments will be reattempted
		/// </summary>
		public bool FailedPaymentsWillBeReattempted { get; set; }
		/// <summary>
		/// Indicates the number of times that the regular subscription period will recur
		/// </summary>
		public int? RecurranceCount { get; set; }
		/// <summary>
		/// Indicates whether the regular subscription period recurs
		/// </summary>
		public bool IsRecurring { get; set; }
		/// <summary>
		/// The next date that the previous failed payment will be attempted (if applicable)
		/// </summary>
		public DateTime? NextRetryDate { get; set; }
		/// <summary>
		/// The date that the new subscription (or subscription cancellation) takes effect
		/// </summary>
		public DateTime? SubscriptionDate { get; set; }
		/// <summary>
		/// The date that the subscription modification (if applicable) will take effect
		/// </summary>
		public DateTime? SubscriptionChangeEffectiveDate { get; set; }
		/// <summary>
		/// The unique PayPal ID of the subscription
		/// </summary>
		public string SubscriptionID { get; set; }
		
		#endregion

		#region Payment Information Variables
		public double? TransactionFee { get; set; }
		public double? GrossAmount { get; set; }
		public PayPalPaymentStatus? PaymentStatus { get; set; }
		public PayPalReasonCode? ReasonCode { get; set; }
		#endregion

	}
}
