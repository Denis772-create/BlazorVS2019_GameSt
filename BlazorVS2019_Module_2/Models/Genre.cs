using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVS2019_Module_2.Models
{
    public class Genre
    {
        public  int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public  string Name { get; set; }
    }
}
