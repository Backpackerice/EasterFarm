namespace EasterFarm.Common
{
    using System;

    public class InsufficientAmmountException : Exception
    {
        private string item;
        private string otherMessage;

        public InsufficientAmmountException(string item)
            : this(string.Empty, item)
        {
            this.otherMessage = string.Format("Insufficient ammount. You don't have enough of item <<{0}>>.", this.Item);
        }

        public InsufficientAmmountException(string message, string item)
            : this(message, null, item)
        {
        }

        public InsufficientAmmountException(string message, Exception innerException, string item)
            : base(string.Empty, innerException)
        {
            this.Item = item;
            this.otherMessage = message;
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
                return this.otherMessage;
            }
        }
    }
}
