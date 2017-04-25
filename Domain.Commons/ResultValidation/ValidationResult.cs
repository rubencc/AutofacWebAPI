namespace Domain.Commons
{
    using System;
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public Exception Exception { get; set; }
    }
}
