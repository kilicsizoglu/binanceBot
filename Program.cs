public class Program
{
    public static void Main(string[] args)
    {
        Balance balance = new Balance();
        while (true)
        {
            if (balance.GetUSDTBalance() > 5)
            {
                Buy buy = new Buy();
                BuyableCoin buyableCoin = new BuyableCoin();
                buy.Execute(buyableCoin.Execute());
            }
            else if (balance.WithAValueOf5USDT() == true)
            {
                Sell sell = new Sell();
                SellableCoin sellableCoin = new SellableCoin();
                sell.Execute(sellableCoin.Execute());
            }
        }
    }
}