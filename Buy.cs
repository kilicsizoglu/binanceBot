using Binance.NetCore;
using Binance.NetCore.Entities;

public class Buy {
    private BinanceApiClient? binanceApiClient = null;
    public Buy() {
        binanceApiClient = new BinanceApiClient("");
    }
    public void Execute(BuyableCoin coin) {
        if (binanceApiClient != null) {
            Tick[] tick = binanceApiClient.Get24HourStats("SPELLUSDT");
            var tradeParams = new TradeParams
            {
                price = new Balance().GetBalance("SPELLUSDT"),
                stopPrice = Convert.ToDecimal(tick[0].lastPrice) - 0.1m,
                quantity = new Balance().GetBalance("SPELLUSDT"),
                side = Side.BUY.ToString(),
                symbol = "SPELLUSDT",
                type = OrderType.STOP_LOSS_LIMIT.ToString()
            };
            binanceApiClient.PostTrade(tradeParams);
        }
    }
}