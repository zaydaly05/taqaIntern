
namespace InGazAPI.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public List<Station> Stations {get; set;}
      

        // Foreign key to Area
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public DateTime ModifiedOn{get; set;}
        public string ModifiedBy{get; set;}
    }
}



