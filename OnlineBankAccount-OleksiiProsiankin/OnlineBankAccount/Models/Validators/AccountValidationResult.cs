namespace OnlineBankAccount.Models
{
    public class AccountValidationResult
    {
        public AccountValidationResult(bool isValid, List<string> messages)
        {
            IsValid = isValid;
            Messages = messages;
        }
        public bool IsValid { get; set; }

        public List<string> Messages { get; set; } = new List<string>();
    }
}