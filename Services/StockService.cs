using dotnet_stocks_api.Models;
using dotnet_stocks_api.Interfaces;

namespace dotnet_stocks_api.Services
{
    public class StockService: IStockService
    {
        IStockRepository _stockRepository;
        List<StockModel> stocks = new List<StockModel>();
        public StockService(IStockRepository stockRepository) {
            _stockRepository = stockRepository;
        }

        public List<StockModel> GetAllStocks()
        {
            return _stockRepository.GetAllStocksUsingDapper();
        }

        public List<StockModel> InsertStocks(StockModel stock)
        {
            stocks.Add(stock);

            return stocks;
        }

        public StockModel GetStockByTickerSymbol(string symbol)
        {
            return stocks.Find(s => s.TickerSymbol == symbol);
        }
    }
}
