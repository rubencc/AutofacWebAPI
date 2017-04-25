namespace Domain.Commons
{
    public interface IValidationResultRequest<T> : IValidationResult where T : class, IRequest
    {
        T Request { get; set; }
    }
}
