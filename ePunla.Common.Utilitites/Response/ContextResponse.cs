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

        public static ContextResponse ValidateContextResponse(int? validation)
        {
            if (validation != null)
                return new ContextResponse(validation);
            else
                return new ContextResponse();
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

        public static ContextResponse<TResponse> ValidateContextResponse<TResponse>(int? validation, TResponse response )
        {
            if (validation != null)
                return new ContextResponse<TResponse>(validation);
            else
                return new ContextResponse<TResponse>(response);
        }
    }
}
