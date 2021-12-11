using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorVS2019_Module_2.Models;

namespace BlazorVS2019_Module_2.Data.Propository
{
    public interface IRepository
    {
        List<GameModel> GetAllGames();
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        bool EditGenre(Genre editedGenre);
    }
}
