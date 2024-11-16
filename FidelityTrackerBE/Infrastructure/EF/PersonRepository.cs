using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class PersonRepository : IPersonRepository
{
    private readonly FidelityTrackerDbContext _context;

    public PersonRepository(FidelityTrackerDbContext context)
    {
        _context = context;
    }
    
    public DbPerson FetchById(int id)
    {
        return _context.People.SingleOrDefault(p => p.Id == id);
    }

    public List<DbPerson> FetchByName(string name)
    {
        return _context.Set<DbPerson>()
            .Where(p => p.Name.Contains(name))
            .ToList();
    }
    
    public int FetchSponsoredPeopleCount(int sponsorId)
    {
        return _context.Set<DbPerson>().Count(p => p.IdSponsor == sponsorId);
    }

    public List<string> FetchGiftsReceived(int personId)
    {
        return _context.Set<DbAcquisition>()
            .Where(a => a.IdSponsor == personId)
            .Join(_context.Set<DbGift>(), a => a.IdGift, g => g.Id, (a, g) => g.Name)
            .ToList();
    }

    public DbPerson Create(string name, int? idSponsor)
    {
        var person = new DbPerson
        {
            Name = name,
            IdSponsor = idSponsor
        };
        _context.People.Add(person);
        _context.SaveChanges();
        return person;
    }
    
    public void CreateAcquisition(int sponsorId, int giftId)
    {
        var acquisition = new DbAcquisition
        {
            IdSponsor = sponsorId,
            IdGift = giftId
        };
        _context.Set<DbAcquisition>().Add(acquisition);
        _context.SaveChanges();
    }

    public bool Update(DbPerson person)
    {
        var entity = _context.People.FirstOrDefault(e => e.Id == person.Id);

        if (entity == null)
        {
            return false;
        }
        
        entity.Name = person.Name;
        entity.IdSponsor = person.IdSponsor;
        
        _context.SaveChanges();

        return true;
    }
}