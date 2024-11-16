namespace Infrastructure.EF.DbEntities;

public class DbPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? IdSponsor { get; set; }
}