using Binance.NetCore;
using Binance.NetCore.Entities;

public class BuyableCoin {
    private BinanceApiClient? binanceApiClient = null;
    public Buy() {
        binanceApiClient = new BinanceApiClient("");
    }
    public string Execute() {
        // SPELLUSDT
        if (binanceApiClient != null) {
            Tick[] ticks = binanceApiClient.Get24HourStats("SPELLUSDT");
            decimal high = Convert.ToDecimal(ticks[0].highPrice);
            decimal low = Convert.ToDecimal(ticks[0].lowPrice);
            decimal rs = high / low;
            decimal rsi = 100 - (100 / (1 + rs));
            if (rsi < 30) {
                return "SPELLUSDT";
            }
        }
        return "";
    }
}