using Application.UseCases.Person.AssignSponsor.DTOs;
using Application.UseCases.Utils;
using Infrastructure.EF;

namespace Application.UseCases.Person.AssignSponsor;

public class UseCaseAssignSponsor : IUseCaseWriter<bool, DtoInputAssignSponsor>
{
    private readonly IPersonRepository _repository;

    public UseCaseAssignSponsor(IPersonRepository repository)
    {
        _repository = repository;
    }

    public bool Execute(DtoInputAssignSponsor input)
    {
        var person = _repository.FetchById(input.PersonId);
        if (person == null)
        {
            throw new ArgumentException("Person not found.");
        }

        var sponsor = _repository.FetchById(input.SponsorId);
        if (sponsor == null)
        {
            throw new ArgumentException("Sponsor not found.");
        }

        person.IdSponsor = input.SponsorId;
        _repository.Update(person);

        return true;
    }
}