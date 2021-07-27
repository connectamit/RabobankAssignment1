namespace Rabobank.GCOB.Domain.Interfaces.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public decimal? Turnover { get; set; }
        public EntityType EntityType { get; set; }
    }
}
