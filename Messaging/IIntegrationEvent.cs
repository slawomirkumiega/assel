using MediatR;

namespace Assel.Messaging
{
    public interface IIntegrationEvent : INotification
    {
    }

    public abstract record IntegrationEvent() : IIntegrationEvent;
}
