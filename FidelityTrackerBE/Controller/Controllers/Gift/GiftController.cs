using Application.UseCases.Gift.Create;
using Application.UseCases.Gift.Create.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FidelityTrackerBE.Controllers.Gift;

[ApiController]
[Route("gifts")]
public class GiftController : ControllerBase
{
    private readonly UseCaseCreateGift _useCaseCreateGift;

    public GiftController(UseCaseCreateGift useCaseCreateGift)
    {
        _useCaseCreateGift = useCaseCreateGift;
    }

    [HttpPost("create-gift")]
    public ActionResult<DtoOutputGift> CreateGift(DtoInputGift dto)
    {
        return Ok(_useCaseCreateGift.Execute(dto));
    }
}