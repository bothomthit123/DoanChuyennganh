
    public class Place
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }

