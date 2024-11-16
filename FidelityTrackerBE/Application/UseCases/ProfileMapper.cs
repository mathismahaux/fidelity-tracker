using Application.UseCases.Gift.Create.DTOs;
using Application.UseCases.Gift.FetchAll.DTOs;
using Application.UseCases.Person.Create.DTOs;

using AutoMapper;
using Infrastructure.EF.DbEntities;

namespace Application.UseCases;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<Domain.Person, DtoOutputPerson>();
        CreateMap<DbPerson, DtoOutputPerson>();
        CreateMap<DbPerson, Application.UseCases.Person.FetchAll.DTOs.DtoOutputPerson>();
        CreateMap<DbPerson, Domain.Person>();
        CreateMap<DtoInputPerson, Domain.Person>();    
        
        CreateMap<Domain.Gift, DtoOutputGift>();
        CreateMap<DbGift, DtoOutputGift>();
        CreateMap<DbGift, DtoOutputFetchAllGifts>();
        CreateMap<DbGift, Domain.Gift>();
        CreateMap<DtoInputGift, Domain.Gift>();    
    }
}