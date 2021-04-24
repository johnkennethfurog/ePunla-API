using System;
using ePunla.Common.Utilitites.Validations;

namespace ePunla.Common.Utilitites.Response
{
    public class MediatrResponse
    {
        public bool IsInvalid { get; set; }
        public ErrorMessage ErrorMessage { get; set; }

        public MediatrResponse(ErrorMessage errorMessage)
        {
            ErrorMessage = errorMessage;
            IsInvalid = true;
        }

        public MediatrResponse()
        {

        }
    }

    public class MediatrResponse<T> : MediatrResponse
    {
        public T Value { get; set; }

        public MediatrResponse(ErrorMessage errorMessage): base(errorMessage) { }

        public MediatrResponse(T value)
        {
            Value = value;
        }
    }
}
