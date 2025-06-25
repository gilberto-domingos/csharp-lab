public class StockRecord {
    public string Symbol {
        get => "ABCD";
    }

    private decimal[] prices = new decimal[] {
        105.1m, 103.12m, 106.93m, 104.5m, 103.7m
    };

    public decimal Average {
        get => prices.Sum() / prices.Length;
    }
    public decimal High {
        get => prices.Max();
    }
    public decimal Low {
        get => prices.Min();
    }

    public int length => prices.Length;

    public decimal this[int index]
    {
        get => prices[index];
    }

    public decimal this[string day]
    {
        get
        {
            if (day == "mon")
            {
                return prices[0];
            }

            if (day == "tue")
            {
                return prices[1];
            }

            throw new IndexOutOfRangeException($"{day} is not valid");
            return 0m;
        }
    }

}
