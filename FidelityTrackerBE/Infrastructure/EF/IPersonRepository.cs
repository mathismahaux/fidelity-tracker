using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF;

public interface IPersonRepository
{
    IEnumerable<DbPerson> FetchAll();
    DbPerson FetchById(int id);
    List<DbPerson> FetchByName(string name);
    int FetchSponsoredPeopleCount(int sponsorId);
    List<string> FetchGiftsReceived(int personId);
    void CreateAcquisition(int sponsorId, int giftId);
    DbPerson Create(string name, int? idSponsor);
    bool Update(DbPerson person);
}