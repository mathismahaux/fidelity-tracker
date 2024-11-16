using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IGiftRepository
{
    DbGift Create(string name);
}