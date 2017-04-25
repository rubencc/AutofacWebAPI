namespace Domain.Commons.Rules
{
    using System;
    using System.Threading.Tasks;
    using Infraestructure.Commons;
    using Infraestructure.IoC.Interfaces;

    public class RulesValidatorRequest<T> : IRulesValidatorRequest<T>
        where T : class, IRequest
    {
        private IFactory factory;

        protected RulesValidatorRequest(IFactory factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            this.factory = factory;
        }

        protected virtual bool ApplyRules(T entity)
        {
            return false;
        }

        protected virtual async Task<bool> ApplyRulesAsync(T entity)
        {
            await Task.CompletedTask.ConfigureAwaitFalse();
            return false;
        }

        public IValidationResultRequest<T> Validate(T entity)
        {
            try
            {
                this.ApplyRules(entity);
                IValidationResultRequest<T> result = this.factory.Resolve<IValidationResultRequest<T>>();
                result.IsValid = true;
                return result;
            }
            catch (Exception ex)
            {
                IValidationResultRequest<T> result = this.factory.Resolve<IValidationResultRequest<T>>();
                result.IsValid = false;
                result.Exception = ex;
                return result;
            }
        }

        public async Task<IValidationResultRequest<T>> ValidateAsync(T entity)
        {
            try
            {
                await this.ApplyRulesAsync(entity).ConfigureAwaitFalse();
                IValidationResultRequest<T> result = this.factory.Resolve<IValidationResultRequest<T>>();
                result.IsValid = true;
                return result;
            }
            catch (Exception ex)
            {
                IValidationResultRequest<T> result = this.factory.Resolve<IValidationResultRequest<T>>();
                result.IsValid = false;
                result.Exception = ex;
                return result;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            this.DisposeResources();
        }

        protected virtual void DisposeResources()
        {
            this.factory?.Dispose();
            this.factory = null;
        }
    }
}
