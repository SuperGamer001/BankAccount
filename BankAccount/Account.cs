namespace BankAccount;
using System.Text.RegularExpressions;

/// <summary>
/// Represents an individual bank account.
/// </summary>
public class Account
{
    private static readonly Regex AccountNumberPattern = new(@"^\d{4}-[A-Z]{5}$", RegexOptions.IgnoreCase);
    
    /// <summary>
    /// Creates a new Account instance with the specified account number.
    /// </summary>
    /// <param name="accountNumber">The account number for this account</param>
    /// <exception cref="ArgumentException">Thrown when the account number does not match the required format</exception>
    public Account()
    {
    }
    
    /// <summary>
    /// Account numbers must start with 4 digits followed by a dash, and then 5 characters (A - Z) not case sensitive.
    /// </summary>
    public required string AccountNumber 
    { 
        get => _accountNumber; 
        init
        {
            if (!IsValidAccountNumber(value))
            {
                throw new ArgumentException("Account number must be 4 digits followed by a dash and then 5 uppercase letters (A-Z).", nameof(AccountNumber));
            }
            _accountNumber = value;
        }
    }
    private readonly string _accountNumber;

    /// <summary>
    /// The current balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Validates that an account number matches the required format.
    /// </summary>
    /// <param name="accountNumber">The account number to validate</param>
    /// <returns>True if the account number is valid, otherwise false</returns>
    private static bool IsValidAccountNumber(string accountNumber)
    {
        return !string.IsNullOrEmpty(accountNumber) && AccountNumberPattern.IsMatch(accountNumber);
    }

    /// <summary>
    /// Deposits a specified amount into the account.
    /// </summary>
    /// <param name="amount">The amount to deposit</param>
    /// <returns>The new balance after the deposit</returns>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the deposit amount is negative or zero.</exception>
    public decimal Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        }
        Balance += amount;
        return Balance;
    }

    /// <summary>
    /// Withdraws a specified amount from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw</param>
    /// <returns>The new balance after the withdrawal</returns>
    /// <exception cref="ArgumentException">Is thrown when the withdrawal amount is negative or zero.</exception>
    /// <exception cref="InvalidOperationException">Is thrown when there are insufficient funds for the withdrawal.</exception>
    public decimal Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }
        Balance -= amount;
        return Balance;
    }
}
