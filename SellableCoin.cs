using Binance.NetCore;
using Binance.NetCore.Entities;

public class SellableCoin
{
    BinanceApiClient? binanceApiClient = null;
    public SellableCoin(string apiKey, string apiSecretKey)
    {
        binanceApiClient = new BinanceApiClient(apiKey, apiSecretKey);
    }
    public string Execute()
    {
        // SPELLUSDT
        if (binanceApiClient != null)
        {
            Tick[] ticks = binanceApiClient.Get24HourStats("SPELLUSDT");
            if (ticks != null)
            {
                decimal high = Convert.ToDecimal(ticks[0].highPrice);
                decimal low = Convert.ToDecimal(ticks[0].lowPrice);
                decimal rs = high / low;
                decimal rsi = 100 - (100 / (1 + rs));
                if (rsi > 55)
                {
                    Console.WriteLine("Spell USDT satilabilir" + rsi);
                    return "SPELLUSDT";
                }
            }

            ticks = binanceApiClient.Get24HourStats("DENTUSDT");
            if (ticks != null)
            {
                decimal high = Convert.ToDecimal(ticks[0].highPrice);
                decimal low = Convert.ToDecimal(ticks[0].lowPrice);
                decimal rs = high / low;
                decimal rsi = 100 - (100 / (1 + rs));
                if (rsi > 55)
                {
                    Console.WriteLine("Spell USDT satilabilir" + rsi);
                    return "SPELLUSDT";
                }
            }
        }
        Console.WriteLine("Satilabilir Coin Yok");
        return "";
    }
}