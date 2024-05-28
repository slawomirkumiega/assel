using Assel.Messaging;
using MediatR;

namespace Assel.BackgroundServices
{
    internal sealed class MessageEventProcessorJob(
    InMemoryMessageQueue queue,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<MessageEventProcessorJob> logger)
    : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (IIntegrationEvent integrationEvent in
                queue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    using IServiceScope scope = serviceScopeFactory.CreateScope();

                    IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

                    await publisher.Publish(integrationEvent, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Unexpected issue!");
                }
            }
        }
    }
}
