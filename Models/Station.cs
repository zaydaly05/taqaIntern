
namespace InGazAPI.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Station> Stations {get; set;}
        public DateTime ModifiedOn{get; set;}
        public string ModifiedBy{get; set;}

        // Foreign key to Area
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}



