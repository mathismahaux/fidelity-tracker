using Application.UseCases.Person.Create.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Person.Create;

public class UseCaseCreatePerson : IUseCaseWriter<DtoOutputPerson, DtoInputPerson>
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseCreatePerson(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public DtoOutputPerson Execute(DtoInputPerson input)
    {
        var person = _mapper.Map<Domain.Person>(input);
        var dbPerson = _repository.Create(person.Name, person.IdSponsor);
        return _mapper.Map<DtoOutputPerson>(dbPerson);
    }
}