using System;
using System.Collections.Specialized;

namespace XMerchant.PayPal
{
    public class PaypalBuyNowRequest
    {
        private readonly IPayPalSettings _settings;

        public PaypalBuyNowRequest()
        {
        }

        public PaypalBuyNowRequest(IPayPalSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// An optional override value for the NotifyUrl property in your PayPal settings object
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// An optional override value for the ReturnUrl property in your PayPal settings object
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// An optional override value for the CancelUrl property in your PayPal settings object
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// The price or amount of the product, service, or contribution, not including shipping, handling, or tax. If omitted from Buy Now or Donate buttons, payers enter their own amount at the time of payment.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Discount amount associated with an item. It must be less than the selling price of the item. If you specify discount_amount and discount_amount2 is not defined, then this flat amount is applied regardless of the quantity of items purchased.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Discount amount associated with each additional quantity of the item. It must be equal to or less than the selling price of the item. A discount_amount must also be specified as greater than or equal to 0 for discount_amount2 to take effect.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? DiscountAmount2 { get; set; }

        /// <summary>
        /// Discount rate (percentage) associated with an item. It must be set to a value less than 100. If you do not set discount_rate2, the value in discount_rate applies only to the first item regardless of the quantity of items purchased.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? DiscountRate { get; set; }

        /// <summary>
        /// Discount rate (percentage) associated with each additional quantity of the item. It must be equal to or less 100. A discount_rate must also be specified as greater than or equal to 0 for discount_rate2 to take effect.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? DiscountRate2 { get; set; }

        /// <summary>
        /// Number of additional quantities of the item to which the discount applies. Applicable when you use discount_amount2 or discount_rate2. Use this variable to specify an upper limit on the number of discounted items.
        /// </summary>
        /// <remarks>Optional</remarks>
        public int? DiscountNum { get; set; }

        /// <summary>
        /// Description of item. If omitted, payers enter their own name at the time of payment.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string ItemName { get; set; }

        /// <summary>
        /// Pass-through variable for you to track product or service purchased or the contribution made. The value you specify passed back to you upon payment completion.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string ItemNumber { get; set; }

        /// <summary>
        /// Number of items. If profile-based shipping rates are configured with a basis of quantity, the sum of quantity values is used to calculate the shipping charges for the transaction. PayPal appends a sequence number to uniquely identify the item in the PayPal Shopping Cart (e.g., quantity1, quantity2)
        /// </summary>
        /// <remarks>Optional</remarks>
        public int? Quantity { get; set; }

        /// <summary>
        /// The cost of shipping this item. If you specify shipping and shipping2 is not defined, this flat amount is charged regardless of the quantity of items purchased.
        /// Default – If profile-based shipping rates are configured, buyers are charged an amount according to the shipping methods they choose.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? Shipping { get; set; }

        /// <summary>
        /// The cost of shipping each additional unit of this item. If omitted and profile-based shipping rates are configured, buyers are charged an amount according to the shipping methods they choose.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? Shipping2 { get; set; }

        /// <summary>
        /// Transaction-based tax override variable. Set this to a flat tax amount to apply to the transaction regardless of the buyer’s location. This value overrides any tax settings set in your account profile.
        /// Default – Profile tax settings, if any, apply.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? Tax { get; set; }

        /// <summary>
        /// Transaction-based tax override variable. Set this to a percentage that will be applied to amount multiplied the quantity selected during checkout. This value overrides any tax settings set in your account profile. Allowable values are numbers 0.001 through 100.
        /// Default – Profile tax settings, if any, apply.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? TaxRate { get; set; }

        /// <summary>
        /// If true allows buyers to specify the quantity.
        /// </summary>
        /// <remarks>Optional</remarks>
        public bool? UndefinedQuantity { get; set; }

        /// <summary>
        /// Weight of items. If profile-based shipping rates are configured with a basis of weight, the sum of weight values is used to calculate the shipping charges for the transaction.
        /// </summary>
        /// <remarks>Optional</remarks>
        public double? Weight { get; set; }

        /// <summary>
        /// The unit of measure if weight is specified.
        /// The default is WeightUnit.Lbs
        /// </summary>
        /// <remarks>Optional</remarks>
        public PayPalWeightUnit? WeightUnit { get; set; }

        /// <summary>
        /// First option field name and label. The os0 variable contains the corresponding value for this option field. For example, if on0 is size, os0 could be large.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string On0 { get; set; }

        /// <summary>
        /// Second option field name and label. The os1 variable contains the corresponding value for this option field. For example, if on1 is color then os1 could be blue.
        /// You can specify a maximum of 7 option field names.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string On1 { get; set; }

        /// <see cref="On0"/>
        /// <remarks>Optional</remarks>
        public string On2 { get; set; }

        /// <see cref="On0"/>
        /// <remarks>Optional</remarks>
        public string On3 { get; set; }

        /// <see cref="On0"/>
        /// <remarks>Optional</remarks>
        public string On4 { get; set; }

        /// <see cref="On0"/>
        /// <remarks>Optional</remarks>
        public string On5 { get; set; }

        /// <see cref="On0"/>
        /// <remarks>Optional</remarks>
        public string On6 { get; set; }

        /// <summary>
        /// Option selection of the buyer for the first option field, on0. If the option field is a dropdown menu or a set of radio buttons, each allowable value should be no more than 64 characters. If buyers enter this value in a text field, there is a 200-character limit.
        /// The option field on0 must also be defined. For example, it could be size.
        /// For priced options, include the price and currency symbol in the text of the option selections, as the following sample code shows:
        /// <option value="small">small - $10.00</option>Add a corresponding option_select0 and option_amount0 variable for each priced option. Only one dropdown menu option selection can have priced options.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string Os0 { get; set; }

        /// <summary>
        /// Option selection of the buyer for the second option field, on0. If the option field is a dropdown menu or a set of radio buttons, each allowable value should be no more than 64 characters. If buyers enter this value in a text field, there is a 200-character limit.
        /// The option field on0 must also be defined. For example, it could be size.
        /// For priced options, include the price and currency symbol in the text of the option selections, as the following sample code shows:
        /// <option value="small">small - $10.00</option>Add a corresponding option_select0 and option_amount0 variable for each priced option. Only one dropdown menu option selection can have priced options.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string Os1 { get; set; }

        /// <see cref="Os0"/>
        /// <remarks>Optional</remarks>
        public string Os2 { get; set; }

        /// <see cref="Os0"/>
        /// <remarks>Optional</remarks>
        public string Os3 { get; set; }

        /// <see cref="Os0"/>
        /// <remarks>Optional</remarks>
        public string Os4 { get; set; }

        /// <see cref="Os0"/>
        /// <remarks>Optional</remarks>
        public string Os5 { get; set; }

        /// <see cref="Os0"/>
        /// <remarks>Optional</remarks>
        public string Os6 { get; set; }

        /// <summary>
        /// The cardinal number of the option field, on0 through on9, that has product options with different prices for each option. You must include option_index if the option field with prices is not on0.
        /// </summary>
        /// <remarks>Optional</remarks>
        public int? OptionIndex { get; set; }

        /// <summary>
        /// For priced options, the value of the first option selection of the on0 dropdown menu. The values must match exactly, as the next sample code shows:
        /// &lt;option value="small"&gt;small - $10.00&lt;/option&gt; ... &lt;input type="hidden" name="option_select0" value="small"&gt;
        /// </summary>
        /// <remarks>Optional</remarks>
        public string OptionSelect0 { get; set; }

        /// <summary>
        /// For priced options, the amount that you want to charge for the first option selection of the on0 dropdown menu. Use only numeric values; the currency is taken from the currency_code variable. For example:
        /// &lt;option value="small"&gt;small - $10.00... &lt;input type="hidden" name="option_amount0"&lt;/option&gt; value="10.00"&gt;
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount0 { get; set; }

        /// <summary>
        /// For priced options, the value of the second option selection of the on0 dropdown menu. For example:
        /// ... &lt;option value="medium"&gt;small - $10.00&lt;/option&gt;... &lt;input type="hidden" name="option_select" value="medium"&gt;
        /// You can specify a maximum of ten option selections by incrementing the option selection index (option_select0 through option_select9).
        /// A corresponding option selection in os0 must also be set.
        /// </summary>
        /// <remarks>Optional</remarks>
        public string OptionSelect1 { get; set; }

        /// <summary>
        /// For priced options, the amount that you want to charge for the second option selection of the on0 dropdown menu. For example:
        /// ... &lt;option value="small"&gt;medium - $15.00&lt;/option&gt; ... &lt;input type="hidden" name="option_amount1" value="15.00"&gt;
        /// You can specify a maximum of ten option amounts by incrementing the option amount index (option_amount0 through option_amount9).
        /// A corresponding option selection in os0 must also be set.
        /// </summary>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount1 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect2 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount2 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect3 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount3 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect4 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount4 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect5 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount5 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect6 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount6 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect7 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount7 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect8 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount8 { get; set; }

        /// <see cref="OptionSelect0"/>
        /// <remarks>Optional</remarks>
        public string OptionSelect9 { get; set; }

        /// <see cref="OptionAmount0"/>
        /// <remarks>Optional</remarks>
        public decimal? OptionAmount9 { get; set; }

        public NameValueCollection GetValues()
        {
            var nvc = new NameValueCollection
                          {
                              {PayPalRequestVariables.Command, PayPalManager.ValueOf(PayPalCommand.BuyNow)},
                              {PayPalRequestVariables.SellerPayPalAccount, _settings.Account}
                          };
            if (Amount.HasValue)
                nvc.Add(PayPalRequestVariables.Amount, Convert.ToString(Amount.Value));
            if (DiscountAmount.HasValue)
                nvc.Add(PayPalRequestVariables.DiscountAmount, Convert.ToString(DiscountAmount.Value));
            if (DiscountAmount2.HasValue)
                nvc.Add(PayPalRequestVariables.DiscountAmount2, Convert.ToString(DiscountAmount2.Value));
            if (DiscountRate.HasValue)
                nvc.Add(PayPalRequestVariables.DiscountRate, Convert.ToString(DiscountRate.Value));
            if (DiscountRate2.HasValue)
                nvc.Add(PayPalRequestVariables.DiscountRate2, Convert.ToString(DiscountRate2.Value));
            if (DiscountNum.HasValue)
                nvc.Add(PayPalRequestVariables.DiscountNum, Convert.ToString(DiscountNum.Value));
            if (!string.IsNullOrWhiteSpace(ItemName))
                nvc.Add(PayPalRequestVariables.ItemName, ItemName);
            if (!string.IsNullOrWhiteSpace(ItemNumber))
                nvc.Add(PayPalRequestVariables.ItemNumber, ItemNumber);
            if (Quantity.HasValue)
                nvc.Add(PayPalRequestVariables.Quantity, Convert.ToString(Quantity.Value));
            if (Shipping.HasValue)
                nvc.Add(PayPalRequestVariables.Shipping, Convert.ToString(Shipping.Value));
            if (Shipping2.HasValue)
                nvc.Add(PayPalRequestVariables.Shipping2, Convert.ToString(Shipping2.Value));
            if (Tax.HasValue)
                nvc.Add(PayPalRequestVariables.Tax, Convert.ToString(Tax.Value));
            if (TaxRate.HasValue)
                nvc.Add(PayPalRequestVariables.TaxRate, Convert.ToString(TaxRate.Value));
            if (UndefinedQuantity ?? false)
                nvc.Add(PayPalRequestVariables.UndefinedQuantity, "1");
            if (Weight.HasValue)
                nvc.Add(PayPalRequestVariables.Weight, Convert.ToString(Weight.Value));
            if (WeightUnit.HasValue)
                nvc.Add(PayPalRequestVariables.WeightUnit, PayPalManager.ValueOf(WeightUnit.Value));
            if (!string.IsNullOrWhiteSpace(On0))
                nvc.Add(PayPalRequestVariables.On0, On0);
            if (!string.IsNullOrWhiteSpace(On1))
                nvc.Add(PayPalRequestVariables.On1, On1);
            if (!string.IsNullOrWhiteSpace(On2))
                nvc.Add(PayPalRequestVariables.On2, On2);
            if (!string.IsNullOrWhiteSpace(On3))
                nvc.Add(PayPalRequestVariables.On3, On3);
            if (!string.IsNullOrWhiteSpace(On4))
                nvc.Add(PayPalRequestVariables.On4, On4);
            if (!string.IsNullOrWhiteSpace(On5))
                nvc.Add(PayPalRequestVariables.On5, On5);
            if (!string.IsNullOrWhiteSpace(On6))
                nvc.Add(PayPalRequestVariables.On6, On6);
            if (!string.IsNullOrWhiteSpace(Os0))
                nvc.Add(PayPalRequestVariables.Os0, Os0);
            if (!string.IsNullOrWhiteSpace(Os1))
                nvc.Add(PayPalRequestVariables.Os1, Os1);
            if (!string.IsNullOrWhiteSpace(Os2))
                nvc.Add(PayPalRequestVariables.Os2, Os2);
            if (!string.IsNullOrWhiteSpace(Os3))
                nvc.Add(PayPalRequestVariables.Os3, Os3);
            if (!string.IsNullOrWhiteSpace(Os4))
                nvc.Add(PayPalRequestVariables.Os4, Os4);
            if (!string.IsNullOrWhiteSpace(Os5))
                nvc.Add(PayPalRequestVariables.Os5, Os5);
            if (!string.IsNullOrWhiteSpace(Os6))
                nvc.Add(PayPalRequestVariables.Os6, Os6);
            if (OptionIndex.HasValue)
                nvc.Add(PayPalRequestVariables.OptionIndex, Convert.ToString(OptionIndex.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect0))
                nvc.Add(PayPalRequestVariables.OptionSelect0, OptionSelect0);
            if (OptionAmount0.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount0, Convert.ToString(OptionAmount0.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect1))
                nvc.Add(PayPalRequestVariables.OptionSelect1, OptionSelect1);
            if (OptionAmount1.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount1, Convert.ToString(OptionAmount1.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect2))
                nvc.Add(PayPalRequestVariables.OptionSelect2, OptionSelect2);
            if (OptionAmount2.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount2, Convert.ToString(OptionAmount2.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect3))
                nvc.Add(PayPalRequestVariables.OptionSelect3, OptionSelect3);
            if (OptionAmount3.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount3, Convert.ToString(OptionAmount3.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect4))
                nvc.Add(PayPalRequestVariables.OptionSelect4, OptionSelect4);
            if (OptionAmount4.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount4, Convert.ToString(OptionAmount4.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect5))
                nvc.Add(PayPalRequestVariables.OptionSelect5, OptionSelect5);
            if (OptionAmount5.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount5, Convert.ToString(OptionAmount5.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect6))
                nvc.Add(PayPalRequestVariables.OptionSelect6, OptionSelect6);
            if (OptionAmount6.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount6, Convert.ToString(OptionAmount6.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect7))
                nvc.Add(PayPalRequestVariables.OptionSelect7, OptionSelect7);
            if (OptionAmount7.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount7, Convert.ToString(OptionAmount7.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect8))
                nvc.Add(PayPalRequestVariables.OptionSelect8, OptionSelect8);
            if (OptionAmount8.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount8, Convert.ToString(OptionAmount8.Value));
            if (!string.IsNullOrWhiteSpace(OptionSelect9))
                nvc.Add(PayPalRequestVariables.OptionSelect9, OptionSelect9);
            if (OptionAmount9.HasValue)
                nvc.Add(PayPalRequestVariables.OptionAmount9, Convert.ToString(OptionAmount9.Value));

            string notifyUrl = string.IsNullOrWhiteSpace(NotifyUrl)
                                   ? string.IsNullOrWhiteSpace(_settings.NotifyUrl) ? null : _settings.NotifyUrl
                                   : NotifyUrl;
            if (notifyUrl != null)
                nvc.Add(PayPalRequestVariables.InstantPaymentNotificationUrl, notifyUrl.ResolveUrl());

            string returnUrl = string.IsNullOrWhiteSpace(ReturnUrl)
                                   ? string.IsNullOrWhiteSpace(_settings.ReturnUrl) ? null : _settings.ReturnUrl
                                   : ReturnUrl;
            if (returnUrl != null)
                nvc.Add(PayPalRequestVariables.ReturnUrl, returnUrl.ResolveUrl());

            string cancelUrl = string.IsNullOrWhiteSpace(CancelUrl)
                                   ? string.IsNullOrWhiteSpace(_settings.CancelUrl) ? null : _settings.CancelUrl
                                   : CancelUrl;
            if (cancelUrl != null)
                nvc.Add(PayPalRequestVariables.PaymentCancellationUrl, cancelUrl.ResolveUrl());

            if (!string.IsNullOrWhiteSpace(_settings.LogoUrl))
                nvc.Add(PayPalRequestVariables.CustomLogoUrl, _settings.LogoUrl.ResolveUrl());

            return _settings.Encrypt ? PayPalEncryptedWebsitePayments.Encrypt(nvc, _settings) : nvc;
        }
    }
}