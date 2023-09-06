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
                buy.Execute(new BuyableCoin.Execute());
            }
            else if (balance.WithAValueOf5USDT() == true)
            {
                Sell sell = new Sell();
                sell.Execute(new SellableCoin.Execute());
            }
        }
    }
}