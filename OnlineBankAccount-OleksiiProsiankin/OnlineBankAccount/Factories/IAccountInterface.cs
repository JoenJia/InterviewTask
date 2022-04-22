using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Factories
{
    public interface IAccountFactory
    {
        public BankAccount CreateAccount();
    }
}
