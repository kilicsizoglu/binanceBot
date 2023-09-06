using Binance.NetCore;
using Binance.NetCore.Entities;

public class SellableCoin {
    BinanceApiClient? binanceApiClient = null;
    public SellableCoin() {
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
            if (rsi > 70) {
                return "SPELLUSDT";
            }
        }
        return "";
    }
}