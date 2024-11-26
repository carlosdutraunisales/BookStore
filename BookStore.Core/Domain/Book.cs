namespace BookStore.Core.Domain
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string ISSN { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; } // Será buscado no serviço externo
    }
}
