using System.ComponentModel.DataAnnotations;

namespace INGAZAPI.DTOs
{
    public class CreateStationDTO
    {
        [Required(ErrorMessage = "Station name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Station name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Area ID is required")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Latitude is required")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public double Longitude { get; set; }

        [StringLength(50, ErrorMessage = "Station code cannot exceed 50 characters")]
        public string? StationCode { get; set; }

        [Required(ErrorMessage = "Station type is required")]
        [StringLength(50, ErrorMessage = "Station type cannot exceed 50 characters")]
        public string StationType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Installation date is required")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }

        public bool IsActive { get; set; } = true;

        [Range(0, double.MaxValue, ErrorMessage = "Elevation must be a positive number")]
        public double? Elevation { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string? ContactPhone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? ContactEmail { get; set; }

        [StringLength(100, ErrorMessage = "Responsible person name cannot exceed 100 characters")]
        public string? ResponsiblePerson { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Monitoring interval must be greater than 0")]
        public int? MonitoringIntervalMinutes { get; set; }

        [StringLength(50, ErrorMessage = "Equipment model cannot exceed 50 characters")]
        public string? EquipmentModel { get; set; }

        [StringLength(50, ErrorMessage = "Equipment serial number cannot exceed 50 characters")]
        public string? EquipmentSerialNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LastMaintenanceDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NextMaintenanceDate { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string? Notes { get; set; }

        // Power supply information
        public bool HasBackupPower { get; set; } = false;

        [StringLength(50, ErrorMessage = "Power source cannot exceed 50 characters")]
        public string? PowerSource { get; set; }

        // Communication settings
        [StringLength(50, ErrorMessage = "Communication type cannot exceed 50 characters")]
        public string? CommunicationType { get; set; }

        [StringLength(100, ErrorMessage = "Network settings cannot exceed 100 characters")]
        public string? NetworkSettings { get; set; }

        // Calibration information
        [DataType(DataType.Date)]
        public DateTime? LastCalibrationDate { get; set; }

        [Range(1, 365, ErrorMessage = "Calibration interval must be between 1 and 365 days")]
        public int? CalibrationIntervalDays { get; set; }

        // Environmental conditions
        [Range(-50, 70, ErrorMessage = "Operating temperature min must be between -50 and 70°C")]
        public double? OperatingTempMin { get; set; }

        [Range(-50, 70, ErrorMessage = "Operating temperature max must be between -50 and 70°C")]
        public double? OperatingTempMax { get; set; }

        [Range(0, 100, ErrorMessage = "Humidity range must be between 0 and 100%")]
        public double? HumidityRange { get; set; }

        // Data validation
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(StationType) &&
                   AreaId > 0 &&
                   Latitude >= -90 && Latitude <= 90 &&
                   Longitude >= -180 && Longitude <= 180 &&
                   InstallationDate <= DateTime.Now;
        }

        // Helper method to generate station code if not provided
        public void GenerateStationCode()
        {
            if (string.IsNullOrWhiteSpace(StationCode))
            {
                var namePrefix = Name.Length >= 3 ? Name.Substring(0, 3).ToUpper() : Name.ToUpper();
                var timestamp = DateTime.Now.ToString("yyyyMMdd");
                StationCode = $"{namePrefix}-{AreaId:D3}-{timestamp}";
            }
        }

        // Set default values
        public void SetDefaults()
        {
            if (InstallationDate == default(DateTime))
                InstallationDate = DateTime.Now;

            if (MonitoringIntervalMinutes == null)
                MonitoringIntervalMinutes = 15; // Default 15 minutes

            if (CalibrationIntervalDays == null)
                CalibrationIntervalDays = 90; // Default 90 days

            if (string.IsNullOrWhiteSpace(PowerSource))
                PowerSource = "AC Power";

            if (string.IsNullOrWhiteSpace(CommunicationType))
                CommunicationType = "Ethernet";
        }
    }
}