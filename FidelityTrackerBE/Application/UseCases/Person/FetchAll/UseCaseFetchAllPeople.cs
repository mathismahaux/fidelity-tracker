using Application.UseCases.Person.FetchAll.DTOs;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Person.FetchAll;

public class UseCaseFetchAllPeople
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllPeople(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<DtoOutputPerson> Execute()
    {
        var people = _repository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputPerson>>(people);
    }
}