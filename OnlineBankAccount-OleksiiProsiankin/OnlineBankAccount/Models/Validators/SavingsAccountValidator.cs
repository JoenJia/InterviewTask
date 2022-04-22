using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models.Validators
{
    public class SavingsAccountValidator : IAccountValidator
    {
        public AccountValidationResult Validate(BankAccount account)
        {
            var messages = new List<string>();

            if (account == null)
            {
                messages.Add("Account is not provided for SavingsAccountValidator");
                return new AccountValidationResult(false, messages);
            }


            if (account.Balance < 0)
            {
                messages.Add("Balance for Saving account has to be positive");
                return new AccountValidationResult(false, messages);
            }

            return new AccountValidationResult(true, messages);
        }
    }
}
