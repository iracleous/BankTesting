using BankTesting.Model;
using BankTesting.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankTestingTest
{
    [TestClass]
    public class BankServiceTest
    {
        [TestMethod]
        public void TestDebit()
        {
            //Arrangement
            double beginningBalance = 11.99;
            BankAccount bankAccount = new BankAccount() { Balance = beginningBalance, CustomerName = "Dimitris Dimitriou" };
            double debitAmount = 4.55;
            double expected = 7.44;
            BankService bankService = new BankService(null) { BankAccount = bankAccount };


            //Action
            bankService.Debit(debitAmount);
            var result = bankService.BankAccount.Balance;


            //Assertion


        }


        [TestMethod]
        public void TestNotNegativeBalance()
        {
            //Arrangement
            double beginningBalance = 10;
            BankAccount bankAccount = new BankAccount() { Balance = beginningBalance, CustomerName = "Dimitris Dimitriou" };
            double debitAmount = 20;
            double expected = 10;
            BankService bankService = new BankService(null) { BankAccount = bankAccount };


            //Action
            try
            {
                bankService.Debit(debitAmount);

            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, IBankService.DebitAmountExceedsBalanceMessage);
                return;
            }

            //Assertion
            Assert.Fail("The expected exception did not take place");

        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new() { CustomerName = "Mr. Dionysios Dionysiou", Balance = beginningBalance };
            BankService bankService = new BankService(null) { BankAccount = account };

            // Action and assertion
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => bankService.Debit(debitAmount));
        }

        [TestMethod]
        public void Test_ToanService_As_Moq()
        {
            //Arrangement
            double beginningBalance = 11.99;
            BankAccount account = new() { CustomerName = "Mr. Dionysios Dionysiou", Balance = beginningBalance };
            Mock<LoanService> loanServiceMock = new();
            loanServiceMock.Setup(x => x.CheckEmployeeMethod()).Returns(true);
            BankService bankService = new BankService(loanServiceMock.Object) { BankAccount = account };

            //action
            bool result = bankService.CheckCustomer();
            bool expected = true;

            //Assertion
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ToanService_As_Moq_With_Parameters()
        {
            //Arrangement
            double beginningBalance = 11.99;
            BankAccount account = new() { CustomerName = "Mr. Dionysios Dionysiou", Balance = beginningBalance };
            Mock<LoanService> loanServiceMock = new();
            loanServiceMock.Setup(x => x.CheckEmployeeMethod(It.IsAny<int>())).Returns(true);
            BankService bankService = new (loanServiceMock.Object) { BankAccount = account };

            //action
            bool result = bankService.CheckCustomer(5);
            bool expected = true;

            //Assertion
            Assert.AreEqual(expected, result);
        }



    }
}
