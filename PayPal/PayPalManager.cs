using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;


namespace XMerchant.PayPal
{
	public static class PayPalManager
	{
		public static bool AuthenticateIPN(IPayPalTransaction transaction, NameValueCollection form)
		{
			var url = transaction.IsTest ? PayPalURL.Sandbox : PayPalURL.Production;
			string data = string.Concat(PayPalRequestVariables.Command, "=", EnumToVar(PayPalCommand.ValidateIPN), "&", form.ToQueryString());
			return new WebClient().UploadString(url, data).Trim() == "VERIFIED";
		}

		public static PayPalTransactionType GetTransactionType(string txn_type)
		{
			return VarToEnum<PayPalTransactionType>(txn_type);
		}

		public static IPayPalTransaction CreateTransactionFrom(NameValueCollection form)
		{
			var transType = GetTransactionType(form[PayPalResponseVariables.TransactionInformation.TransactionType]);

			IPayPalTransaction trans = new PayPalTransaction();
			trans.RecipientAccount = form[PayPalResponseVariables.TransactionInformation.RecipientAccount];
			trans.CharacterSet = form[PayPalResponseVariables.TransactionInformation.CharacterSet];
			trans.CustomReference = form[PayPalResponseVariables.TransactionInformation.CustomReference];
			trans.NotificationVersion = form[PayPalResponseVariables.TransactionInformation.NotificationVersion];
			trans.ParentTransactionID = form[PayPalResponseVariables.TransactionInformation.ParentTransactionID];
			trans.GuestReceiptID = form[PayPalResponseVariables.TransactionInformation.GuestReceiptID];
			trans.RecipientAccountEmail = form[PayPalResponseVariables.TransactionInformation.RecipientAccountEmail];
			trans.RecipientAccountID = form[PayPalResponseVariables.TransactionInformation.RecipientAccountID];
			trans.Resent = form[PayPalResponseVariables.TransactionInformation.Resent] == "true";
			trans.CountryCode = form[PayPalResponseVariables.TransactionInformation.CountryCode];
			trans.IsTest = form[PayPalResponseVariables.TransactionInformation.IsTest] == "1";
			trans.TransactionID = form[PayPalResponseVariables.TransactionInformation.TransactionID];
			trans.TransactionType = transType;
			trans.RecipientAccountID = form[PayPalResponseVariables.TransactionInformation.RecipientAccountID];

			switch(trans.TransactionType)
			{
				case PayPalTransactionType.WebAccept:
					break;

				case PayPalTransactionType.WebsitePaymentsProFee:
					break;
			}

			return trans;
		}

		public static void Encrypt()
		{
		}

		public static PayPalCaseType GetCaseType(string case_type)
		{
			return VarToEnum<PayPalCaseType>(case_type);
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

		public static string ValueOf(PayPalReturnURLMethod method)
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
