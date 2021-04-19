using BankTesting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTesting.Service
{
    public interface IBankService
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public BankAccount BankAccount { get; set; }

        public void Debit(double amount);
        public void Credit(double amount);

        public bool CheckCustomer();
    }
}
