namespace ApartmentRental.DAL.Entities
{
    public class Rieltor
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public bool IsVerified { get; set; }
        public int FeedbackCount { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}
