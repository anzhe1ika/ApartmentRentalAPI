using ApartmentRental.Common;

namespace ApartmentRental.DAL.Entities
{
    public class Apartment
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Districts District { get; set; }

        public string Street { get; set; }

        public string BuildingNum { get; set; }

        public int RoomsCount { get; set; }

        public FurnitureType FurnitureType { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsChildFriendly { get; set; }

        public int Floor { get; set; }

        public int BuildingFloorCount { get; set; }

        public float Area { get; set; }

        public bool IsActive { get; set; }

        public DateTime PublishingDate { get; set; }

        public List<string> PhotosUrls { get; set; }
        
        public int? OwnerID { get; set; }
        
        public Owner? Owner { get; set; }

        public int? RieltorID { get; set; }

        public Rieltor? Rieltor { get; set; }
    }
}
