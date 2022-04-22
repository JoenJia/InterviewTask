using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models.Fees
{
    public class CheckingAccountFeeForOverdraft : IFeeApplicator
    {
        public decimal GetFeeAmount()
        {
            return 20.0m;
        }
    }
}
