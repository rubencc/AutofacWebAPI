namespace Domain.Commons.Rules
{
    using System;
    using System.Threading.Tasks;

    public interface IRulesValidator<T> : IDisposable
        where T : class
    {
        IValidationResult Validate(T entity);
        Task<IValidationResult> ValidateAsync(T entity);
    }
}
