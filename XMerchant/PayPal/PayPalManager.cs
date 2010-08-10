using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;


namespace XMerchant.PayPal
{
	public static class PayPalManager
	{
		public static PayPalTransaction CreateTransactionFrom(NameValueCollection form)
		{
			PayPalTransaction trans = new PayPalTransaction();

			// Transaction Information
			trans.RecipientAccount = form[PayPalResponseVariables.TransactionInformation.RecipientAccount];
			trans.RecipientAccountEmail = form[PayPalResponseVariables.TransactionInformation.RecipientAccountEmail];
			trans.RecipientAccountID = form[PayPalResponseVariables.TransactionInformation.RecipientAccountID];
			trans.CharacterSet = form[PayPalResponseVariables.TransactionInformation.CharacterSet];
			trans.CustomReference = form[PayPalResponseVariables.TransactionInformation.CustomReference];
			trans.NotificationVersion = form[PayPalResponseVariables.TransactionInformation.NotificationVersion];
			trans.ParentTransactionID = form[PayPalResponseVariables.TransactionInformation.ParentTransactionID];
			trans.GuestReceiptID = form[PayPalResponseVariables.TransactionInformation.GuestReceiptID];
			trans.Resent = form[PayPalResponseVariables.TransactionInformation.Resent] == "true";
			trans.PurchaseCountryCode = form[PayPalResponseVariables.TransactionInformation.CountryCode];
			trans.IsTest = form[PayPalResponseVariables.TransactionInformation.IsTest] == "1";
			trans.TransactionID = form[PayPalResponseVariables.TransactionInformation.TransactionID];
			trans.TransactionType = GetTransactionType(form[PayPalResponseVariables.TransactionInformation.TransactionType]);
			trans.Signature = form[PayPalResponseVariables.TransactionInformation.Signature];

			// Buyer Information
			trans.Country = form[PayPalResponseVariables.BuyerInformation.Country];
			trans.City = form[PayPalResponseVariables.BuyerInformation.City];
			trans.CountryCode = form[PayPalResponseVariables.BuyerInformation.CountryCode];
			trans.RecipientName = form[PayPalResponseVariables.BuyerInformation.RecipientName];
			trans.State = form[PayPalResponseVariables.BuyerInformation.State];
			trans.Status = GetAddressStatus(form[PayPalResponseVariables.BuyerInformation.Status]);
			trans.Street = form[PayPalResponseVariables.BuyerInformation.Street];
			trans.PostalCode = form[PayPalResponseVariables.BuyerInformation.PostalCode];
			trans.Phone = form[PayPalResponseVariables.BuyerInformation.Phone];
			trans.FirstName = form[PayPalResponseVariables.BuyerInformation.FirstName];
			trans.LastName = form[PayPalResponseVariables.BuyerInformation.LastName];
			trans.BusinessName = form[PayPalResponseVariables.BuyerInformation.BusinessName];
			trans.Email = form[PayPalResponseVariables.BuyerInformation.Email];
			trans.PayerID = form[PayPalResponseVariables.BuyerInformation.PayerID];

			// Subscription Information


			return trans;
		}

		internal static bool AuthenticateIPN(NameValueCollection form)
		{
			var url = form[PayPalResponseVariables.TransactionInformation.IsTest] == "1" ? PayPalUrl.Sandbox : PayPalUrl.Production;
			string data = string.Concat(PayPalRequestVariables.Command, "=", EnumToVar(PayPalCommand.ValidateIPN), "&", form.ToQueryString());
			return new WebClient().UploadString(url, data).Trim() == "VERIFIED";
		}

		public static Uri GetSubscriptionCancelUrl(bool testMode, string paypalMerchantEmail)
		{
			return new Uri(testMode ? PayPalUrl.Sandbox : PayPalUrl.Production + "?cmd=_subscr-find&alias=" + paypalMerchantEmail);
		}

		public static PayPalTransactionType GetTransactionType(string txn_type)
		{
			return VarToEnum<PayPalTransactionType>(txn_type);
		}

		public static PayPalCaseType GetCaseType(string case_type)
		{
			return VarToEnum<PayPalCaseType>(case_type);
		}

		public static PayPalAddressStatus GetAddressStatus(string address_status)
		{
			return VarToEnum<PayPalAddressStatus>(address_status);
		}

		public static string ValueOf(PayPalCommand cmd)
		{
			return EnumToVar(cmd);
		}

		public static string ValueOf(PayPalSubscriptionPeriodUnit unit)
		{
			return EnumToVar(unit);
		}

		public static string ValueOf(PayPalSubscriptionEditMode type)
		{
			return EnumToVar(type);
		}

		public static string ValueOf(PayPalReturnUrlMethod method)
		{
			return EnumToVar(method);
		}

		public static string ValueOf(PayPalShippingMode mode)
		{
			return EnumToVar(mode);
		}

		public static string ValueOf(PayPalSubscriptionRecurrance recur)
		{
			return EnumToVar(recur);
		}

		public static string ValueOf(PayPalFailedPaymentReattempt reattempt)
		{
			return EnumToVar(reattempt);
		}

		public static string ValueOf(PayPalUserPaymentNote note)
		{
			return EnumToVar(note);
		}

		#region Internal Helper Methods
		static T VarToEnum<T>(string val) where T : struct, IConvertible
		{
			var type = typeof(T);
			if(!type.IsEnum)
				throw new ArgumentException("An Enum type is required for T");
			object returnVal = null;
			foreach(var member in type.GetMembers())
			{
				var attr = member.GetCustomAttributes(typeof(PayPalValueAttribute), false).FirstOrDefault() as PayPalValueAttribute;
				if(attr != null)
				{
					if(attr.Value == val)
						return (T)Enum.Parse(type, member.Name);
				}
				else if(returnVal == null && member.GetCustomAttributes(typeof(PayPalUnknownValueAttribute), false).FirstOrDefault() != null)
					returnVal = (T)Enum.Parse(type, member.Name);
			}
			if(returnVal != null)
				return (T)returnVal;
			throw new ArgumentOutOfRangeException("val");
		}
		static string EnumToVar<T>(T val) where T : struct, IConvertible
		{
			var type = typeof(T);
			if(!type.IsEnum)
				throw new ArgumentException("An Enum type is required for T");
			var member = type.GetMember(val.ToString()).FirstOrDefault();
			if(member != null)
			{
				var attr = member.GetCustomAttributes(typeof(PayPalValueAttribute), false).FirstOrDefault() as PayPalValueAttribute;
				if(attr != null)
					return attr.Value;
			}
			throw new InvalidEnumArgumentException("val");
		}
		#endregion
	}
}
