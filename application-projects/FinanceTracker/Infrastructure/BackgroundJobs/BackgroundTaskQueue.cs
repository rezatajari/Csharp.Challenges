using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Infrastructure.BackgroundJobs
{
    public interface IBackgroundTaskQueue
    {
        ValueTask QueueBackgroundWorkItemAsync(string workItem);
        ValueTask<string> DequeueAsync(CancellationToken cancellationToken);
    }
    public class BackgroundTaskQueue: IBackgroundTaskQueue
    {
        private readonly Channel<string> _queue;
        public BackgroundTaskQueue()
        {
            var option = new BoundedChannelOptions(100)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue= Channel.CreateBounded<string>(option);
        }
        public ValueTask<string> DequeueAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask QueueBackgroundWorkItemAsync(string workItem)
        {
            throw new NotImplementedException();
        }
    }
}
