using System;

namespace XMerchant.PayPal
{
	/// <summary>
	/// Use this class to manually specify all the standard values used when generating PayPal forms and links. To specify all of these in
	/// your application configuration file, use <see cref="PayPalConfigSettings" /> instead.
	/// </summary>
	public class PayPalCustomSettings : IPayPalSettings
	{
		/// <summary>
		/// The PayPal seller account (usually an email address)
		/// </summary>
		public string Account { get; set; }

		/// <summary>
		/// Specifies whether to use the PayPal production environment or the PayPal developer sandbox
		/// </summary>
		public bool TestMode { get; set; }

		/// <summary>
		/// Specifies that the payment form variables should be encrypted before being written to a page
		/// </summary>
		public bool Encrypt { get; set; }

		/// <summary>
		/// The path to the PayPal public certificate that is downloaded from the PayPal website for use with Encrypted Website Payments (EWP)
		/// </summary>
		public string RecipientPublicCertPath { get; set; }

		/// <summary>
		/// The path to the website's public certificate for signing Encrypted Website Payments (EWP) forms
		/// </summary>
		public string SignerPfxPath { get; set; }

		/// <summary>
		/// The password that is used for signing Encrypted Website Payments (EWP) values (see <see cref="IPayPalSettings.SignerPfxPath" />)
		/// </summary>
		public string SignerPfxPassword { get; set; }

		/// <summary>
		/// The ID of the PayPal certificate after it has been uploaded to PayPal in the account profile area
		/// </summary>
		public string CertID { get; set; }

		/// <summary>
		/// The web address that should be redirected to after a user has made a successful PayPal payment
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		/// The web address that will handle PayPal IPN notifications
		/// </summary>
		public string NotifyUrl { get; set; }

		/// <summary>
		/// The web address that should be redirected to if a user cancels the payment process whilst on PayPal's payment pages
		/// </summary>
		public string CancelUrl { get; set; }

		/// <summary>
		/// The web address of a custom logo that can be displayed on PayPal's payment pages
		/// </summary>
		public string LogoUrl { get; set; }
	}
}