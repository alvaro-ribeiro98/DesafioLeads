namespace DesafioLeads.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Job { get; set; }
        public int JobId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
