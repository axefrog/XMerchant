using System;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace XMerchant.PayPal
{
	/// <summary>
	/// http://forums.asp.net/t/1236969.aspx
	/// </summary>
	public class PayPalEncryptedWebsitePayments
	{
		private Encoding _encoding = Encoding.Default;
		private string _recipientPublicCertPath;
		private X509Certificate2 _signerCert;

		private X509Certificate2 _recipientCert;
		public PayPalEncryptedWebsitePayments()
		{
		}

		#region "Properties"
		/// <summary>
		/// Character encoding, e.g. UTF-8, Windows-1252
		/// </summary>

		public string Charset {
			get { return _encoding.WebName; }
			set {
				if (value != null && !string.IsNullOrEmpty(value)) {
					_encoding = Encoding.GetEncoding(value);
				}
			}
		}

		/// <summary>
		/// Path to the recipient's public certificate in PEM format
		/// </summary>

		public string RecipientPublicCertPath {
			get { return _recipientPublicCertPath; }
			set {
				_recipientPublicCertPath = value;
				_recipientCert = new X509Certificate2(_recipientPublicCertPath);
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="signerPfxCertPath">File path to the signer's public certificate plus private key in PKCS#12 format</param>
		/// <param name="signerPfxCertPassword">Password for signer's private key</param>

		public void LoadSignerCredential(string signerPfxCertPath, string signerPfxCertPassword)
		{
			try {
				_signerCert = new X509Certificate2(File.ReadAllBytes(signerPfxCertPath), signerPfxCertPassword, X509KeyStorageFlags.MachineKeySet);
			} catch (Exception ex) {
				throw new Exception("Signer Cert Path: " + signerPfxCertPath + "\r\n" + ex);
			}
		}

		/// <summary>
		/// Sign a message and encrypt it for the recipient.
		/// </summary>
		/// <param name="clearText">Name value pairs must be separated by \n (vbLf or Chr(10)), for example "cmd=_xclick\nbusiness=..."</param>
		/// <returns></returns>

		public string SignAndEncrypt(string clearText)
		{
			string result = null;
			byte[] messageBytes = _encoding.GetBytes(clearText);
			byte[] signedBytes = Sign(messageBytes);
			byte[] encryptedBytes = Envelope(signedBytes);
			result = Base64Encode(encryptedBytes);
			return result;
		}

		private byte[] Sign(byte[] messageBytes)
		{
			ContentInfo content = new ContentInfo(messageBytes);
			SignedCms signed = new SignedCms(content);
			CmsSigner signer = new CmsSigner(_signerCert);
			signed.ComputeSignature(signer);
			byte[] signedBytes = signed.Encode();
			return signedBytes;
		}

		private byte[] Envelope(byte[] contentBytes)
		{
			ContentInfo content = new ContentInfo(contentBytes);
			EnvelopedCms envMsg = new EnvelopedCms(content);
			CmsRecipient recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, _recipientCert);
			envMsg.Encrypt(recipient);
			byte[] encryptedBytes = envMsg.Encode();
			return encryptedBytes;
		}

		private string Base64Encode(byte[] encoded)
		{
			const string PKCS7_HEADER = "-----BEGIN PKCS7-----";
			const string PKCS7_FOOTER = "-----END PKCS7-----";
			string base64 = Convert.ToBase64String(encoded);
			StringBuilder formatted = new StringBuilder();
			formatted.Append(PKCS7_HEADER);
			formatted.Append(base64);
			formatted.Append(PKCS7_FOOTER);
			return formatted.ToString();
		}

		public static NameValueCollection Encrypt(NameValueCollection vars, IPayPalSettings settings)
		{
			var sb = new StringBuilder();
			foreach(var key in vars.AllKeys)
				sb.Append(key).Append("=").AppendLine(vars[key]);
			sb.Append("cert_id=").AppendLine(settings.CertID);
			var ewp = new PayPalEncryptedWebsitePayments();
			ewp.LoadSignerCredential(settings.SignerPfxPath, settings.SignerPfxPassword);
			ewp.RecipientPublicCertPath = settings.RecipientPublicCertPath;
			return new NameValueCollection
			{
				{ PayPalRequestVariables.Command, PayPalManager.ValueOf(PayPalCommand.EncryptedCommand) },
				{ PayPalRequestVariables.EncryptedData, ewp.SignAndEncrypt(sb.ToString()) }
			};
		}
	}
}