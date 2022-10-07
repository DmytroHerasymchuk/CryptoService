using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaskCompletion<TResult>
    {
        public Task<TResult> Task { get; private set; }
        public TaskCompletion(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
            }         
        }
        public TResult Result
        {
            get
            {
                return Task.Status == TaskStatus.RanToCompletion ? Task.Result : default;
            }
        }
    }
}
