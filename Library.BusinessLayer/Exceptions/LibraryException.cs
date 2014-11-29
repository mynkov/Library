using System;

namespace Library.BusinessLayer.Exceptions
{
    public abstract class LibraryException : Exception
    {
        protected LibraryException(string message)
            : base(message)
        {
        }

        protected LibraryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
