namespace Domain.Commons.Rules
{
    using System.Threading.Tasks;
    using System;
    using Infraestructure.IoC.Interfaces;
    using Infraestructure.Commons;

    public abstract  class RulesValidator<T> : IRulesValidator<T> where T : class
    {
        private IFactory factory;

        protected RulesValidator(IFactory factory)
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

        public IValidationResult Validate(T entity)
        {
            try
            {
                this.ApplyRules(entity);
                IValidationResult result = this.factory.Resolve<IValidationResult>();
                result.IsValid = true;
                return result;
            }
            catch(Exception ex)
            {
                IValidationResult result = this.factory.Resolve<IValidationResult>();
                result.IsValid = false;
                result.Exception = ex;
                return result;
            }
        }

        public async Task<IValidationResult> ValidateAsync(T entity)
        {
            try
            {
                await this.ApplyRulesAsync(entity).ConfigureAwaitFalse();
                IValidationResult result = this.factory.Resolve<IValidationResult>();
                result.IsValid = true;
                return result;
            }
            catch (Exception ex)
            {
                IValidationResult result = this.factory.Resolve<IValidationResult>();
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
