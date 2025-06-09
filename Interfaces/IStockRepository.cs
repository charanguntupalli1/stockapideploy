using dotnet_stocks_api.Models;

namespace dotnet_stocks_api.Interfaces
{
    public interface IStockRepository
    {
        public List<StockModel> GetAllStocks();

        public List<StockModel> GetAllStocksUsingDapper();
    }
}
