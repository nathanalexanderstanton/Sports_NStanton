using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Sports_NStanton.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; } // PlayerID(Integer, Primary Key)
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name(String 100 characters, Required)
        public DateTime DateOfBirth { get; set; } // DateOfBirth(Date)
        [Required]
        public DateTime CreateDate { get; set; } // CreateDate(Date, Default to time record is created, Required)

        public ICollection<PlayerGameStat> PlayerGameStats { get; set; }

        public Player()
        {
            CreateDate = DateTime.Now;
        }
    }
}