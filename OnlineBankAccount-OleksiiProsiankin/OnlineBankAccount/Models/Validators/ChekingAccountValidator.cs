using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models.Validators
{
    public class ChekingAccountValidator : IAccountValidator
    {

        public AccountValidationResult Validate(BankAccount account)
        {
            var messages = new List<string>();

            if (account == null)
            {
                messages.Add("Account is not provided for ChekingAccountValidator");
                return new AccountValidationResult(false, messages);
            }


            if (account.Balance < -1000.0m)
            {
                messages.Add("Balance for Cheking account has to be more than -1000");
                return new AccountValidationResult(false, messages);
            }

            if (account.Balance >  -1000.0m && account.Balance < 0)
            {
                messages.Add("Balance for Cheking account require fee");
                return new AccountRequireFeeResult(true, messages);
            }

            return new AccountValidationResult(true, messages);
        }
    }
}
