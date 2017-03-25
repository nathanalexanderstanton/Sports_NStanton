using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Sports_NStanton.Models
{
    [Table("PlayerGameStats")]
    public class PlayerGameStat
    {
        [Key]
        public int PlayerGameStatID { get; set; } // PlayerGameStatID(Integer, Primary Key)
        [Required]
        [ForeignKey("Game")]
        public int GameID { get; set; } // GameID(Integer, Foreign Key, Required)
        [Required]
        [ForeignKey("Player")]
        public int PlayerID { get; set; } // PlayerID(Integer, Foreign Key, Required, [GameID, PlayerID] pair are Unique)
        [Required]
        public int ShotsOnGoal { get; set; } // ShotsOnGoal(Integer, Required)
        [Required]
        public DateTime CreateDate { get; set; } // CreateDate(Date, Default to time record is created, Required)

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }

        public PlayerGameStat()
        {
            CreateDate = DateTime.Now;
        }
    }
}