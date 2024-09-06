#nullable disable
namespace TruckEase.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckEase.Authentication.Implementation;
using TruckEase.Commands;
using TruckEase.Contracts.CompanyUser.Mappers;
using TruckEase.Contracts.CompanyUser.Requests;
using TruckEase.Contracts.CompanyUser.Responses;
using TruckEase.Dtos;
using TruckEase.Mediator.Interfaces;
using TruckEase.Queries;
using TruckEase.Vtos;


[Route("api/company-users")]
[ApiController]
public class CompanyUsersController : ControllerBase
{
    private readonly ITruckEaseEventsPublisher eventsPublisher;

    public CompanyUsersController(ITruckEaseEventsPublisher eventsPublisher)
    {
        this.eventsPublisher = eventsPublisher;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterCompanyUserWithTokenResponse>> RegisterCompanyUser([FromBody] RegisterCompanyUserRequest userRequest)
    {
        RegisterCompanyUserVto registerVto = userRequest.ToRegisterCompanyUserVto();

        RegisterCompanyUserDto response = await eventsPublisher.SendAsync(new RegisterCompanyUserCommand(registerVto));

        return Ok(response.ToRegisteredCompanyUserResponse());
    }

    [HttpPatch("{companyUserId:int}/edit")]
    public async Task<IActionResult> EditCompanyUserInfo([FromBody] EditCompanyUserRequest editCompanyUserRequest, [FromRoute] int companyUserId)
    {
        EditCompanyUserVto editCompanyUserVto = editCompanyUserRequest.ToEditCompanyUserVto();

        await eventsPublisher.SendAsync(new EditCompanyUserCommand(editCompanyUserVto, companyUserId));

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<RegisterCompanyUserWithTokenResponse>> LoginUser([FromBody] LoginRequest loginRequest)
    {
        LoginCompanyUserVto loginVto = loginRequest.ToLoginCompanyUserVto();

        RegisterCompanyUserWithTokenDto response = await eventsPublisher.SendAsync(new LoginCompanyUserCommand(loginVto));

        return Ok(response.ToRegisteredCompanyUserResponseWithToken());
    }

    [HttpGet("{companyUserId:int}/info")]
    public async Task<ActionResult<RegisterCompanyUserWithTokenResponse>> GetCompanyUserInfo([FromRoute] int companyUserId)
    {

        CompanyUserInfoDto response = await eventsPublisher.SendAsync(new GetCompanyUserInfoQuery(companyUserId));

        return Ok(response.ToCompanyUserInfoResponse());
    }


}
