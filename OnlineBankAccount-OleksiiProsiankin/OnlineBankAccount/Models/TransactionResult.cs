using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankAccount.Models
{
    public class TransactionResult
    {

        public TransactionResult(bool isSuccessed, List<string> messages)
        {
            IsSuccess = isSuccessed;
            Messages = messages;  
        }
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
