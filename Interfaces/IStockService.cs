using dotnet_stocks_api.Models;

namespace dotnet_stocks_api.Interfaces
{
    public interface IStockService
    {
        public List<StockModel> GetAllStocks();

        public List<StockModel> InsertStocks(StockModel stock);

        public StockModel GetStockByTickerSymbol(string symbol);
    }
}
