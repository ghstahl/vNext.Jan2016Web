using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ConsoleApp.Cassandra.Products
{
    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<Task<T>> taskFactory, bool startNewTaskForFactoryMethod = false)
            : base(startNewTaskForFactoryMethod ? () => StartNewTask(taskFactory) : taskFactory)
        {
        }

        public ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter GetAwaiter()
        {
            // Since we're using this class in the context of our library, always use ConfigureAwait(false) with the Task
            return Value.ConfigureAwait(false).GetAwaiter();
        }

        private static Task<T> StartNewTask(Func<Task<T>> taskFactory)
        {
            return Task.Factory.StartNew(taskFactory).Unwrap();
        }
    }
}