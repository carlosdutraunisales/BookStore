namespace BookStore.Core.Interfaces
{
    public interface IBookPricingService
    {
        Task<decimal> GetPriceByISSNAsync(string issn);
    }
}
