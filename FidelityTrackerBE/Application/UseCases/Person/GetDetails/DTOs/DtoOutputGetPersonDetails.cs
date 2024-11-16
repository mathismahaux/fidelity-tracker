namespace Application.UseCases.Person.GetDetails.DTOs;

public class DtoOutputGetPersonDetails
{
    public string Name { get; set; }
    public int SponsoredCount { get; set; }
    public List<string> GiftsRecieved { get; set; }
}