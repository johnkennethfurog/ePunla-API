using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Validations;

namespace ePunla.Common.Utilitites.Response
{
    public class MediatrResponse
    {
        public bool IsInvalid { get; set; }

        private IEnumerable<ErrorMessage> _errorMessages;
        public IEnumerable<ErrorMessage> ErrorMessages
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                IsInvalid = true;
                _errorMessages = value;
            }
        }


        public MediatrResponse(ErrorMessage errorMessage)
        {
            ErrorMessages = new List<ErrorMessage> { errorMessage };
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

        public MediatrResponse()
        {

        }
    }
}
