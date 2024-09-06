using TruckEase.Mediator.Contracts;

namespace TruckEase.Mediator.Interfaces;

public interface ITruckEaseIntegrationEventsDispatcher
{
    void Dispatch(string jobName, PublishNotification request);

    void Dispatch(PublishNotification request);

    void Schedule(PublishNotification request, ITruckEaseEventsPublisher publisher, TimeSpan callTime);
}
