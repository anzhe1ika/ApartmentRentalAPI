namespace ApartmentRental.DAL.Entities
{
    public class Owner
    {
        public int ID { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}
