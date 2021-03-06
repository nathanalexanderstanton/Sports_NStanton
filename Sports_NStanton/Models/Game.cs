﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Sports_NStanton.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int GameID { get; set; } //GameID(Integer, Primary Key)
        [Required]
        [StringLength(100)]
        public string Name { get; set; } //Name(String 100 characters, Required)
        [Required]
        public DateTime GameDate { get; set; } //GameDate(Date, Required)
        [Required]
        public DateTime CreateDate { get; set; } //CreateDate(Date, Default to time record is created, Required)

        public ICollection<PlayerGameStat> PlayerGameStats { get; set; }

        public Game()
        {
            CreateDate = DateTime.Now;
        }
    }
}