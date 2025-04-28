// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for Event Challenge

namespace EventsChallenge
{
    class PiggyBank {
        private decimal _BalanceAmount;

        public decimal TheBalance {
            set {
                _BalanceAmount = value;
            }
            get {
                return _BalanceAmount;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            decimal[] testValues = { 250, 1000, -750, 100, -200 };
            
            PiggyBank pb = new PiggyBank();

            foreach (decimal testValue in testValues) {
                pb.TheBalance += testValue;
            }
            Console.WriteLine($"Final value is {pb.TheBalance}");
        }
    }
}
