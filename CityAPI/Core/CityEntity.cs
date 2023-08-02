namespace CityAPI.Core
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Istanbul";
        public int Populasyon { get; set; } = 17000000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
        public UserEntity? User { get; set; }
    }
}
