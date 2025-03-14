using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission10Backend.Data
{
    public class Bowler
    {
        [Key]
        public int BowlerId { get; set; }
        public string? BowlerLastName { get; set; }
        public string? BowlerFirstName { get; set; }
        public string? BowlerMiddleInit { get; set; }
        public string? BowlerAddress { get; set; }
        public string? BowlerCity { get; set; }
        public string? BowlerState { get; set; }
        public string? BowlerZip { get; set; }
        public string? BowlerPhoneNumber { get; set; }
        
        [ForeignKey("TeamId")]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }

    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public int? CaptainId { get; set; }
    }
}