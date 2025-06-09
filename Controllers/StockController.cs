using dotnet_stocks_api.Interfaces;
using dotnet_stocks_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_stocks_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        IStockService _stockService;

        public StockController( IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet()]
        public List<StockModel> GetAllStocks()
        {
            
            return _stockService.GetAllStocks();
        }

        [HttpGet("{tickerSymbol}")]
        public StockModel GetByTickerSymbol([FromRoute] string tickerSymbol)
        {

            return _stockService.GetStockByTickerSymbol(tickerSymbol);
        }

        [HttpGet("get")]
        public StockModel GetBySymbol([FromQuery] string tickerSymbol)
        {

            return _stockService.GetStockByTickerSymbol(tickerSymbol);
        }

        [HttpPost]
        public List<StockModel> Post([FromBody] StockModel stock)
        {
           var stockList =  _stockService.InsertStocks(stock);

            return stockList;
           
        }

        [HttpPut]
        public IActionResult Put()
        { 
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
