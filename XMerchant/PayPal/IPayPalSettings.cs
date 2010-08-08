namespace XMerchant.PayPal
{
	public interface IPayPalSettings
	{
		/// <summary>
		/// The PayPal seller account (usually an email address)
		/// </summary>
		string Account { get; }
		/// <summary>
		/// Specifies whether to use the PayPal production environment or the PayPal developer sandbox
		/// </summary>
		bool TestMode { get; }
		/// <summary>
		/// The path to the PayPal public certificate that is downloaded from the PayPal website for use with Encrypted Website Payments (EWP)
		/// </summary>
		string RecipientPublicCertPath { get; }
		/// <summary>
		/// The path to the website's public certificate for signing Encrypted Website Payments (EWP) forms
		/// </summary>
		string SignerPfxPath { get; }
		/// <summary>
		/// The password that is used for signing Encrypted Website Payments (EWP) values (see <see cref="SignerPfxPath" />)
		/// </summary>
		string SignerPfxPassword { get; }
		/// <summary>
		/// The ID of the PayPal certificate after it has been uploaded to PayPal in the account profile area
		/// </summary>
		string CertID { get; }
		/// <summary>
		/// The web address that should be redirected to after a user has made a successful PayPal payment
		/// </summary>
		string ReturnUrl { get; }
		/// <summary>
		/// The web address that will handle PayPal IPN notifications
		/// </summary>
		string NotifyUrl { get; }
		/// <summary>
		/// The web address that should be redirected to if a user cancels the payment process whilst on PayPal's payment pages
		/// </summary>
		string CancelUrl { get; }
		/// <summary>
		/// The web address of a custom logo that can be displayed on PayPal's payment pages
		/// </summary>
		string LogoUrl { get; }
	}
}