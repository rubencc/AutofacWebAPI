namespace Domain.Commons.Rules
{
    using System;
    using System.Threading.Tasks;

    public interface IRulesValidatorRequest<T> : IDisposable
        where T : class, IRequest
    {
        IValidationResultRequest<T> Validate(T entity);
        Task<IValidationResultRequest<T>> ValidateAsync(T entity);
    }
}
