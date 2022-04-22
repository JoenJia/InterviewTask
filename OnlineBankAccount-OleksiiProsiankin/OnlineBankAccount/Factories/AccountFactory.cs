using OnlineBankAccount.Models.Fees;
using OnlineBankAccount.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Factories
{

    
    public class CheckingAccountFactory : IAccountFactory
    {

        
        public BankAccount CreateAccount()
        {
            var feeApplicators = new List<IFeeApplicator> { new CheckingAccountFeeForOverdraft() };
            return new CheckingAccount(new ChekingAccountValidator(), feeApplicators);
        }
    }

    public class SavingsAccountFactory : IAccountFactory
    {
        public BankAccount CreateAccount()
        {
            var feeApplicators = new List<IFeeApplicator> { new NoFee() };
            return new SavingsAccount(new SavingsAccountValidator(), feeApplicators);
        }
    }
}
