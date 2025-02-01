using Microsoft.AspNetCore.Mvc;
using ITELECTIVE_PrelimProject_CurrencyConverter.Models;

namespace ITELECTIVE_PrelimProject_CurrencyConverter.Controllers
{
    public class CurrencyConverterController : Controller
    {
        private readonly Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.0m },  // Base currency
            { "PHP", 58.35m }, // Example exchange rate: 1 USD = 56.50 PHP
            { "EUR", 0.85m },  // Example exchange rate: 1 USD = 0.85 EUR
            { "GBP", 0.75m },  // Example exchange rate: 1 USD = 0.75 GBP
            { "JPY", 110.0m }, // Example exchange rate: 1 USD = 110.0 JPY
            { "AUD", 1.35m },  // Example exchange rate: 1 USD = 1.35 AUD
            { "CAD", 1.25m },  // Example exchange rate: 1 USD = 1.25 CAD
            { "CHF", 0.92m },  // Example exchange rate: 1 USD = 0.92 CHF
            { "CNY", 6.45m },  // Example exchange rate: 1 USD = 6.45 CNY
            { "INR", 74.0m }   // Example exchange rate: 1 USD = 7a4.0 INR
        };

        [HttpGet]
        public IActionResult Index()
        {
            // Initialize an empty model for the view
            return View(new CurrencyConverterModel());
        }

        [HttpPost]
        public IActionResult Convert(CurrencyConverterModel model)
        {
            if (model.Amount > 0 && exchangeRates.ContainsKey(model.FromCurrency) && exchangeRates.ContainsKey(model.ToCurrency))
            {
                decimal conversionRate = exchangeRates[model.ToCurrency] / exchangeRates[model.FromCurrency];
                model.ConvertedAmount = model.Amount * conversionRate;
            }
            else
            {
                model.ConvertedAmount = 0;
            }

            return View("Index", model);
        }
    }
}