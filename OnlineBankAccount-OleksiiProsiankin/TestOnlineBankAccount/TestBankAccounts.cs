using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBankAccount;
using OnlineBankAccount.Factories;

namespace TestOnlineBankAccount
{
    [TestClass]
    public class TestBankAccounts
    {
        private BankAccount tSavingAccount;
        private BankAccount tCheckingAccount;   
        
        [TestInitialize]
        public void InitTest()
        {
            var tSavingsAccountFactory = new SavingsAccountFactory();
            var tCheckingAccountFactory = new CheckingAccountFactory();
            tSavingAccount = (SavingsAccount)tSavingsAccountFactory.CreateAccount();
            tCheckingAccount = (CheckingAccount)tCheckingAccountFactory.CreateAccount();
        }
        [TestMethod]
        public void TestCreateNewAccount()
        {
            var tSavingsAccountFactory = new SavingsAccountFactory();
            var newSavingAccount = (SavingsAccount)tSavingsAccountFactory.CreateAccount();
            Assert.IsNotNull(newSavingAccount, "SavingsAccount was not created!");

            var tCheckingAccountFactory = new CheckingAccountFactory();
            var newChekingsAccount = (CheckingAccount)tCheckingAccountFactory.CreateAccount();
            Assert.IsNotNull(newChekingsAccount, "CheckingAccount was not created!");
        }

        [TestMethod]
        public void TestDepositMoneyIntoAccount()
        {
            tSavingAccount.Balance = 5.0m;
            tSavingAccount.DepositToAccount(10.0m);

            Assert.AreEqual(15.0m, tSavingAccount.Balance);
        }

        [TestMethod]
        public void TestWithdrawMoneyFromAccount()
        {
            tSavingAccount.Balance = 5.0m;

            tSavingAccount.WithdrawFromAccount(3.0m);

            Assert.AreEqual(2.0m, tSavingAccount.Balance);
        }

        [TestMethod]
        public void TestTransferMoneyBetweenAccounts()
        {
            tSavingAccount.Balance = 15.0m;
            tCheckingAccount.Balance = 15.0m;

            tSavingAccount.DoTransfer(10.0m, tSavingAccount, tCheckingAccount);

            Assert.AreEqual(5.0m, tSavingAccount.Balance);
            Assert.AreEqual(25.0m, tCheckingAccount.Balance);
        }

        [TestMethod]
        public void TestInvalidTransactionForSavingAccountIfBalanceLessZero()
        {
            tSavingAccount.Balance = 15.0m;
            tCheckingAccount.Balance = 15.0m;

            tSavingAccount.DoTransfer(20.0m, tSavingAccount, tCheckingAccount);

            Assert.AreEqual(15.0m, tCheckingAccount.Balance);
            Assert.AreEqual(15.0m, tSavingAccount.Balance);
        }

        [TestMethod]
        public void TestInvalidTransactionForCheckingAccountIfBalanceLessThousand()
        {
            tSavingAccount.Balance = 15.0m;
            tCheckingAccount.Balance = 15.0m;

            tCheckingAccount.DoTransfer(10000.0m, tCheckingAccount, tSavingAccount);

            Assert.AreEqual(15.0m, tSavingAccount.Balance);
            Assert.AreEqual(15.0m, tCheckingAccount.Balance);
        }

        [TestMethod]
        public void TestTransactionForCheckingAccountIfOverdraftApplied()
        {
            tSavingAccount.Balance = 15.0m;
            tCheckingAccount.Balance = 15.0m;

            tCheckingAccount.DoTransfer(500.0m, tCheckingAccount, tSavingAccount);

            Assert.AreEqual(515.0m, tSavingAccount.Balance);
            Assert.AreEqual(-505.0m, tCheckingAccount.Balance);
        }
    }
}