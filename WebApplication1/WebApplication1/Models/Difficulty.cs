using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Difficulty
    {
        [Key]
        public int DifficultyId { get; set; }
        public string Name { get; set; }
    }
}