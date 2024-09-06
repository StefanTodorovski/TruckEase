using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckEase.Authentication.Interfaces;
using TruckEase.Contracts.CurrentUser.Responses;
using TruckEase.Mediator.Interfaces;

namespace TruckEase.Controllers;

[Route("api/currentuser")]
[ApiController]
public class CurrentUserController : ControllerBase
{
    private readonly ICurrentUser currentUser;

    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public CurrentUserController(ICurrentUser currentUser, ITruckEaseEventsPublisher eventsPublisher)
    {
        this.currentUser = currentUser;
        this.eventsPublisher = eventsPublisher;
    }

    [HttpGet]
    public ActionResult<CurrentUserResponse?> GetCurrentUser() => currentUser.Id >= 0 ? new CurrentUserResponse(
        currentUser.Id,
        currentUser.FirstName,
        currentUser.LastName,
        currentUser.Email,
        currentUser.InCompanyFK) : null;

}
