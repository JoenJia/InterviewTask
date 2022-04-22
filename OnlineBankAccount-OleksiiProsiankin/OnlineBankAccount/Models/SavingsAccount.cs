using OnlineBankAccount.Models;
using OnlineBankAccount.Models.Fees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(IAccountValidator validator, List<IFeeApplicator> feeApplicators) : base(validator, feeApplicators)
        {
        }
    }
}
