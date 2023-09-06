using Binance.NetCore;
using Binance.NetCore.Entities;

public class Sell {

    private BinanceApiClient? binanceApiClient = null;
    public Sell() {
        binanceApiClient = new BinanceApiClient("");
    }

    public void Execute(SellableCoin coin) {
        if (binanceApiClient != null) {
            Tick[] tick = binanceApiClient.Get24HourStats("SPELLUSDT");
            var tradeParams = new TradeParams
            {
                price = new Balance().GetBalance("SPELLUSDT"),
                stopPrice = Convert.ToDecimal(tick[0].lastPrice) + 0.1m,
                quantity = new Balance().GetBalance("SPELLUSDT"),
                side = Side.SELL.ToString(),
                symbol = "SPELLUSDT",
                type = OrderType.STOP_LOSS_LIMIT.ToString()
            };
            binanceApiClient.PostTrade(tradeParams);
        }
    }
}