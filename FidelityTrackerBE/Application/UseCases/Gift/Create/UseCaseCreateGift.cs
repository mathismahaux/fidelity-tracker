using Application.UseCases.Gift.Create.DTOs;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.EF;

namespace Application.UseCases.Gift.Create;

public class UseCaseCreateGift : IUseCaseWriter<DtoOutputGift, DtoInputGift>
{
    private readonly IGiftRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseCreateGift(IGiftRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public DtoOutputGift Execute(DtoInputGift input)
    {
        var gift = _mapper.Map<Domain.Gift>(input);
        var dbGift = _repository.Create(gift.Name);
        return _mapper.Map<DtoOutputGift>(dbGift);
    }
}