using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models.Fees
{
    public interface IFeeApplicator
    {
        public decimal GetFeeAmount();
    }
}
