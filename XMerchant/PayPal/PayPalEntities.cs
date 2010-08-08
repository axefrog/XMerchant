using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMerchant.PayPal
{
	public interface IPayPalCustomerDetails
	{
		/// <summary>
		/// <para>City of customer’s address</para>
		/// <para>Length: 40 characters</para>
		/// </summary>
		string Country { get; set; }
		string City { get; set; }
		string CountryCode { get; set; }
	}

	public interface IPayPalTransaction
	{
		/// <summary>
		/// The PayPal account login or email address that the payment has been sent to. Note that this can be a subaccount of another PayPal account.
		/// See <see cref="RecipientAccount" /> for the primary account holder email.
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.RecipientAccount)]
		string RecipientAccount { get; set; }

		/// <summary>
		/// The primary PayPal account holder receiving the payment/transaction notification. The primary account holder email address is specified
		/// even if the payment was targeted at a subaccount of the primary PayPal account.
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.RecipientAccountEmail)]
		string RecipientAccountEmail { get; set; }

		[PayPalVariable(PayPalResponseVariables.TransactionInformation.CharacterSet)]
		string CharacterSet { get; set; }

		/// <summary>
		/// A custom value passed to PayPal by this application when the transaction was initiated.
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.CustomReference)]
		string CustomReference { get; set; }

		/// <summary>
		/// Represents the version of the notification message sent by PayPal. Expected to change only when PayPal implements new features that
		/// affect their IPN system.
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.NotificationVersion)]
		string NotificationVersion { get; set; }

		/// <summary>
		/// In the case of a refund, reversal or canceled reversal, this contains the <see cref="TransactionID" /> of the original
		/// transaction, while <see cref="TransactionID" /> contains a new ID for the new transaction.
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.ParentTransactionID)]
		string ParentTransactionID { get; set; }

		/// <summary>
		/// A unique ID generated during guest checkout (payment by credit card without logging in)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.GuestReceiptID)]
		string GuestReceiptID { get; set; }

		/// <summary>
		/// Specifies whether or not this transaction was a resend of an earlier failed IPN notification
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.Resent)]
		bool Resent { get; set; }

		/// <summary>
		/// Unique account ID of the payment recipient (i.e. the merchant)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.RecipientAccountID)]
		string RecipientAccountID { get; set; }

		/// <summary>
		/// The ISO 3166 country code associated with the country of residence of the person who initiated this transaction
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.CountryCode)]
		string CountryCode { get; set; }

		/// <summary>
		/// Specifies whether this transaction came from the PayPal Developer Sandbox
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.IsTest)]
		bool IsTest { get; set; }

		/// <summary>
		/// The unique ID for this transaction
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.TransactionID)]
		string TransactionID { get; set; }

		/// <summary>
		/// The type of the transaction
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.TransactionType)]
		PayPalTransactionType TransactionType { get; set; }

		/// <summary>
		/// An encrypted string used to validate the authenticity of the transaction during IPN authentication
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.TransactionInformation.Signature)]
		string Signature { get; set; }
	}

	public interface IPayPalBuyerInformation
	{
		/// <summary>
		/// Country of customer's address (Length: 64 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.Country)]
		string Country { get; set; }
		/// <summary>
		/// City of customer's address (Length: 40 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.City)]
		string City { get; set; }
		/// <summary>
		/// ISO 3166 country code associated with customer's address (Length: 2 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.CountryCode)]
		string CountryCode { get; set; }
		/// <summary>
		/// Name used with address - included when the customer provides a Gift Address (Length: 128 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.RecipientName)]
		string RecipientName { get; set; }
		/// <summary>
		/// State of customer’s address (Length: 40 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.State)]
		string State { get; set; }
		/// <summary>
		/// Whether the customer provided a confirmed address
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.Status)]
		PayPalAddressStatus Status { get; set; }
		/// <summary>
		/// Customer's street address. (Length: 200 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.Street)]
		string Street { get; set; }
		/// <summary>
		/// Zip or postal code code of customer’s address. (Length: 20 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.PostalCode)]
		string PostalCode { get; set; }
		/// <summary>
		/// Customer’s telephone number. (Length: 20 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.Phone)]
		string Phone { get; set; }
		/// <summary>
		/// Customer’s first name (Length: 64 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.FirstName)]
		string FirstName { get; set; }
		/// <summary>
		/// Customer’s last name (Length: 64 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.LastName)]
		string LastName { get; set; }
		/// <summary>
		/// Customer’s company name, if customer is a business (Length: 127 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.BusinessName)]
		string BusinessName { get; set; }
		/// <summary>
		/// Customer’s primary email address. Use this email to provide any credits. (Length: 127 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.Email)]
		string Email { get; set; }
		/// <summary>
		/// Unique customer ID. (Length: 13 characters)
		/// </summary>
		[PayPalVariable(PayPalResponseVariables.BuyerInformation.PayerID)]
		string PayerID { get; set; }
	}

	public class PayPalTransaction : IPayPalTransaction
	{
		public string RecipientAccount { get; set; }
		public string RecipientAccountEmail { get; set; }
		public string CharacterSet { get; set; }
		public string CustomReference { get; set; }
		public string NotificationVersion { get; set; }
		public string ParentTransactionID { get; set; }
		public string GuestReceiptID { get; set; }
		public bool Resent { get; set; }
		public string RecipientAccountID { get; set; }
		public string CountryCode { get; set; }
		public bool IsTest { get; set; }
		public string TransactionID { get; set; }
		public PayPalTransactionType TransactionType { get; set; }
		public string Signature { get; set; }
	}

	public class PayPalBuyerInformation : IPayPalBuyerInformation
	{
		public string Country { get; set; }
		public string City { get; set; }
		public string CountryCode { get; set; }
		public string RecipientName { get; set; }
		public string State { get; set; }
		public PayPalAddressStatus Status { get; set; }
		public string Street { get; set; }
		public string PostalCode { get; set; }
		public string Phone { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BusinessName { get; set; }
		public string Email { get; set; }
		public string PayerID { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class PayPalVariableAttribute : Attribute
	{
		public string Name { get; set; }

		public PayPalVariableAttribute(string variableName)
		{
			Name = variableName;
		}
	}
}
