using Binance.NetCore;
using Binance.NetCore.Entities;

public class Sell {

    private BinanceApiClient? binanceApiClient = null;
    public Sell() {
        binanceApiClient = new BinanceApiClient("");
    }

    public void Execute(string coin) {
        if (binanceApiClient != null) {
            Tick[] tick = binanceApiClient.Get24HourStats(coin);
            var tradeParams = new TradeParams
            {
                price = new Balance().GetBalance(coin),
                stopPrice = Convert.ToDecimal(tick[0].lastPrice) + 0.1m,
                quantity = new Balance().GetBalance(coin),
                side = Side.SELL.ToString(),
                symbol = coin,
                type = OrderType.STOP_LOSS_LIMIT.ToString()
            };
            binanceApiClient.PostTrade(tradeParams);
        }
    }
}