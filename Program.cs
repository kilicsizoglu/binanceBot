public class Program
{
    public static void Main(string[] args)
    {
        string apiKey = "";
        string apiSecretKey = "";
        Balance balance = new Balance(apiKey, apiSecretKey);
        while (true)
        {
            if (balance.GetUSDTBalance() >= 5)
            {
                Buy buy = new Buy(apiKey, apiSecretKey);
                BuyableCoin buyableCoin = new BuyableCoin(apiKey, apiSecretKey);
                buy.Execute(buyableCoin.Execute());
            }
            if (balance.WithAValueOf5USDT() == true)
            {
                Sell sell = new Sell(apiKey, apiSecretKey);
                SellableCoin sellableCoin = new SellableCoin(apiKey, apiSecretKey);
                sell.Execute(sellableCoin.Execute());
            }
        }
    }
}