using dotnet_stocks_api.Interfaces;
using dotnet_stocks_api.Models;
using Npgsql;
using System.Data;
using Dapper;

namespace dotnet_stocks_api.Repositories
{
    public class StockRepository: IStockRepository
    {

        public StockRepository() {
        }

        public List<StockModel> GetAllStocks()
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            List<StockModel> stocks = new List<StockModel>();
            var connectionString = "host=endeavourtech.ddns.net;Port=27443;User Id=evr_sql_app;Password=5LViU5pLkSjRHECec9NF4wRxxV;Database=StocksDB;";

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var command = new NpgsqlCommand("Select * from endeavour.stocks_lookup", connection);

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            adapter.Fill(dataTable);

            dataSet.Tables.Add(dataTable);

            for (var i=0;  i < dataSet.Tables[0].Rows.Count; i++)
            {
                stocks.Add(new StockModel()
                {
                    TickerName = dataSet.Tables[0].Rows[i][0].ToString(),
                    TickerSymbol = dataSet.Tables[0].Rows[i][1].ToString()
                });
            }
            connection.Close();
            return stocks;

        }

        public List<StockModel> GetAllStocksUsingDapper()
        {
            List<StockModel> stocks = new List<StockModel>();
            var connectionString = "host=endeavourtech.ddns.net;Port=27443;User Id=evr_sql_app;Password=5LViU5pLkSjRHECec9NF4wRxxV;Database=StocksDB;";

            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();



            stocks = connection.Query<StockModel>("Select ticker_symbol as TickerSymbol, ticker_name as TickerName from endeavour.stocks_lookup").ToList();

            

            connection.Close();
            return stocks;

        }
    }
}
