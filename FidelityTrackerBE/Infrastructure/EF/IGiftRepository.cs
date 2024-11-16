using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IGiftRepository
{
    IEnumerable<DbGift> FetchAll();
    DbGift Create(string name);
}