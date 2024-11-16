using Infrastructure.EF;
using Infrastructure.EF.DbEntities;

namespace Application.UseCases.Person.GiveGift;

public class UseCaseGiveGiftToPerson
{
    private readonly IPersonRepository _repository;
    private readonly FidelityTrackerDbContext _context;

    public UseCaseGiveGiftToPerson(IPersonRepository repository, FidelityTrackerDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public string Execute(int sponsorId, int giftId)
    {
        var sponsoredCount = _repository.FetchSponsoredPeopleCount(sponsorId);

        if (sponsoredCount % 5 != 0)
        {
            return "Sponsor has not reached a multiple of 5 sponsored people.";
        }

        var gift = _context.Set<DbGift>().FirstOrDefault(g => g.Id == giftId);

        if (gift == null)
        {
            return "Gift not found.";
        }

        _repository.CreateAcquisition(sponsorId, gift.Id);

        return $"Gift {gift.Name} awarded to sponsor {sponsorId}.";
    }
}