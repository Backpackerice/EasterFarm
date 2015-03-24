namespace EasterFarm.Common
{
    using System;

    public class InsufficientAmmountException : Exception
    {
        private string item;

        public InsufficientAmmountException(string message, string item)
            : this(message, null, item)
        {
        }

        public InsufficientAmmountException(string message, Exception innerException, string item)
            : base(message, innerException)
        {
            this.Item = item;
        }

        public string Item
        {
            get
            {
                return this.item;
            }

            private set
            {
                this.item = value;
            }
        }

        public override string Message
        {
            get
            {
                return string.Format("Insufficient ammount. You don't have enough of item <<{0}>>.", this.Item);
            }
        }
    }
}
