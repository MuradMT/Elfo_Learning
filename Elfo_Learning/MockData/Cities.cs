using Elfo_Learning.Models;

namespace Elfo_Learning.MockData
{
    public static class Cities
    {
        public static List<CityDto> data
        {
            get
            {
                return new List<CityDto>()
                {
                    new CityDto() {Id=1,Country="Italy",Name="Milan"},
                    new CityDto() {Id=2,Country="Azerbaijan",Name="Baku"},
                    new CityDto() {Id=3,Country="England",Name="London"}

                };
            }

        }
        
    }
}
