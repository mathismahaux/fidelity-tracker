using Application.UseCases.Gift.FetchAll.DTOs;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Gift.FetchAll;

public class UseCaseFetchAllGifts
{
    private readonly IGiftRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllGifts(IGiftRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<DtoOutputFetchAllGifts> Execute()
    {
        var people = _repository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputFetchAllGifts>>(people);
    }
}