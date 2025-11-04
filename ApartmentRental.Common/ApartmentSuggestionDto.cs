namespace ApartmentRental.Common
{
    public class ApartmentSuggestionDto
    {
        public int ID { get; set; }

        public string? PhotoUrl { get; set; }

        public decimal Price { get; set; }

        public Districts District { get; set; }

        public string Street { get; set; }

        public string BuildingNum { get; set; }

        public FurnitureType FurnitureType { get; set; }

        public bool IsPetFriendly { get; set; }

        public bool IsChildFriendly { get; set; }

        public float Area { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}
