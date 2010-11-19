namespace XMerchant.PayPal
{
	internal class PayPalUrl
	{
		public const string Production = "https://www.paypal.com/cgi-bin/webscr";
		public const string Sandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
	}

	internal static class PayPalRequestVariables
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
		/// <summary>
		/// Pass-through variable for you to track product or service purchased or the contribution made. The value you specify passed back to you upon payment completion.
		/// </summary>
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

		public static class IndividualItems
		{
			public const string Amount = "amount";
			public const string DiscountAmount = "discount_amount";
			public const string DiscountAmount2 = "discount_amount2";
			public const string DiscountRate = "discount_rate";
			public const string DiscountRate2 = "discount_rate2";
			public const string DiscountNum = "discount_num";
			public const string Quantity = "quantity";
			public const string Shipping = "shipping";
			public const string Shipping2 = "shipping2";
			public const string Tax = "tax";
			public const string TaxRate = "tax_rate";
			public const string UndefinedQuantity = "undefined_quantity";
			public const string Weight = "weight";
			public const string WeightUnit = "weight_unit";
			public const string On0 = "on0";
			public const string On1 = "on1";
			public const string On2 = "on2";
			public const string On3 = "on3";
			public const string On4 = "on4";
			public const string On5 = "on5";
			public const string On6 = "on6";
			public const string Os0 = "os0";
			public const string Os1 = "os1";
			public const string Os2 = "os2";
			public const string Os3 = "os3";
			public const string Os4 = "os4";
			public const string Os5 = "os5";
			public const string Os6 = "os6";
			public const string OptionIndex = "option_index";
			public const string OptionSelect0 = "option_select0";
			public const string OptionAmount0 = "option_amount0";
			public const string OptionSelect1 = "option_select1";
			public const string OptionAmount1 = "option_amount1";
			public const string OptionSelect2 = "option_select2";
			public const string OptionAmount2 = "option_amount2";
			public const string OptionSelect3 = "option_select3";
			public const string OptionAmount3 = "option_amount3";
			public const string OptionSelect4 = "option_select4";
			public const string OptionAmount4 = "option_amount4";
			public const string OptionSelect5 = "option_select5";
			public const string OptionAmount5 = "option_amount5";
			public const string OptionSelect6 = "option_select6";
			public const string OptionAmount6 = "option_amount6";
			public const string OptionSelect7 = "option_select7";
			public const string OptionAmount7 = "option_amount7";
			public const string OptionSelect8 = "option_select8";
			public const string OptionAmount8 = "option_amount8";
			public const string OptionSelect9 = "option_select9";
			public const string OptionAmount9 = "option_amount9";
		}

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

	internal static class PayPalResponseVariables
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

		public static class SubscriptionInformation
		{
			/// <summary>
			/// Amount of payment for trial period 1 for USD payments; otherwise blank (optional).
			/// </summary>
			public const string Trial1AmountUSD = "amount1";
			/// <summary>
			/// Amount of payment for trial period 2 for USD payments; otherwise blank (optional).
			/// </summary>
			public const string Trial2AmountUSD = "amount2";
			/// <summary>
			/// Amount of payment for regular subscription period for USD payments; otherwise blank.
			/// </summary>
			public const string SubscriptionAmountUSD = "amount3";
			/// <summary>
			/// Amount of payment for trial period 1, regardless of currency (optional).
			/// </summary>
			public const string Trial1Amount = "mc_amount1";
			/// <summary>
			/// Amount of payment for trial period 2, regardless of currency (optional).
			/// </summary>
			public const string Trial2Amount = "mc_amount2";
			/// <summary>
			/// Amount of payment for regular subscription period, regardless of currency.
			/// </summary>
			public const string SubscriptionAmount = "mc_amount3";
			/// <summary>
			/// (optional) Password generated by PayPal and given to subscriber to access the subscription (password will be encrypted). Length: 24 characters
			/// </summary>
			public const string Password = "password";
			/// <summary>
			/// (optional) Trial subscription interval in days, weeks, months, years (example: a 4 day interval is “period1: 4 D”).
			/// </summary>
			public const string Trial1Period = "period1";
			/// <summary>
			/// (optional) Trial subscription interval in days, weeks, months, or years.
			/// </summary>
			public const string Trial2Period = "period2";
			/// <summary>
			/// Regular subscription interval in days, weeks, months, or years.
			/// </summary>
			public const string SubscriptionPeriod = "period3";
			/// <summary>
			/// Indicates whether reattempts should occur upon payment failures (1 is yes, blank is no).
			/// </summary>
			public const string ReattemptFailedPayments = "reattempt";
			/// <summary>
			/// The number of payment installments that will occur at the regular rate.
			/// </summary>
			public const string RecurranceCount = "recur_times";
			/// <summary>
			/// Indicates whether regular rate recurs (1 is yes, blank is no).
			/// </summary>
			public const string Recurring = "recurring";
			/// <summary>
			/// Date PayPal will retry a failed subscription payment.
			/// </summary>
			public const string RetryDate = "retry_at";
			/// <summary>
			/// Start date or cancellation date depending on whether transaction is subscr_signup or subscr_cancel. Time/Date stamp generated by PayPal, in the following format: HH:MM:SS DD Mmm YY, YYYY PST
			/// </summary>
			public const string SubscriptionDate = "subscr_date";
			/// <summary>
			/// Date when the subscription modification will be effective (only for txn_type = subscr_modify). Time/Date stamp generated by PayPal, in the following format: HH:MM:SS DD Mmm YY, YYYY PST
			/// </summary>
			public const string SubscriptionChangeEffectiveDate = "subscr_effective";
			/// <summary>
			/// ID generated by PayPal for the subscriber. Length: 19 characters
			/// </summary>
			public const string SubscriptionID = "subscr_id";
			/// <summary>
			/// (optional) Username generated by PayPal and given to subscriber to access the subscription. Length: 64 characters
			/// </summary>
			public const string Username = "username";
		}

		public static class PaymentInformation
		{
			/// <summary>
			/// Authorization amount
			/// </summary>
			public const string AuthorizationAmount = "auth_amount";
			/// <summary>
			/// Authorization expiration date and time, in the following format: HH:MM:SS DD Mmm YY, YYYY PST. Length: 28 characters
			/// </summary>
			public const string AuthorizationExpiryDate = "auth_exp";
			/// <summary>
			/// Authorization identification number. Length: 19 characters
			/// </summary>
			public const string AuthorizationID = "auth_id";
			/// <summary>
			/// Status of authorization
			/// </summary>
			public const string AuthorizationStatus = "auth_status";
			/// <summary>
			/// Exchange rate used if a currency conversion occurred.
			/// </summary>
			public const string ExchangeRate = "exchange_rate";
			/// <summary>
			/// <para>One or more filters that identify a triggering action associated with one of the following payment_status values: Pending, Completed, Denied, where x is a number starting with 1 that makes the IPN variable name unique; x is not the filter’s ID number. The filters and their ID numbers are as follows:</para>
			/// <para>1 = AVS No Match</para>
			/// <para>2 = AVS Partial Match</para>
			/// <para>3 = AVS Unavailable/Unsupported</para>
			/// <para>4 = Card Security Code (CSC) Mismatch</para>
			/// <para>5 = Maximum Transaction Amount</para>
			/// <para>6 = Unconfirmed Address</para>
			/// <para>7 = Country Monitor</para>
			/// <para>8 = Large Order Number</para>
			/// <para>9 = Billing/Shipping Address Mismatch</para>
			/// <para>10 = Risky ZIP Code</para>
			/// <para>11 = Suspected Freight Forwarder Check</para>
			/// <para>12 = Total Purchase Price Minimum</para>
			/// <para>13 = IP Address Velocity</para>
			/// <para>14 = Risky Email Address Domain Check</para>
			/// <para>15 = Risky Bank Identification Number (BIN) Check</para>
			/// <para>16 = Risky IP Address Range</para>
			/// <para>17 = PayPal Fraud Model</para>
			/// </summary>
			public const string FraudManagementPendingFilters = "fraud_managment_pending_filters_{0}";
			/// <summary>
			/// Passthrough variable you can use to identify your Invoice Number for this purchase. If omitted, no variable is passed back. Length: 127 characters
			/// </summary>
			public const string InvoiceNumber = "invoice";
			/// <summary>
			/// Item name as passed by you, the merchant. Or, if not passed by you, as entered by your customer. If this is a shopping cart transaction, PayPal will append the number of the item (e.g., item_name1, item_name2, and so forth). Length: 127 characters
			/// </summary>
			public const string CartItemName = "item_name{0}";
			/// <summary>
			/// Pass-through variable for you to track purchases. It will get passed back to you at the completion of the payment. If omitted, no variable will be passed back to you. If this is a shopping cart transaction, PayPal will append the number of the item (e.g., item_number1, item_number2, and so forth). Length: 127 characters
			/// </summary>
			public const string CartItemNumber = "item_number{0}";
			/// <summary>
			/// <para>• For payment IPN notifications, this is the currency of the payment.</para>
			/// <para>• For non-payment subscription IPN notifications (i.e., txn_type= signup, cancel, failed, eot, or modify), this is the currency of the subscription.</para>
			/// <para>• For payment subscription IPN notifications, it is the currency of the payment (i.e., txn_type = subscr_payment)</para>
			/// </summary>
			public const string Currency = "mc_currency";
			/// <summary>
			/// Transaction fee associated with the payment. mc_gross minus mc_fee equals the amount deposited into the receiver_email account. Equivalent to payment_fee for USD payments. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction fee.
			/// </summary>
			public const string TransactionFee = "mc_fee";
			/// <summary>
			/// Full amount of the customer's payment, before transaction fee is subtracted. Equivalent to payment_gross for USD payments. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction.
			/// </summary>
			public const string GrossAmount = "mc_gross";
			/// <summary>
			/// The amount is in the currency of mc_currency, where x is the shopping cart detail item number. The sum of mc_gross_ x should total mc_gross.
			/// </summary>
			public const string CartItemGrossAmount = "mc_gross{0}";
			/// <summary>
			/// Total handling amount associated with the transaction.
			/// </summary>
			public const string HandlingFee = "mc_handling";
			/// <summary>
			/// Total shipping amount associated with the transaction.
			/// </summary>
			public const string ShippingFee = "mc_shipping";
			/// <summary>
			/// This is the combined total of shipping1 and shipping2 Website Payments Standard variables, where x is the shopping cart detail item number. The shipping x variable is only shown when the merchant applies a shipping amount for a specific item. Because profile shipping might apply, the sum of shipping x might not be equal to shipping.
			/// </summary>
			public const string CartItemShippingFee = "mc_shipping{0}";
			/// <summary>
			/// Memo as entered by your customer in PayPal Website Payments note field. Length: 255 characters
			/// </summary>
			public const string CustomerNote = "memo";
			/// <summary>
			/// If this is a PayPal Shopping Cart transaction, number of items in cart.
			/// </summary>
			public const string CartItemsTotal = "num_cart_items";
			/// <summary>
			/// Option name as requested by you. PayPal appends the number of the item where x represents the number of the shopping cart detail item (e.g., option_name2, option_name2). Length: 64 characters
			/// </summary>
			public const string OptionName = "option_name{0}";
			/// <summary>
			/// Option choice as entered by your customer. PayPal appends the number of the item where x represents the number of the shopping cart detail item (e.g., option_selection1, option_selection2). Length: 200 characters
			/// </summary>
			public const string OptionValue = "option_selection{0}";
			/// <summary>
			/// <para>Whether the customer has a verified PayPal account.</para>
			/// <para>verified – Customer has a verified PayPal account.</para>
			/// <para>unverified – Customer has an unverified PayPal account.</para>
			/// </summary>
			public const string PayerStatus = "payer_status";
			/// <summary>
			/// Time/Date stamp generated by PayPal, in the following format: HH:MM:SS DD Mmm YY, YYYY PST. Length: 28 characters
			/// </summary>
			public const string PaymentDate = "payment_date";
			/// <summary>
			/// <para>The status of the payment:</para>
			/// <para>Canceled_Reversal: A reversal has been canceled. For example, you won a dispute with the customer, and the funds for the transaction that was reversed have been returned to you.</para>
			/// <para>Completed: The payment has been completed, and the funds have been added successfully to your account balance.</para>
			/// <para>Created: A German ELV payment is made using Express Checkout.</para>
			/// <para>Denied: You denied the payment. This happens only if the payment was previously pending because of possible reasons described for the pending_reason variable or the Fraud_Management_Filters_x variable.</para>
			/// <para>Expired: This authorization has expired and cannot be captured.</para>
			/// <para>Failed: The payment has failed. This happens only if the payment was made from your customer’s bank account.</para>
			/// <para>Pending: The payment is pending. See pending_reason for more information.</para>
			/// <para>Refunded: You refunded the payment.</para>
			/// <para>Reversed: A payment was reversed due to a chargeback or other type of reversal. The funds have been removed from your account balance and returned to the buyer. The reason for the reversal is specified in the ReasonCode element.</para>
			/// <para>Processed: A payment has been accepted.</para>
			/// <para>Voided: This authorization has been voided.</para>
			/// </summary>
			public const string PaymentStatus = "payment_status";
			/// <summary>
			/// <para>echeck: This payment was funded with an eCheck.</para>
			/// <para>instant: This payment was funded with PayPal balance, credit card, or Instant Transfer.</para>
			/// </summary>
			public const string PaymentType = "payment_type";
			/// <summary>
			/// <para>This variable is set only if payment_status = Pending.</para>
			/// <para>address: The payment is pending because your customer did not include a confirmed shipping address and your Payment Receiving Preferences is set yo allow you to manually accept or deny each of these payments. To change your preference, go to the Preferences section of your Profile.</para>
			/// <para>authorization: You set the payment action to Authorization and have not yet captured funds.</para>
			/// <para>echeck: The payment is pending because it was made by an eCheck that has not yet cleared.</para>
			/// <para>intl: The payment is pending because you hold a non-U.S. account and do not have a withdrawal mechanism. You must manually accept or deny this payment from your Account Overview.</para>
			/// <para>multi-currency: You do not have a balance in the currency sent, and you do not have your Payment Receiving Preferences set to automatically convert and accept this payment. You must manually accept or deny this payment.</para>
			/// <para>order: You set the payment action to Order and have not yet captured funds.</para>
			/// <para>paymentreview: The payment is pending while it is being reviewed by PayPal for risk.</para>
			/// <para>unilateral: The payment is pending because it was made to an email address that is not yet registered or confirmed.</para>
			/// <para>upgrade: The payment is pending because it was made via credit card and you must upgrade your account to Business or Premier status in order to receive the funds. upgrade can also mean that you have reached the monthly limit for transactions on your account.</para>
			/// <para>verify: The payment is pending because you are not yet verified. You must verify your account before you can accept this payment.</para>
			/// <para>other: The payment is pending for a reason other than those listed above. For more information, contact PayPal Customer Service.</para>
			/// </summary>
			public const string PendingReason = "pending_reason";
			/// <summary>
			/// <para>ExpandedSellerProtection: Seller is protected by Expanded seller protection</para>
			/// <para>SellerProtection: Seller is protected by PayPal’s Seller Protection Policy</para>
			/// <para>None: Seller is not protected under Expanded seller protection nor the Seller Protection Policy</para>
			/// </summary>
			public const string ProtectionEligibility = "protection_eligibility";
			/// <summary>
			/// Quantity as entered by your customer or as passed by you, the merchant. If this is a shopping cart transaction, PayPal appends the number of the item (e.g. quantity1, quantity2).
			/// </summary>
			public const string Quantity = "quantity";
			/// <summary>
			/// <para>This variable is set if payment_status =Reversed, Refunded, or Canceled_Reversal.</para>
			/// <para>adjustment_reversal: Reversal of an adjustment</para>
			/// <para>buyer-complaint: A reversal has occurred on this transaction due to a complaint about the transaction from your customer.</para>
			/// <para>chargeback: A reversal has occurred on this transaction due to a chargeback by your customer.</para>
			/// <para>chargeback_reimbursement: Reimbursement for a chargeback</para>
			/// <para>chargeback_settlement: Settlement of a chargeback</para>
			/// <para>guarantee: A reversal has occurred on this transaction due to your customer triggering a money-back guarantee.</para>
			/// <para>other: Non-specified reason.</para>
			/// <para>refund: A reversal has occurred on this transaction because you have given the customer a refund.</para>
			/// <para>NOTE:Additional codes may be returned.</para>
			/// </summary>
			public const string ReasonCode = "reason_code";
			/// <summary>
			/// Remaining amount that can be captured with Authorization and Capture
			/// </summary>
			public const string AuthorizationAmountRemaining = "remaining_settle";
			/// <summary>
			/// Amount that is deposited into the account’s primary balance after a currency conversion from automatic conversion (through your Payment Receiving Preferences) or manual conversion (through manually accepting a payment).
			/// </summary>
			public const string ConvertedAmount = "settle_amount";
			/// <summary>
			/// Currency of settle_amount.
			/// </summary>
			public const string AuthorizationAmountRemainingCurrency = "settle_currency";
			/// <summary>
			/// The name of a shipping method from the Shipping Calculations section of the merchant's account profile. The buyer selected the named shipping method for this transaction.
			/// </summary>
			public const string ShippingMethod = "shipping_method";
			/// <summary>
			/// Amount of tax charged on payment. PayPal appends the number of the item (e.g., item_name1, item_name2). The tax x variable is included only if there was a specific tax amount applied to a particular shopping cart item. Because total tax may apply to other items in the cart, the sum of tax x might not total to tax.
			/// </summary>
			public const string TaxAmount = "tax";
			/// <summary>
			/// Amount of tax charged on payment. PayPal appends the number of the item (e.g., item_name1, item_name2). The tax x variable is included only if there was a specific tax amount applied to a particular shopping cart item. Because total tax may apply to other items in the cart, the sum of tax x might not total to tax.
			/// </summary>
			public const string CartItemTaxAmount = "tax{0}";
			/// <summary>
			/// Authorization and Capture transaction entity
			/// </summary>
			public const string TransactionEntity = "transaction_entity";
		}
    
        public const string CustomValue = "custom";
    }
}