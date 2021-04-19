using BankTesting.Service;
using System;

namespace BankTesting
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BankService bankService = new(null) { BankAccount= new() };
            bankService.Debit(10);
            Console.WriteLine(bankService.BankAccount.Balance<0? "error":"ok");
        }
    }
}
