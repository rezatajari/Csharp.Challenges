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
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<string> _queue;
        public BackgroundTaskQueue()
        {
            var option = new BoundedChannelOptions(100)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<string>(option);
        }
        public async ValueTask<string> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }

        public async ValueTask QueueBackgroundWorkItemAsync(string workItem)
        {
            await _queue.Writer.WriteAsync(workItem);
        }
    }
}
