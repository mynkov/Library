using System;

namespace Library.BusinessLayer.Exceptions
{
    public class DataAccessLayerException : LibraryException
    {
        public DataAccessLayerException(string message)
            : base(message)
        {
        }

        public DataAccessLayerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
