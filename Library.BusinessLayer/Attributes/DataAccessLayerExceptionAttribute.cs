using System;
using Library.BusinessLayer.Exceptions;

namespace Library.BusinessLayer.Attributes
{
    [Serializable]
    public class DataAccessLayerExceptionAttribute : ExceptionAttribute
    {
        protected override Exception CreateException(string message, Exception innerException)
        {
            return new DataAccessLayerException(message, innerException);
        }
    } 
}
