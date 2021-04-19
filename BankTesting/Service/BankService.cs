using BankTesting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTesting.Service
{
    public class BankService : IBankService
    {
        public BankAccount BankAccount { get ; set ; }
        private LoanService loanService; 
       
        public BankService(LoanService _loanService)
        {
            loanService = _loanService;
        }

        public void Credit(double amount)
        {
            BankAccount.Balance += amount;
        }

        public void Debit(double amount)
        {

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, IBankService.DebitAmountLessThanZeroMessage);
            }

            if (amount> BankAccount.Balance)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, IBankService.DebitAmountExceedsBalanceMessage);
            }

            BankAccount.Balance -= amount;
        } 
        
        public bool CheckCustomer()
        {
           return loanService.CheckEmployeeMethod();
        }

        public bool CheckCustomer(int category)
        {
           return loanService.CheckEmployeeMethod(category);
        }

    }
}
