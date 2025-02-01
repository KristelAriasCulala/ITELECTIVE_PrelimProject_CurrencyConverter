namespace ITELECTIVE_PrelimProject_CurrencyConverter.Models
{
    public class CurrencyConverterModel
    {
        public decimal Amount { get; set; } // Amount to be converted
        public string FromCurrency { get; set; } // Source currency
        public string ToCurrency { get; set; } // Target currency
        public decimal ConvertedAmount { get; set; } // Result after conversion
    }
}
