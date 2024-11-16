using Application.UseCases.Person.SearchByName.DTOs;
using Infrastructure.EF;

namespace Application.UseCases.Person.SearchByName;

public class UseCaseSearchPersonByName
{
    private readonly IPersonRepository _repository;

    public UseCaseSearchPersonByName(IPersonRepository repository)
    {
        _repository = repository;
    }

    public List<DtoOutputSearchPersonByName> Execute(DtoInputSearchPersonByName input)
    {
        var persons = _repository.FetchByName(input.Name);

        return persons.Select(p => new DtoOutputSearchPersonByName
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();
    }
}