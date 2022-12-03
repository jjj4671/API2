
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Player
    {
        [Key]
        public string PlayerName { get; set; }
        public int TeamNo { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public string TopTen { get; set; }
    }
}
