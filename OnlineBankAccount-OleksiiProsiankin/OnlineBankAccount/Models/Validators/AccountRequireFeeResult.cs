using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models.Validators
{
    public class AccountRequireFeeResult : AccountValidationResult
    {
        public AccountRequireFeeResult(bool isValid, List<string> messages) : base(isValid, messages)
        {
        }
    }
}
