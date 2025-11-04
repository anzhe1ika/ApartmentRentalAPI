namespace ApartmentRental.Common
{
    public class SearchApartmentsRequest
    {
        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public Districts? District { get; set; }

        public int? MinRoomsCount { get; set; }

        public int? MaxRoomsCount { get; set; }

        public FurnitureType? FurnitureType { get; set; }

        public bool? IsPetFriendly { get; set; }

        public bool? IsChildFriendly { get; set; }

        public int? MinFloor { get; set; }

        public int? MaxFloor { get; set; }

        public float? MinArea { get; set; }

        public float? MaxArea { get; set; }
    }
}
