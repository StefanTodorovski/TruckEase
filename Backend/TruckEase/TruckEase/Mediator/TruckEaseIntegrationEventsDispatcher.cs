/*
using TruckEase.Mediator.Contracts;
using TruckEase.Mediator.Interfaces;

namespace TruckEase.Mediator;

public class TruckEaseIntegrationEventsDispatcher
{
}

public class TruckEaseIntegrationEventsDispatcher : ITruckEaseIntegrationEventsDispatcher
{
    private readonly IJob jobService;

    public TruckEaseIntegrationEventsDispatcher(IJob jobService)
    {
        this.jobService = jobService;
    }

    public void Dispatch(string jobName, PublishNotification request)
    {
        jobService.Enqueue<ITruckEaseEventsPublisher>(x => x.PublishAsync(jobName, request));
    }

    public void Dispatch(PublishNotification request)
    {
        jobService.Enqueue<ITruckEaseEventsPublisher>(x => x.PublishAsync(request));
    }

    public void Schedule(PublishNotification request, ITruckEaseEventsPublisher publisher, TimeSpan callTime)
    {
        jobService.Schedule(() => publisher.PublishAsync(request), callTime);
    }
}
*/