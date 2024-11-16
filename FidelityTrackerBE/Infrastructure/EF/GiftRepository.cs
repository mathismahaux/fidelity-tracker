using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public class GiftRepository : IGiftRepository
{
    private readonly FidelityTrackerDbContext _context;

    public GiftRepository(FidelityTrackerDbContext context)
    {
        _context = context;
    }

    public DbGift Create(string name)
    {
        var gift = new DbGift
        {
            Name = name
        };
        _context.Gifts.Add(gift);
        _context.SaveChanges();
        return gift;
    }
}