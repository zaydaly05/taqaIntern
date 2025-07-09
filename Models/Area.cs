
using System.Collections.Generic;

namespace InGazAPI.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        // Navigation properties
        public List<Station> Stations { get; set; } = new();
        public List<User> Users { get; set; } = new();
        public DateTime ModifiedOn{get; set;}
        public string ModifiedBy{get; set;}
    }
}



