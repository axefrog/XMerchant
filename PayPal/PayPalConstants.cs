using System;

namespace XMerchant.PayPal
{
	public class PayPalUrl
	{
		public const string Production = "https://www.paypal.com/cgi-bin/webscr";
		public const string Sandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
	}

	public static class PayPalRequestVariables
	{
		/// <summary>
		/// The command that informs PayPal which operation you are trying to perform. See <see cref="PayPalCommand" /> enum for possible values.
		/// </summary>
		public const string Command = "cmd";
		/// <summary>
		/// The type of the PayPal transaction. See <see cref="PayPalTransactionType" /> enum for details.
		/// </summary>
		public const string TransactionType = "txn_type";
		/// <summary>
		/// Your PayPal ID or an email address associated with your PayPal account. Email addresses must be confirmed.
		/// </summary>
		public const string SellerPayPalAccount = "business";
		/// <summary>
		/// <para>Description of item being sold. If you are collecting aggregate payments, this can include a summary of all items purchased, tracking numbers, or generic terms such as “subscription.” If omitted, customer will see a field in which they have the option of entering an Item Name.</para>
		/// <para>Max Length: 127</para>
		/// </summary>
		public const string ItemName = "item_name";
		public const string ItemNumber = "item_number";
		public const string ReturnUrl = "return";
		public const string ReturnUrlMethod = "rm";
		public const string InstantPaymentNotificationUrl = "notify_url";
		public const string PaymentCancellationUrl = "cancel_return";
		public const string CustomLogoUrl = "image_url";
		public const string ShippingMode = "no_shipping";
		/// <summary>
		/// The currency of prices for trial periods and the subscription. The default is USD. For allowable values, see Currency Codes.
		/// </summary>
		public const string CurrencyCode = "currency_code";
		/// <summary>
		/// Trial period 1 price. For a free trial period, specify 0.
		/// </summary>
		public const string TrialPeriod1Price = "a1";
		/// <summary>
		/// Trial period 1 duration. Required if you specify a1. Specify an integer value in the allowable range for the units of duration that you specify with t1.
		/// </summary>
		public const string TrialPeriod1Duration = "p1";
		/// <summary>
		/// <para>Trial period 1 units of duration. Required if you specify a1. Allowable values:</para>
		/// <para>D – for days; allowable range for p1 is 1 to 90</para>
		/// <para>W – for weeks; allowable range for p1 is 1 to 52</para>
		/// <para>M – for months; allowable range for p1 is 1 to 24</para>
		/// <para>Y – for years; allowable range for p1 is 1 to 5</para>
		/// </summary>
		public const string TrialPeriod1DurationUnit = "t1";
		/// <summary>
		/// Trial period 2 price. Can be specified only if you also specify a1.
		/// </summary>
		public const string TrialPeriod2Price = "a2";
		/// <summary>
		/// Trial period 2 duration. Required if you specify a2. Specify an integer value in the allowable range for the units of duration that you specify with t2.
		/// </summary>
		public const string TrialPeriod2Duration = "p2";
		/// <summary>
		/// <para>Trial period 2 units of duration. Allowable values:</para>
		/// <para>D – for days; allowable range for p1 is 1 to 90</para>
		/// <para>W – for weeks; allowable range for p1 is 1 to 52</para>
		/// <para>M – for months; allowable range for p1 is 1 to 24</para>
		/// <para>Y – for years; allowable range for p1 is 1 to 5</para>
		/// </summary>
		public const string TrialPeriod2DurationUnit = "t2";
		/// <summary>
		/// Regular subscription price.
		/// </summary>
		public const string SubscriptionPrice = "a3";
		/// <summary>
		/// Subscription duration. Specify an integer value in the allowable range for the units of duration that you specify with t3.
		/// </summary>
		public const string SubscriptionPeriodDuration = "p3";
		/// <summary>
		/// <para>Regular subscription units of duration. Allowable values:</para>
		/// <para>D – for days; allowable range for p1 is 1 to 90</para>
		/// <para>W – for weeks; allowable range for p1 is 1 to 52</para>
		/// <para>M – for months; allowable range for p1 is 1 to 24</para>
		/// <para>Y – for years; allowable range for p1 is 1 to 5</para>
		/// </summary>
		public const string SubscriptionPeriodDurationUnit = "t3";
		/// <summary>
		/// <para>Recurring payments. Subscription payments recur unless subscribers cancel their subscriptions before the end of the current billing cycle or you limit the number of times that payments recur with the value that you specify for srt.</para>
		/// <para>Allowable values:</para>
		/// <para>0 – subscription payments do not recur</para>
		/// <para>1 – subscription payments recur</para>
		/// <para>The default is 0.</para>
		/// </summary>
		public const string SubscriptionPaymentsRecur = "src";
		/// <summary>
		/// Recurring times. Number of times that subscription payments recur. Specify an integer above 1. Valid only if you specify src="1".
		/// </summary>
		public const string SubscriptionRecurrancesMax = "srt";
		/// <summary>
		/// <para>Reattempt on failure. If a recurring payment fails, PayPal attempts to collect the payment two more times before canceling the subscription.</para>
		/// <para>Allowable values:</para>
		/// <para>0 – do not reattempt failed recurring payments</para>
		/// <para>1 – reattempt failed recurring payments before canceling</para>
		/// <para>The default is 1.</para>
		/// <para>For more information, see <a href="https://cms.paypal.com/us/cgi-bin/?&amp;cmd=_render-content&amp;content_ID=developer/e_howto_html_subscribe_buttons">Reattempting Failed Recurring Payments With Subscribe Buttons</a>.</para>
		/// </summary>
		public const string ReattemptPaymentOnFailure = "sra";
		/// <summary>
		/// <para>Do not prompt payers to include a note with their payments. Allowable values for Subscribe buttons:</para>
		/// <para>0 – show the text box and the prompt</para>
		/// <para>1 – hide the text box and the prompt</para>
		/// <para>For Subscribe buttons, always include no_note and set it to 1.</para>
		/// </summary>
		public const string AllowPaymentNoteFromCustomer = "no_note";
		/// <summary>
		/// User-defined field which must be unique with each subscription. The invoice number will be shown to subscribers with the other details of their transactions.
		/// </summary>
		public const string CustomValue = "custom";
		/// <summary>
		/// User-defined field which must be unique with each subscription. The invoice number will be shown to subscribers with the other details of their transactions.
		/// <para>Max Length: 127</para>
		/// </summary>
		public const string InvoiceNumber = "invoice";
		/// <summary>
		/// Modification behavior. Allowable values:
		/// <para>0 – allows subscribers to only create new subscriptions</para>
		/// <para>1 – allows subscribers to modify their current subscriptions or sign up for new ones</para>
		/// <para>2 – allows subscribers to only modify their current subscriptions</para>
		/// </summary>
		public const string SubscriptionModification = "modify";
		public const string PayPalNewUserAutoGenerate = "usr_manage";

		public const string EncryptedData = "encrypted";

		/// <summary>
		/// https://cms.paypal.com/us/cgi-bin/?&cmd=_render-content&content_ID=developer/e_howto_html_IPNandPDTVariables#id091EB01I0Y4
		/// </summary>
		public static class BuyerInformation
		{
			/// <summary>
			/// <para>Country of customer’s address</para>
			/// <para>Length: 64 characters</para>
			/// </summary>
			public const string Country = "address_country";
			/// <summary>
			/// <para>City of customer’s address</para>
			/// <para>Length: 40 characters</para>
			/// </summary>
			public const string City = "address_city";
		}
	}

	public static class PayPalResponseVariables
	{
		public static class TransactionInformation
		{
			/// <summary>
			/// The PayPal account login or email address that the payment has been sent to. Note that this can be a subaccount of another PayPal account.
			/// See <see cref="RecipientAccount" /> for the primary account holder email.
			/// </summary>
			public const string RecipientAccount = "business";

			/// <summary>
			/// The primary PayPal account holder receiving the payment/transaction notification. The primary account holder email address is specified
			/// even if the payment was targeted at a subaccount of the primary PayPal account.
			/// </summary>
			public const string RecipientAccountEmail = "receiver_email";

			public const string CharacterSet = "charset";

			/// <summary>
			/// A custom value passed to PayPal by this application when the transaction was initiated.
			/// </summary>
			public const string CustomReference = "custom";

			/// <summary>
			/// Represents the version of the notification message sent by PayPal. Expected to change only when PayPal implements new features that
			/// affect their IPN system.
			/// </summary>
			public const string NotificationVersion = "notify_version";

			/// <summary>
			/// In the case of a refund, reversal or canceled reversal, this contains the <see cref="TransactionID" /> of the original
			/// transaction, while <see cref="TransactionID" /> contains a new ID for the new transaction.
			/// </summary>
			public const string ParentTransactionID = "parent_txn_id";

			/// <summary>
			/// A unique ID generated during guest checkout (payment by credit card without logging in)
			/// </summary>
			public const string GuestReceiptID = "receipt_id";

			/// <summary>
			/// Specifies whether or not this transaction was a resend of an earlier failed IPN notification
			/// </summary>
			public const string Resent = "resend";

			/// <summary>
			/// Unique account ID of the payment recipient (i.e. the merchant)
			/// </summary>
			public const string RecipientAccountID = "receiver_id";

			/// <summary>
			/// The ISO 3166 country code associated with the country of residence of the person who initiated this transaction
			/// </summary>
			public const string CountryCode = "residence_country";

			/// <summary>
			/// Specifies whether this transaction came from the PayPal Developer Sandbox
			/// </summary>
			public const string IsTest = "test_ipn";

			/// <summary>
			/// The unique ID for this transaction
			/// </summary>
			public const string TransactionID = "txn_id";

			/// <summary>
			/// The type of the transaction
			/// </summary>
			public const string TransactionType = "txn_type";

			/// <summary>
			/// An encrypted string used to validate the authenticity of the transaction during IPN authentication
			/// </summary>
			public const string Signature = "verify_sign";
		}

		public static class BuyerInformation
		{
			/// <summary>
			/// Country of customer's address (Length: 64 characters)
			/// </summary>
			public const string Country = "address_country";

			/// <summary>
			/// City of customer's address (Length: 40 characters)
			/// </summary>
			public const string City = "address_city";

			/// <summary>
			/// ISO 3166 country code associated with customer's address (Length: 2 characters)
			/// </summary>
			public const string CountryCode = "address_country_code";

			/// <summary>
			/// Name used with address - included when the customer provides a Gift Address (Length: 128 characters)
			/// </summary>
			public const string RecipientName = "address_name";

			/// <summary>
			/// State of customer’s address (Length: 40 characters)
			/// </summary>
			public const string State = "address_state";

			/// <summary>
			/// Whether the customer provided a confirmed address
			/// </summary>
			public const string Status = "address_status";

			/// <summary>
			/// Customer's street address. (Length: 200 characters)
			/// </summary>
			public const string Street = "address_street";

			/// <summary>
			/// Zip or postal code code of customer’s address. (Length: 20 characters)
			/// </summary>
			public const string PostalCode = "address_zip";

			/// <summary>
			/// Customer’s telephone number. (Length: 20 characters)
			/// </summary>
			public const string Phone = "contact_phone";

			/// <summary>
			/// Customer’s first name (Length: 64 characters)
			/// </summary>
			public const string FirstName = "first_name";

			/// <summary>
			/// Customer’s last name (Length: 64 characters)
			/// </summary>
			public const string LastName = "last_name";

			/// <summary>
			/// Customer’s company name, if customer is a business (Length: 127 characters)
			/// </summary>
			public const string BusinessName = "payer_business_name";

			/// <summary>
			/// Customer’s primary email address. Use this email to provide any credits. (Length: 127 characters)
			/// </summary>
			public const string Email = "payer_email";

			/// <summary>
			/// Unique customer ID. (Length: 13 characters)
			/// </summary>
			public const string PayerID = "payer_id";
		}
	}
}