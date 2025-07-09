public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; } // "Admin" or "Operator"

    public int? AreaId { get; set; } // For Admins
    public List<UserStation> UserStations { get; set; } // For Operators
}
public class UserStation
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int StationId { get; set; }
    public Station Station { get; set; }
}
