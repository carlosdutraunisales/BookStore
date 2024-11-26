using BookStore.Core.Domain;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Response;
using System.Net.Http.Json;

namespace BookStore.Infrastructure.Services
{
    public class BookPricingService : IBookPricingService
    {
        private readonly HttpClient _httpClient;

        public BookPricingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetPriceByISSNAsync(string issn)
        {
            // var response = await _httpClient.GetFromJsonAsync<PricingResponse>($"https://localhost:32769/ms-book-precification?issn={issn}");
            var pricingResponse = new PricingResponse();
            pricingResponse.Price = (Decimal)ms_book_precification(issn);


            return pricingResponse.Price ?? throw new Exception("Preço não encontrado.");
             
        
        
        }

        public double ms_book_precification(string issn)
        {

            Random random = new Random();

            // Gerar um double entre 0.0 e 1.0
            double randomValue = random.NextDouble();
            Console.WriteLine($"Valor aleatório entre 0.0 e 1.0: {randomValue}");

            // Gerar um double entre um intervalo específico (exemplo: 10.0 a 50.0)
            double min = 10.0;
            double max = 250.0;
            double randomInRange = min + (random.NextDouble() * (max - min));


            return randomInRange;
        }
    }
}
