using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVS2019_Module_2.Models
{
    public class GameModel
    {
        public int Id { get; set; } = 1;
        public  string Name { get; set; }
        public  int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public  string Image { get; set; }
    }
}
