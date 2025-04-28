// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for Event Challenge

namespace EventsSolution
{
    public delegate void BalanceEventHandler(decimal OldValue, decimal NewValue);

    class PiggyBank {
        private decimal _BalanceAmount;
        public event BalanceEventHandler? BalanceChanged;

        public decimal TheBalance {
            set {
                decimal oldVal = _BalanceAmount;
                _BalanceAmount = value;
                if (BalanceChanged is not null) { BalanceChanged(oldVal, _BalanceAmount); }
            }
            get {
                return _BalanceAmount;
            }
        }
    }

    class BalanceLogger {
        public static void BalanceLog(decimal oldVal, decimal newVal) {
            Console.WriteLine($"The balance changed from {oldVal} to {newVal}");
        }
    }

    class Program {
        static void Main(string[] args) {
            decimal[] testValues = { 250, 1000, -750, 100, -200 };
            
            PiggyBank pb = new PiggyBank();

            pb.BalanceChanged += BalanceLogger.BalanceLog;

            foreach (decimal testValue in testValues) {
                pb.TheBalance += testValue;
            }
            Console.WriteLine($"Final value is {pb.TheBalance}");
        }
    }
}
