namespace Domain.Commons
{
    using System;

    public interface IValidationResult
    {
        bool IsValid { get; set; }

        Exception Exception { get; set; }
    }
}
