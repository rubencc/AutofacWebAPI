namespace Domain.Commons
{
    public interface IResponse<T> where T : class, IRequest

    {
        T Request { get; set; }
        IValidationResultRequest<T> ValidationResult { get; set; }
    }
}
