using System;

namespace EventsChallenge
{
    public class BalanceChangedEventArgs : EventArgs
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }

    class PiggyBank {
        private decimal _BalanceAmount;

        public event EventHandler<BalanceChangedEventArgs> BalanceChanged;

        public decimal TheBalance {
            set {
                decimal old = _BalanceAmount;
                _BalanceAmount = value;
                
                OnBalanceChanged(old, _BalanceAmount);
            }
            get {
                return _BalanceAmount;
            }
        }

        protected virtual void OnBalanceChanged(decimal oldBalance, decimal newBalance)
        {
            BalanceChanged?.Invoke(this, new BalanceChangedEventArgs {
                OldBalance = oldBalance,
                NewBalance = newBalance
            });
        }
    }

    class Program {
        static void Main(string[] args) {
            decimal[] testValues = { 250, 1000, -750, 100, -200 };
            
            PiggyBank pb = new PiggyBank();

            pb.BalanceChanged += (sender, e) => {
                Console.WriteLine($"Balance changed: {e.OldBalance} => {e.NewBalance}");
            };

            foreach (decimal testValue in testValues) {
                pb.TheBalance += testValue;
            }
            Console.WriteLine($"Final value is {pb.TheBalance}");
        }
    }
}