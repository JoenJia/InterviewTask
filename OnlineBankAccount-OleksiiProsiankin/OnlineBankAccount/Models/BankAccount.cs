using OnlineBankAccount.Models;
using OnlineBankAccount.Models.Fees;
using OnlineBankAccount.Models.Validators;

namespace OnlineBankAccount
{
    public class BankAccount
    {
        private IAccountValidator Validator { get; }
        private List<IFeeApplicator> FeeApplicators { get; }
        public BankAccount(IAccountValidator validator, List<IFeeApplicator> feeApplicators)
        {
            Validator = validator;
            FeeApplicators = feeApplicators;
        }
        public decimal Balance { get; set; }

        public TransactionResult WithdrawFromAccount(decimal amount)
        {
            Balance -= amount;
            var transactionResult = ValidateAndApplyFee(amount);
            if (!transactionResult.IsSuccess) Balance += amount;
            return transactionResult;
        }

        

        public TransactionResult DepositToAccount(decimal amount)
        {
            Balance += amount;

            var transactionResult = ValidateAndApplyFee(amount);
            if (!transactionResult.IsSuccess) Balance -= amount;
            return transactionResult;
        }

        public TransactionResult DoTransfer(decimal amount, BankAccount? fromAccount = null, BankAccount? toAccount = null) 
        {
            if (fromAccount != null) { fromAccount.Balance -= amount; };
            if (toAccount != null) { toAccount.Balance += amount; };

            var transactionResult = ValidateAndApplyFee(amount);
            if (!transactionResult.IsSuccess) { 
                fromAccount.Balance += amount;
                toAccount.Balance -= amount;
            };
            return transactionResult;
        }

        private void ApplyFee(AccountValidationResult validationResult)
        {
            if (validationResult.GetType() == typeof(AccountRequireFeeResult))
            {
                foreach (var feeApplicator in FeeApplicators)
                {
                    Balance -= feeApplicator.GetFeeAmount();
                }
            }
        }

        private TransactionResult ValidateAndApplyFee(decimal amount)
        {
            var validationResult = Validator.Validate(this);
            if (!validationResult.IsValid)
            {                
                return new TransactionResult(false, validationResult.Messages);
            }

            ApplyFee(validationResult);

            return new TransactionResult(true, null);
        }

    }
}