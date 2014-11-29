using System;
using Library.Common.Extensions;
using PostSharp.Aspects;

namespace Library.BusinessLayer.Attributes
{
    [Serializable]
    public abstract class ExceptionAttribute : OnExceptionAspect
    {
        protected abstract Exception CreateException(string message, Exception innerException);

        protected string GetMessage(MethodExecutionArgs args)
        {
            return string.Format(Properties.Resources.Exceptions.ExceptionAttributeMessage,
                                 args.Method,
                                 args.Arguments.ToJson());
        }

        public override void OnException(MethodExecutionArgs args)
        {
            throw CreateException(GetMessage(args), args.Exception);
        }
    }
}
