using System;
using System.Linq;

namespace SampleAlgorithms
{
    public class PasswordStrengthEvaluator
    {
        /// <summary>
        /// Evaluates the strength of a given password based on common security rules.
        /// Returns one of: "Weak", "Medium", or "Strong".
        /// </summary>
        public string Evaluate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");

            int score = 0;

            if (password.Length >= 8)
                score++;
            if (password.Any(char.IsUpper))
                score++;
            if (password.Any(char.IsLower))
                score++;
            if (password.Any(char.IsDigit))
                score++;
            if (password.Any(ch => "!@#$%^&*()_+-=[]{}|;:'\",.<>?".Contains(ch)))
                score++;

            if (score <= 2)
                return "Weak";
            else if (score == 3 || score == 4)
                return "Medium";
            else
                return "Strong";
        }
    }
}
