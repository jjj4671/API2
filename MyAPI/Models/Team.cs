using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Team
    {
        [Key]
        public int TeamNo { get; set; }
        public int TablePos { get; set; }
        public int LastYearPos { get; set; }
        public string UCLQualify { get; set; }   
    }
}
