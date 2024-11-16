using Application.UseCases.Person.GetDetails.DTOs;
using Infrastructure.EF;

namespace Application.UseCases.Person.GetDetails;

public class UseCaseGetPersonDetails
{
    private readonly IPersonRepository _repository;

    public UseCaseGetPersonDetails(IPersonRepository repository)
    {
        _repository = repository;
    }

    public DtoOutputGetPersonDetails Execute(int personId)
    {
        var person = _repository.FetchById(personId);
        if (person == null)
        {
            return null;
        }

        var sponsoredCount = _repository.FetchSponsoredPeopleCount(personId);
        var giftsRecieved = _repository.FetchGiftsReceived(personId);

        return new DtoOutputGetPersonDetails
        {
            Name = person.Name,
            SponsoredCount = sponsoredCount,
            GiftsRecieved = giftsRecieved
        };
    }
}