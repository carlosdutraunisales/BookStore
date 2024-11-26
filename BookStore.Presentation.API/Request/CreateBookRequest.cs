namespace BookStore.Presentation.API.Request
{
    public record CreateBookRequest(string Name, string ISSN, DateTime PublicationDate);
}
