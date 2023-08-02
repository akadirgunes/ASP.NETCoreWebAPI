namespace CityAPI.Core.Dtos.City
{
    public class DeleteCity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Istanbul";
        public int Populasyon { get; set; } = 17000000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
    }
}
