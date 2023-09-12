using Binance.NetCore;
using Binance.NetCore.Entities;

public class Sell
{
    string apiKey = "";
    string apiSecretKey = "";

    private BinanceApiClient? binanceApiClient = null;
    public Sell(string apiKey, string apiSecretKey)
    {
        binanceApiClient = new BinanceApiClient(apiKey, apiSecretKey);
        this.apiKey = apiKey;
        this.apiSecretKey = apiSecretKey;
    }

    public void Execute(string coin)
    {
        if (coin != "")
        {
            if (binanceApiClient != null)
            {
                try
                {
                    Tick[] tick = binanceApiClient.Get24HourStats(coin);
                    var tradeParams = new TradeParams
                    {
                        price = new Balance(apiKey, apiSecretKey).GetBalance(coin),
                        stopPrice = Convert.ToDecimal(tick[0].lastPrice) + 0.1m,
                        quantity = new Balance(apiKey, apiSecretKey).GetBalance(coin),
                        side = Side.SELL.ToString(),
                        symbol = coin,
                        type = OrderType.STOP_LOSS_LIMIT.ToString()
                    };
                    binanceApiClient.PostTrade(tradeParams);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}