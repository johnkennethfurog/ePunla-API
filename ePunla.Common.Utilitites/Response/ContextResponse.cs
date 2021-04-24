using System;
namespace ePunla.Common.Utilitites.Response
{
    public class ContextResponse
    {
        public int? ErrorCode { get; set; }
        public bool IsValid { get; private set; }

        public ContextResponse(int? errorCode)
        {
            ErrorCode = errorCode;
            IsValid = false;
        }

        public ContextResponse()
        {
            IsValid = true;
        }
    }

    public class ContextResponse<T> : ContextResponse
    {
        public T Value { get; set; }

        public ContextResponse(int? errorCode) : base(errorCode)
        {

        }

        public ContextResponse(T value)
        {
            Value = value;
        }
    }
}
