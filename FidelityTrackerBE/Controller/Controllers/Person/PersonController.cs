using Application.UseCases.Person.AssignSponsor;
using Application.UseCases.Person.AssignSponsor.DTOs;
using Application.UseCases.Person.Create;
using Application.UseCases.Person.Create.DTOs;
using Application.UseCases.Person.FetchAll;
using Application.UseCases.Person.GetDetails;
using Application.UseCases.Person.GetDetails.DTOs;
using Application.UseCases.Person.GiveGift;
using Application.UseCases.Person.SearchByName;
using Application.UseCases.Person.SearchByName.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FidelityTrackerBE.Controllers.Person;

[ApiController]
[Route("people")]
public class PersonController : ControllerBase
{
    private readonly UseCaseFetchAllPeople _useCaseFetchAllPeople;
    private readonly UseCaseCreatePerson _useCaseCreatePerson;
    private readonly UseCaseAssignSponsor _useCaseAssignSponsor;
    private readonly UseCaseSearchPersonByName _useCaseSearchPersonByName;
    private readonly UseCaseGetPersonDetails _useCaseGetPersonDetails;
    private readonly UseCaseGiveGiftToPerson _useCaseGiveGiftToPerson;


    public PersonController(UseCaseCreatePerson useCaseCreatePerson, UseCaseAssignSponsor useCaseAssignSponsor, UseCaseSearchPersonByName useCaseSearchPersonByName, UseCaseGetPersonDetails useCaseGetPersonDetails, UseCaseGiveGiftToPerson useCaseGiveGiftToPerson, UseCaseFetchAllPeople useCaseFetchAllPeople)
    {
        _useCaseFetchAllPeople = useCaseFetchAllPeople;
        _useCaseCreatePerson = useCaseCreatePerson;
        _useCaseAssignSponsor = useCaseAssignSponsor;
        _useCaseSearchPersonByName = useCaseSearchPersonByName;
        _useCaseGetPersonDetails = useCaseGetPersonDetails;
        _useCaseGiveGiftToPerson = useCaseGiveGiftToPerson;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputPerson>> FetchAll()
    {
        return Ok(_useCaseFetchAllPeople.Execute());
    }

    [HttpGet("search-by-name")]
    public ActionResult<List<DtoOutputSearchPersonByName>> SearchByName([FromQuery] string name)
    {
        var input = new DtoInputSearchPersonByName { Name = name };
        var result = _useCaseSearchPersonByName.Execute(input);

        if (result == null || result.Count == 0)
        {
            return NotFound("No persons found with the specified name.");
        }

        return Ok(result);
    }

    [HttpGet("get-details")]
    public ActionResult<DtoOutputGetPersonDetails> GetPersonDetails([FromQuery] int id)
    {
        var details = _useCaseGetPersonDetails.Execute(id);

        if (details == null)
        {
            return NotFound("No person found with the specified ID.");
        }
        
        return Ok(details);
    }
    
    [HttpPost("create-person")]
    public ActionResult<DtoOutputPerson> Create(DtoInputPerson dto)
    {
        return Ok(_useCaseCreatePerson.Execute(dto));
    }
    
    [HttpPost("give-gift")]
    public ActionResult AwardGiftToSponsor([FromBody]int id, int giftId)
    {
        var result = _useCaseGiveGiftToPerson.Execute(id, giftId);

        if (result.Contains("not reached"))
        {
            return BadRequest(result);
        }

        if (result.Contains("not found"))
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPatch("assign-sponsor")]
    public ActionResult Update(DtoInputAssignSponsor dto)
    {
        return Ok(_useCaseAssignSponsor.Execute(dto));
    }
}