using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models
{
    public interface IAccountValidator
    {
        AccountValidationResult Validate(BankAccount account);
    }
}
