using System.Threading.Channels;

namespace Assel.Messaging
{
    internal sealed class InMemoryMessageQueue
    {
        private readonly Channel<IIntegrationEvent> _channel =
            Channel.CreateUnbounded<IIntegrationEvent>();

        public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;

        public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
    }
}
