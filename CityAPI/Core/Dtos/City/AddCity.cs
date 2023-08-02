namespace CityAPI.Core.Dtos.City
{
    public class AddCity
    {
        public string Name { get; set; } = "Istanbul";
        public int Populasyon { get; set; } = 17000000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
    }
}
