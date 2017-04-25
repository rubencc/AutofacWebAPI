namespace Domain.Commons
{
    using System;

    public class ValidationResultRequest<T> : IValidationResultRequest<T> where T : class, IRequest
    {
        public bool IsValid { get; set; }
        public Exception Exception { get; set; }
        public T Request { get; set; }
    }
}
