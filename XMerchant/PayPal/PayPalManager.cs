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
			trans.RecipientAccount      = form[PayPalResponseVariables.TransactionInformation.RecipientAccount];
			trans.RecipientAccountEmail = form[PayPalResponseVariables.TransactionInformation.RecipientAccountEmail];
			trans.RecipientAccountID    = form[PayPalResponseVariables.TransactionInformation.RecipientAccountID];
			trans.CharacterSet          = form[PayPalResponseVariables.TransactionInformation.CharacterSet];
			trans.CustomReference       = form[PayPalResponseVariables.TransactionInformation.CustomReference];
			trans.NotificationVersion   = form[PayPalResponseVariables.TransactionInformation.NotificationVersion];
			trans.ParentTransactionID   = form[PayPalResponseVariables.TransactionInformation.ParentTransactionID];
			trans.GuestReceiptID        = form[PayPalResponseVariables.TransactionInformation.GuestReceiptID];
			trans.Resent                = form[PayPalResponseVariables.TransactionInformation.Resent] == "true";
			trans.PurchaseCountryCode   = form[PayPalResponseVariables.TransactionInformation.CountryCode];
			trans.IsTest                = form[PayPalResponseVariables.TransactionInformation.IsTest] == "1";
			trans.TransactionID         = form[PayPalResponseVariables.TransactionInformation.TransactionID];
			trans.TransactionType       = GetTransactionType(form[PayPalResponseVariables.TransactionInformation.TransactionType]);
			trans.Signature             = form[PayPalResponseVariables.TransactionInformation.Signature];

			// Buyer Information
			trans.Country       = form[PayPalResponseVariables.BuyerInformation.Country];
			trans.City          = form[PayPalResponseVariables.BuyerInformation.City];
			trans.CountryCode   = form[PayPalResponseVariables.BuyerInformation.CountryCode];
			trans.RecipientName = form[PayPalResponseVariables.BuyerInformation.RecipientName];
			trans.State         = form[PayPalResponseVariables.BuyerInformation.State];
			trans.Status        = form[PayPalResponseVariables.BuyerInformation.Status] == null ? (PayPalAddressStatus?)null : GetAddressStatus(form[PayPalResponseVariables.BuyerInformation.Status]);
			trans.Street        = form[PayPalResponseVariables.BuyerInformation.Street];
			trans.PostalCode    = form[PayPalResponseVariables.BuyerInformation.PostalCode];
			trans.Phone         = form[PayPalResponseVariables.BuyerInformation.Phone];
			trans.FirstName     = form[PayPalResponseVariables.BuyerInformation.FirstName];
			trans.LastName      = form[PayPalResponseVariables.BuyerInformation.LastName];
			trans.BusinessName  = form[PayPalResponseVariables.BuyerInformation.BusinessName];
			trans.Email         = form[PayPalResponseVariables.BuyerInformation.Email];
			trans.PayerID       = form[PayPalResponseVariables.BuyerInformation.PayerID];

			// Subscription Information
			int n; DateTime dt;
			trans.TrialPeriod1                    = GetPeriod(form, PayPalResponseVariables.SubscriptionInformation.Trial1Amount, PayPalResponseVariables.SubscriptionInformation.Trial1Period);
			trans.TrialPeriod2                    = GetPeriod(form, PayPalResponseVariables.SubscriptionInformation.Trial2Amount, PayPalResponseVariables.SubscriptionInformation.Trial2Period);
			trans.SubscriptionPeriod              = GetPeriod(form, PayPalResponseVariables.SubscriptionInformation.SubscriptionAmount, PayPalResponseVariables.SubscriptionInformation.SubscriptionPeriod);
			trans.GeneratedPassword               = form[PayPalResponseVariables.SubscriptionInformation.Password];
			trans.GeneratedUsername               = form[PayPalResponseVariables.SubscriptionInformation.Username];
			trans.FailedPaymentsWillBeReattempted = form[PayPalResponseVariables.SubscriptionInformation.ReattemptFailedPayments] == "1";
			trans.RecurranceCount                 = int.TryParse(form[PayPalResponseVariables.SubscriptionInformation.RecurranceCount], out n) ? (int?)n : null;
			trans.IsRecurring                     = form[PayPalResponseVariables.SubscriptionInformation.Recurring] == "1";
			trans.NextRetryDate                   = DateTime.TryParse(form[PayPalResponseVariables.SubscriptionInformation.Password], out dt) ? (DateTime?)dt : null;
			trans.SubscriptionDate                = DateTime.TryParse(form[PayPalResponseVariables.SubscriptionInformation.SubscriptionDate], out dt) ? (DateTime?)dt : null;
			trans.SubscriptionChangeEffectiveDate = DateTime.TryParse(form[PayPalResponseVariables.SubscriptionInformation.SubscriptionChangeEffectiveDate], out dt) ? (DateTime?)dt : null;
			trans.SubscriptionID                  = form[PayPalResponseVariables.SubscriptionInformation.SubscriptionID];

			double d;
			trans.GrossAmount    = double.TryParse(form[PayPalResponseVariables.PaymentInformation.GrossAmount], out d) ? (double?)d : null;
			trans.TransactionFee = double.TryParse(form[PayPalResponseVariables.PaymentInformation.TransactionFee], out d) ? (double?)d : null;
			trans.PaymentStatus  = form[PayPalResponseVariables.PaymentInformation.PaymentStatus] == null ? null : (PayPalPaymentStatus?)GetPaymentStatus(form[PayPalResponseVariables.PaymentInformation.PaymentStatus]);
			trans.ReasonCode     = form[PayPalResponseVariables.PaymentInformation.ReasonCode] == null ? null : (PayPalReasonCode?)GetReasonCode(form[PayPalResponseVariables.PaymentInformation.ReasonCode]);

			// PayPal doesn't seem to send a txn_type variable when there's a refund
			if(trans.TransactionType == PayPalTransactionType.Unknown)
			{
				if(trans.PaymentStatus == PayPalPaymentStatus.Refunded)
					trans.TransactionType = PayPalTransactionType.Refund;
			}

			return trans;
		}
		private static PayPalTransaction.Period GetPeriod(NameValueCollection form, string amountVar, string periodVar)
		{
			if(string.IsNullOrWhiteSpace(form[amountVar]) || string.IsNullOrWhiteSpace(form[periodVar])) return null;
			var period = GetPeriod(form[periodVar]);
			return new PayPalTransaction.Period
			{
				Amount = double.Parse(form[amountVar]),
				Length = period.Item1,
				Unit = period.Item2
			};
		}
		private static Tuple<int, PayPalSubscriptionPeriodUnit> GetPeriod(string period)
		{
			var arr = period.Split(' ');
			return new Tuple<int, PayPalSubscriptionPeriodUnit>(int.Parse(arr[0]), GetSubscriptionPeriodUnit(arr[1]));
		}

		public static bool AuthenticateIPN(NameValueCollection form)
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

		public static PayPalSubscriptionPeriodUnit GetSubscriptionPeriodUnit(string period)
		{
			return VarToEnum<PayPalSubscriptionPeriodUnit>(period);
		}

		public static PayPalReasonCode GetReasonCode(string reason_code)
		{
			return VarToEnum<PayPalReasonCode>(reason_code);
		}

		public static PayPalPaymentStatus GetPaymentStatus(string payment_status)
		{
			return VarToEnum<PayPalPaymentStatus>(payment_status);
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

		public static string ValueOf(PayPalWeightUnit weightUnit)
		{
			return EnumToVar(weightUnit);
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
