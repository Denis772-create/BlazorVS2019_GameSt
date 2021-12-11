using System;
using System.Collections.Generic;
using System.Linq;
using BlazorVS2019_Module_2.Models;

namespace BlazorVS2019_Module_2.Data.Propository
{
    public class GameRepository : IRepository
    {
        private List<GameModel> _gameModels;
        private List<Genre> _genres;

        public GameRepository()
        {
            _gameModels = new List<GameModel>()
            {
                new GameModel()
                {
                    Name = "Rateridid",
                    GenreId =  1,
                    Image = "images/1060.jpg",
                    ReleaseDate = DateTime.Now
                },
                new GameModel()
                {
                    Name = "Rateridid",
                    GenreId =  2,
                    Image = "images/doodle-champion-island-games-begin-6753651837108462.2-2xa.gif",
                    ReleaseDate = DateTime.Now
                },
                new GameModel()
                {
                    Name = "Rateridid",
                    GenreId =  3,
                    Image = "images/1060.jpg",
                    ReleaseDate = DateTime.Now
                }
            };


            _genres = new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Sdfn"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "WERTdfn"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "QSADFdfn"
                }
            };
        }

        public List<GameModel> GetAllGames()
        {
            return _gameModels;
        }

        public List<Genre> GetAllGenres()
        {
            return _genres;
        }

        public Genre GetGenreById(int id)
        {
            return _genres.FirstOrDefault((genre => genre.Id == id));
        }

        public bool EditGenre(Genre editedGenre)
        {
            var oldGenre = _genres.FirstOrDefault(x => x.Id == editedGenre.Id);

            if (oldGenre != null)
            {
                oldGenre = editedGenre;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
