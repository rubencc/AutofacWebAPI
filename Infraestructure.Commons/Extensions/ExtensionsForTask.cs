namespace Infraestructure.Commons
{
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public static class ExtensionsForTask
    {
        public static ConfiguredTaskAwaitable ConfigureAwaitFalse(this Task task)
        {
            return task.ConfigureAwait(false);
        }

        public static ConfiguredTaskAwaitable<T> ConfigureAwaitFalse<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false);
        }
    }
}
