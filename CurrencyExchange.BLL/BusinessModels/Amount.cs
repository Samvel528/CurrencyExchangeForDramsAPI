using CurrencyExchange.DAL.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace CurrencyExchange.BLL.BusinessModels
{
    public class Amount
    {
        private const string _actualRatesAPIUrl = "https://api.apilayer.com/exchangerates_data/latest?apikey=vbjeljWWPNFs5FGuVoXeefSI6jdplMS1";
        private readonly decimal _givenAmount;
        private readonly string _currencyType;
        private const string AMD = "AMD";

        public Amount(decimal givenAmount, string currencyType)
        {
            _givenAmount = givenAmount;
            _currencyType = currencyType;
        }

        public (decimal, decimal) ReceivedAmount()
        {
            var actualRates =  GetActualExchangeRate();
            var amdActualRate = actualRates.Rates.TryGetValue(AMD, out decimal currentAMDRate);
            actualRates.Rates.TryGetValue(_currencyType, out decimal currentRate);
            decimal receivedAmount = _givenAmount / (currentAMDRate / currentRate);

            return (receivedAmount, currentRate);
        }

        private ActualExchangeRate GetActualExchangeRate()
        {
            ActualExchangeRate actualExchangeRate;

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(_actualRatesAPIUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using(var response = request.GetResponse())
            {
                using(var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            actualExchangeRate = JsonConvert.DeserializeObject<ActualExchangeRate>(responseString);

            return actualExchangeRate;
        }
    }
}
