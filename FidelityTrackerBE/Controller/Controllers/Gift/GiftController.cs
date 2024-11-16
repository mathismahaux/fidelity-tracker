using Application.UseCases.Gift.Create;
using Application.UseCases.Gift.Create.DTOs;
using Application.UseCases.Gift.FetchAll;
using Application.UseCases.Person.FetchAll.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FidelityTrackerBE.Controllers.Gift;

[ApiController]
[Route("gifts")]
public class GiftController : ControllerBase
{
    private readonly UseCaseFetchAllGifts _useCaseFetchAllGifts;
    private readonly UseCaseCreateGift _useCaseCreateGift;

    public GiftController(UseCaseCreateGift useCaseCreateGift, UseCaseFetchAllGifts useCaseFetchAllGifts)
    {
        _useCaseCreateGift = useCaseCreateGift;
        _useCaseFetchAllGifts = useCaseFetchAllGifts;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Application.UseCases.Gift.FetchAll.DTOs.DtoOutputFetchAllGifts>> FetchAll()
    {
        return Ok(_useCaseFetchAllGifts.Execute());
    }

    [HttpPost("create-gift")]
    public ActionResult<DtoOutputGift> CreateGift(DtoInputGift dto)
    {
        return Ok(_useCaseCreateGift.Execute(dto));
    }
}