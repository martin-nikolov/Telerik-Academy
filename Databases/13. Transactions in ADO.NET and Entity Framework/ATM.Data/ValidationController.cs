namespace ATM.Data
{
    using System;
    using System.Linq;

    public class ValidationController
    {
        private const int CardNumberLength = 10;
        private const int CardPinLength = 4;

        public bool IsValidCardNumber(string cardNumber)
        {
            var isValidCardNumber = !string.IsNullOrEmpty(cardNumber) && cardNumber.Trim().Length == CardNumberLength;
            return isValidCardNumber;
        }

        public bool IsValidCardPin(string cardPin)
        {
            var isValidCardPin = !string.IsNullOrEmpty(cardPin) && cardPin.Trim().Length == CardPinLength;
            return isValidCardPin;
        }

        public bool IsPermittedWithdrawalAmount(decimal withdrawalAmount, decimal moneyInCardAccount)
        {
            var isPermittedWithdrawalAmount = withdrawalAmount > 0 && moneyInCardAccount >= withdrawalAmount;
            return isPermittedWithdrawalAmount;
        }

        public bool IsPinCodeMatches(string expected, string actual)
        {
            var isPinCodeMatches = expected == actual;
            return isPinCodeMatches;
        }
    }
}